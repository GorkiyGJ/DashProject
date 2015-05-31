function WebModal(Anchor, AnchorID, IsClientResult, Url, WindowHeight, WindowWidth, Scrolling, Resizable, Properties, OutControlId, OutControlName) {
    
	var o = new Object;
	o.Properties = Properties;
  	var queryStringPrefix;
	if (Url.indexOf("?")==-1)
		queryStringPrefix = "?";
	else
		queryStringPrefix = "&";

	var returnValue = window.showModalDialog(Url + queryStringPrefix + "__IsModalShow=1&__LoadIFrame=True&__IsClientResult=" + IsClientResult, o, "dialogHeight:" + WindowHeight + "; dialogWidth:" + WindowWidth + "; status:off; center:yes; help:off;resizable:yes;scrollbars=1;");

	if(IsClientResult == "False")
	{
	    if(returnValue != null)
	        document.getElementById("__WebModalData").value = returnValue.WebModalData;
	        
	    document.getElementById("__AnchorID").value = AnchorID;
        return true;
    }
	else if (returnValue != null && returnValue.OutPutValueId != null && returnValue.OutValueName != null)
	{ 
	   
	   document.getElementById(OutControlId).value = returnValue.OutPutValueId;
	   document.getElementById(OutControlName).value = returnValue.OutValueName; 
	   return false;
	}
    
    return false;
}

function WebModalForEditor(Url, WindowHeight, WindowWidth)
{
 
  	var queryStringPrefix;
	if (Url.indexOf("?")==-1)
		queryStringPrefix = "?";
	else
		queryStringPrefix = "&";
		
	var returnValue = window.showModalDialog(Url + queryStringPrefix + "__IsModalShow=1&__LoadIFrame=True&__IsClientResult=True", null, "dialogHeight:" + WindowHeight + "; dialogWidth:" + WindowWidth + "; status:off; center:yes; help:off;resizable:yes;scrollbars=1;");
	
	if (returnValue != null && returnValue.OutPutValueId != null && returnValue.OutValueName != null)
	{ 	   
	  return returnValue;
	}
    
    return null; 
}

function WireClientSideEvent(control, event, functionToAttach)
{
	var ctrl;
	if (typeof(control) != "undefined")
	{
		ctrl = control;
	}
	else
	{
		ctrl = document.getElementById(control);
	}

	if (typeof(ctrl) != "undefined")
	{
		if ( typeof( ctrl.addEventListener ) != "undefined" ) {
				ctrl.addEventListener(event, functionToAttach, false);
			} 
		else if ( typeof ( ctrl.attachEvent ) != "undefined" ) 
		{
			ctrl.attachEvent(event, functionToAttach);
		} 
		else 
		{
			ctrl[event] = functionToAttach;
		}
	}
}
