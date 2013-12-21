#region Libraries
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Web.Model.Infrastructure.Configuration
{
    /// <summary>
    /// Provides access to configuration files for applications.
    /// This class is a wrapper of <see cref="ConfigurationManager"/>.
    /// </summary>
    public class ConfigurationManagerWrapper : IConfigurationManager
    {
        /// <summary>
        /// Gets the <see cref="ConnectionStringSettingsCollection"/> data for the current application's default configuration.
        /// </summary>
        public ConnectionStringSettingsCollection ConnectionStrings
        {
            [DebuggerStepThrough]
            get { return ConfigurationManager.ConnectionStrings; }
        }

        /// <summary>
        /// Gets the <see cref="AppSettingsSection"/> data for the current application's default configuration.
        /// </summary>
        public NameValueCollection AppSettings
        {
            [DebuggerStepThrough]
            get { return ConfigurationManager.AppSettings; }
        }

        /// <summary>
        /// Retrieves a specified configuration section for the current application's default configuration.
        /// </summary>
        /// <param name="sectionName">The configuration section path and name.</param>
        /// <returns>The specified configuration section object, of null if the section does not exist.</returns>
        [DebuggerStepThrough]
        public object GetSection(string sectionName)
        {
            return ConfigurationManager.GetSection(sectionName);
        }

        /// <summary>
        /// Retrieves a specified configuration section for the current application's default configuration.
        /// </summary>
        /// <typeparam name="T">A generic parameter that specifies the type of the configuration section.</typeparam>
        /// <param name="sectionName">The configuration section path and name.</param>
        /// <returns>The specified configuration section object, of null if the section does not exist.</returns>
        [DebuggerStepThrough]
        public T GetSection<T>(string sectionName) where T : ConfigurationSection
        {
            return ConfigurationManager.GetSection(sectionName) as T;
        }

        /// <summary>
        /// Refreshes the named section so the next time that it is retrieved it will be re-read from disk.
        /// </summary>
        /// <param name="sectionName">The configuration section name or the configuration path and section name of the section to refresh.</param>
        [DebuggerStepThrough]
        public void RefreshSection(string sectionName)
        {
            ConfigurationManager.RefreshSection(sectionName);
        }

        /// <summary>
        /// Opens the configuration file for the current application as a System.Configuration.Configuration object.
        /// </summary>
        /// <param name="userLevel">The System.Configuration.ConfigurationUserLevel for which you are opening the configuration.</param>
        /// <returns>A System.Configuration.Configuration object.</returns>
        /// <exception cref="ConfigurationErrorsException">A configuration file could not be loaded.</exception>
        [DebuggerStepThrough]
        public System.Configuration.Configuration OpenExeConfiguration(ConfigurationUserLevel userLevel)
        {
            return ConfigurationManager.OpenExeConfiguration(userLevel);
        }

    }
}
