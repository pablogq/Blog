#region Libraries
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Web.Model.Infrastructure.Configuration
{
    /// <summary>
    /// Provides an interface to access configuration files for applications.
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        /// Gets the <see cref="ConnectionStringSettingsCollection"/> data for the current application's default configuration.
        /// </summary>
        ConnectionStringSettingsCollection ConnectionStrings { get; }

        /// <summary>
        /// Gets the <see cref="AppSettingsSection"/> data for the current application's default configuration.
        /// </summary>
        NameValueCollection AppSettings { get; }

        /// <summary>
        /// Retrieves a specified configuration section for the current application's default configuration.
        /// </summary>
        /// <param name="sectionName">The configuration section path and name.</param>
        /// <returns>The specified configuration section object, of null if the section does not exist.</returns>
        object GetSection(string sectionName);

        /// <summary>
        /// Retrieves a specified configuration section for the current application's default configuration.
        /// </summary>
        /// <typeparam name="T">A generic parameter that specifies the type of the configuration section.</typeparam>
        /// <param name="sectionName">The configuration section path and name.</param>
        /// <returns>The specified configuration section object, of null if the section does not exist.</returns>
        T GetSection<T>(string sectionName) where T : ConfigurationSection;

        /// <summary>
        /// Refreshes the named section so the next time that it is retrieved it will be re-read from disk.
        /// </summary>
        /// <param name="sectionName">The configuration section name or the configuration path and section name of the section to refresh.</param>
        void RefreshSection(string sectionName);

        /// <summary>
        /// Opens the configuration file for the current application as a System.Configuration.Configuration object.
        /// </summary>
        /// <param name="userLevel">The System.Configuration.ConfigurationUserLevel for which you are opening the configuration.</param>
        /// <returns>A System.Configuration.Configuration object.</returns>
        /// <exception cref="ConfigurationErrorsException">A configuration file could not be loaded.</exception>
        System.Configuration.Configuration OpenExeConfiguration(ConfigurationUserLevel userLevel);
    }
}
