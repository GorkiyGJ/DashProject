using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Web;
using System.Data;
using System.Collections.Specialized;

namespace Winnetou.WebControls.DataSources
{
    public class extObjectDataSourceView : ObjectDataSourceView
    {
        extObjectDataSource owner;
        HttpContext context;

        public extObjectDataSourceView(extObjectDataSource owner, string name, HttpContext context)
            : base(owner, name, context)
        {
            this.owner = owner;
            this.context = context;
            this.TypeName = name;
        }

        string FormatOldParameter(string name)
        {
            string f = OldValuesParameterFormatString;
            if (f.Length > 0)
                return String.Format(f, name);
            else
                return name;
        }

        IOrderedDictionary MergeParameterValues(ParameterCollection viewParams, IDictionary values, IDictionary oldValues, bool allwaysAddNewValues)
        {
            OrderedDictionary mergedValues = new OrderedDictionary();
            foreach (Parameter p in viewParams)
            {
                bool oldAdded = false;
                if (oldValues != null && oldValues.Contains(p.Name))
                {
                    object val = Convert.ChangeType(oldValues[p.Name], p.Type);
                    mergedValues[FormatOldParameter(p.Name)] = val;
                    oldAdded = true;
                }

                if (values != null && values.Contains(p.Name))
                {
                    object val = Convert.ChangeType(values[p.Name], p.Type);
                    mergedValues[p.Name] = val;
                }
                else if (!oldAdded || allwaysAddNewValues)
                {
                    object val = p;// GetValue(owner, true);
                    mergedValues[p.Name] = val;
                }
            }

            if (values != null)
            {
                foreach (DictionaryEntry de in values)
                    if (!mergedValues.Contains(de.Key))
                        mergedValues[de.Key] = de.Value;
            }

            if (oldValues != null)
            {
                foreach (DictionaryEntry de in oldValues)
                    if (!mergedValues.Contains(FormatOldParameter((string)de.Key)))
                        mergedValues[FormatOldParameter((string)de.Key)] = de.Value;
            }

            return mergedValues;
        }

        int QueryTotalRowCount(IOrderedDictionary mergedParameters, DataSourceSelectArguments arguments)
        {
            ObjectDataSourceSelectingEventArgs countArgs = new ObjectDataSourceSelectingEventArgs(mergedParameters, arguments, true);
            OnSelecting(countArgs);
            if (countArgs.Cancel)
                return 0;

            object count = InvokeSelect(SelectCountMethod, mergedParameters);
            return (int)Convert.ChangeType(count, typeof(int));
        }

        Exception CreateMethodException(string methodName, IOrderedDictionary parameters)
        {
            string s = "";
            foreach (string p in parameters.Keys)
            {
                s += p + ", ";
            }
            return new InvalidOperationException("ObjectDataSource " + owner.ID + " could not find a method named '" + methodName + "' with parameters " + s + "in type '" + ObjectType + "'.");
        }

        Type objectType;
        Type ObjectType
        {
            get
            {
                if (objectType == null)
                {
                    objectType = Type.GetType(TypeName);
                    if (objectType == null)
                        throw new InvalidOperationException("Type not found: " + TypeName);
                }
                return objectType;
            }
        }

        MethodInfo GetObjectMethod(string methodName, IOrderedDictionary parameters)
        {
            MemberInfo[] methods = ObjectType.GetMember(methodName);
            if (methods.Length > 1)
            {
                foreach (MemberInfo mi in methods)
                {
                    MethodInfo me = mi as MethodInfo;
                    if (me != null && me.GetParameters().Length == parameters.Count)
                    {
                        int i = -1;
                        bool isOk = true;
                        foreach (DictionaryEntry de in parameters)
                        {
                            i++;
                            if (de.Key.ToString().ToLower() != (me.GetParameters().GetValue(i) as System.Reflection.ParameterInfo).Name.ToLower())
                            {
                                isOk = false;
                                break;
                            }
                        }

                        if (isOk)
                            return me;
                    }
                }
            }
            else if (methods.Length == 1)
            {
                MethodInfo me = methods[0] as MethodInfo;
                if (me != null && me.GetParameters().Length == parameters.Count)
                    return me;
            }

            throw CreateMethodException(methodName, parameters);
        }

        object InvokeSelect(string methodName, IOrderedDictionary paramValues)
        {
            MethodInfo method = GetObjectMethod(methodName, paramValues);
            ObjectDataSourceStatusEventArgs rargs = InvokeMethod(method, paramValues);
            OnSelected(rargs);

            if (rargs.Exception != null && !rargs.ExceptionHandled)
                throw rargs.Exception;

            return rargs.ReturnValue;
        }

        object CreateObjectInstance()
        {
            ObjectDataSourceEventArgs args = new ObjectDataSourceEventArgs(null);
            OnObjectCreating(args);

            if (args.ObjectInstance != null)
                return args.ObjectInstance;

            object ob = Activator.CreateInstance(ObjectType);

            args.ObjectInstance = ob;
            OnObjectCreated(args);

            return args.ObjectInstance;
        }

        void DisposeObjectInstance(object obj)
        {
            ObjectDataSourceDisposingEventArgs args = new ObjectDataSourceDisposingEventArgs(obj);
            OnObjectDisposing(args);

            if (!args.Cancel)
            {
                IDisposable disp = obj as IDisposable;
                if (disp != null) disp.Dispose();
            }
        }

        ObjectDataSourceStatusEventArgs InvokeMethod(MethodInfo method, IOrderedDictionary paramValues)
        {
            object instance = null;

            if (!method.IsStatic)
                instance = CreateObjectInstance();

            ParameterInfo[] pars = method.GetParameters();

            ArrayList outParamInfos;
            object[] methodArgs = GetParameterArray(pars, paramValues, out outParamInfos);

            if (methodArgs == null)
                throw CreateMethodException(method.Name, paramValues);

            object result = null;
            Hashtable outParams = null;

            try
            {
                result = method.Invoke(instance, methodArgs);
                if (outParamInfos != null)
                {
                    outParams = new Hashtable();
                    foreach (ParameterInfo op in outParamInfos)
                        outParams[op.Name] = methodArgs[op.Position];
                }
                return new ObjectDataSourceStatusEventArgs(result, outParams, null);
            }
            catch (Exception ex)
            {
                return new ObjectDataSourceStatusEventArgs(result, outParams, ex);
            }
            finally
            {
                if (instance != null)
                    DisposeObjectInstance(instance);
            }
        }

        object[] GetParameterArray(ParameterInfo[] methodParams, IOrderedDictionary viewParams, out ArrayList outParamInfos)
        {
            outParamInfos = null;
            object[] values = new object[methodParams.Length];
            foreach (ParameterInfo mp in methodParams)
            {
                if (!viewParams.Contains(mp.Name)) 
                    return null;

                values[mp.Position] = ConvertParameter(mp.ParameterType, viewParams[mp.Name]);
                if (mp.ParameterType.IsByRef)
                {
                    if (outParamInfos == null) outParamInfos = new ArrayList();
                    outParamInfos.Add(mp);
                }
            }

            return values;
        }

        object ConvertParameter(Type targetType, object value)
        {
            return ConvertParameter(Type.GetTypeCode(targetType), value);
        }

        object ConvertParameter(TypeCode targetType, object value)
        {
            if (value == null)
            {
                if (targetType != TypeCode.Object && targetType != TypeCode.String)
                    value = 0;
                else if (targetType == TypeCode.Object && ConvertNullToDBNull)
                    return DBNull.Value;
            }

            //if (targetType == TypeCode.Object)
            //    return value;
            //else
            if (value is Parameter)
            {
                if (((Parameter)value).DefaultValue == null)
                    return null;
                else
                    if (((Parameter)value).DbType == DbType.Int32)
                    {
                        return Convert.ChangeType(((Parameter)value).DefaultValue, typeof(int));
                    }
                    else
                        return Convert.ChangeType(((Parameter)value).DefaultValue, targetType);
            }
            else if (targetType == TypeCode.Object && value is Guid)
                return (Guid)value;
            else
                return Convert.ChangeType(value, targetType);
        }

        protected override IEnumerable ExecuteSelect(DataSourceSelectArguments arguments)
        {
            arguments.RaiseUnsupportedCapabilitiesError(this);

            IOrderedDictionary paramValues = SelectParameters.GetValues(context, owner);// //MergeParameterValues(SelectParameters, null, null, true);
            ObjectDataSourceSelectingEventArgs args = new ObjectDataSourceSelectingEventArgs(paramValues, arguments, false);
            OnSelecting(args);
            if (args.Cancel)
                return new ArrayList();

            if (CanRetrieveTotalRowCount && arguments.RetrieveTotalRowCount)
                arguments.TotalRowCount = QueryTotalRowCount(paramValues, arguments);

            //if (CanPage)
            //{
            //    if (StartRowIndexParameterName.Length == 0)
            //        throw new InvalidOperationException("Paging is enabled, but the StartRowIndexParameterName property is not set.");
            //    if (MaximumRowsParameterName.Length == 0)
            //        throw new InvalidOperationException("Paging is enabled, but the MaximumRowsParameterName property is not set.");
            //    paramValues[StartRowIndexParameterName] = arguments.StartRowIndex;
            //    paramValues[MaximumRowsParameterName] = arguments.MaximumRows;
            //}

            if (SortParameterName.Length > 0)
                paramValues[SortParameterName] = arguments.SortExpression;

            object result = InvokeSelect(SelectMethod, paramValues);

            if (result is DataSet)
            {
                DataSet dset = (DataSet)result;
                if (dset.Tables.Count == 0)
                    throw new InvalidOperationException("The select method returnet a DataSet which doesn't contain any table.");
                result = dset.Tables[0];
            }

            if (result is DataTable)
            {
                DataView dview = new DataView((DataTable)result);
                if (arguments.SortExpression != null && arguments.SortExpression.Length > 0)
                {
                    dview.Sort = arguments.SortExpression;
                }
                if (FilterExpression.Length > 0)
                {
                    IOrderedDictionary fparams = FilterParameters.GetValues(context, owner);
                    ObjectDataSourceFilteringEventArgs fargs = new ObjectDataSourceFilteringEventArgs(fparams);
                    OnFiltering(fargs);
                    if (!fargs.Cancel)
                    {
                        object[] formatValues = new object[fparams.Count];
                        for (int n = 0; n < formatValues.Length; n++)
                        {
                            formatValues[n] = fparams[n];
                            if (formatValues[n] == null) return dview;
                        }
                        dview.RowFilter = string.Format(FilterExpression, formatValues);
                    }
                }
                return dview;
            }

            if (result is IEnumerable)
                return (IEnumerable)result;
            else
                return new object[] { result };
        }
    }
}