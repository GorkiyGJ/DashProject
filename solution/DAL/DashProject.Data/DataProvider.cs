using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using Manitou.Data.Provider;
using System.Web;
using System.Configuration.Provider;
using System.Reflection;

namespace DashProject.Data
{
    public sealed class DataProvider
    {
        private static volatile ManitouProvider _provider = null;
      
        private static volatile ManitouProviderCollection _providers = null;
        private static volatile ManitouServiceSection _section = null;
        private static volatile Configuration _config = null;

        private static object SyncRoot = new object();

        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                // use default ConnectionStrings if _section has already been discovered
                if (_config == null && _section != null)
                {
                    return WebConfigurationManager.ConnectionStrings;
                }

                return Configuration.ConnectionStrings.ConnectionStrings;
            }
        }

        public static string DefaultConectinString
        {
            get { return Provider.ConnectionString; }
        }

        #region Provider

        #region LoadProvider
        internal static void LoadProvider(ManitouProvider provider)
        {
            LoadProvider(provider, false);
        }

        internal static void LoadProvider(ManitouProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
            {
                lock (SyncRoot)
                {
                    if (_providers == null)
                        _providers = new ManitouProviderCollection();
                }
            }

            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if (_provider == null || setAsDefault)
                        _provider = provider;
                }
            }
        }

        private static void LoadProviders()
        {
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    if (_provider == null)
                    {
                        _providers = new ManitouProviderCollection();

                        ProvidersHelper.InstantiateProviders(ManitouSection.Providers, _providers, typeof(ManitouProvider));
                        _provider = (ManitouProvider)_providers[ManitouSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default ManitouProvider");
                        }
                    }
                }
            }
        }
        #endregion

        protected internal static ManitouProvider Provider
        {
            get 
            { 
                LoadProviders(); 
                return _provider; 
            }
        }

        protected internal static ManitouProviderCollection Providers
        {
            get
            {
                LoadProviders();
                return _providers;
            }
        }
        #endregion        

        #region Coniguration
        internal static ManitouServiceSection ManitouSection
        {
            get
            {
                if (_section == null)
                {
                    if (Configuration != null)
                    {
                        _section = Configuration.GetSection("ManitouService") as ManitouServiceSection;

                        if (_section == null)
                            _section = Configuration.GetSection("Manitou") as ManitouServiceSection;

                        if (_section == null)
                        {
                            foreach (ConfigurationSection section in Configuration.Sections)
                            {
                                if (section is ManitouServiceSection)
                                {
                                    _section = section as ManitouServiceSection;
                                    break;
                                }
                            }
                        }
                    }

                    if (_section == null)
                        _section = WebConfigurationManager.GetSection("ManitouService") as ManitouServiceSection;

                    if (_section == null)
                        _section = WebConfigurationManager.GetSection("Manitou") as ManitouServiceSection;
                }

                if (_section == null)
                    throw new ProviderException("Unable to load ManitouServiceSection");

                return _section;
            }
        }

        internal static Configuration Configuration
        {
            get
            {
                if (_config == null)
                {
                    if (System.IO.File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "DashProject.Data.dll.config")))
                    {
                        ExeConfigurationFileMap configMap = new ExeConfigurationFileMap { ExeConfigFilename = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "DashProject.Data.dll.config") };
                        _config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                    }
                    else
                    {
                        Assembly[] asm = AppDomain.CurrentDomain.GetAssemblies();
                        foreach (Assembly a in asm)
                        {
                            if (a.ManifestModule.Name == "DashProject.Data.dll")
                            {
                                string path = System.IO.Path.GetDirectoryName(a.Location);
                                if (System.IO.File.Exists(System.IO.Path.Combine(path, "DashProject.Data.dll.config")))
                                {
                                    _config = ConfigurationManager.OpenExeConfiguration(System.IO.Path.Combine(path, "DashProject.Data.dll"));
                                    break;
                                }
                            }
                        }
                    }

                    if (_config == null)
                    {
                        if (HttpContext.Current != null)
                        {
                            _config = WebConfigurationManager.OpenWebConfiguration("~");
                        }
                        else
                        {
                            String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                            if (configFile.ToLower().Contains("devenv.exe"))
                                _config = GetDesignTimeConfig();
                            else
                                _config = ConfigurationManager.OpenExeConfiguration(System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, AppDomain.CurrentDomain.FriendlyName));
                        }
                    }
                }

                return _config;
            }
        }

        private static Configuration GetDesignTimeConfig()
        {
            ExeConfigurationFileMap configMap = null;

            // Get an instance of the currently running Visual Studio IDE.
            EnvDTE80.DTE2 dte = (EnvDTE80.DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.9.0");
            if (dte != null)
            {
                dte.SuppressUI = true;

                EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
                if (item != null)
                {
                    if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
                    {
                        System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);

                        configMap = new ExeConfigurationFileMap();
                        configMap.ExeConfigFilename = String.Format("{0}\\{1}", info.Directory.FullName, item.Name); 
                    }
                    else
                    {
                        configMap = new ExeConfigurationFileMap();
                        configMap.ExeConfigFilename = item.get_FileNames(0);
                    }
                }
            }

            return ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        }
        #endregion
    }
}