using System;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace IM.EasyDev.Web.Rest.Extensions
{
    public static class HttpConfigurationExtensions
    {
        /// <summary>
        /// Configures a provided <see cref="T:System.Web.Http.HttpConfiguration" /> instance using a provided action.
        /// </summary>
        /// <param name="httpConfig">A <see cref="T:System.Web.Http.HttpConfiguration" /> instance to configure.</param>
        /// <param name="cfgAction">An action, which configures a provided <see cref="T:System.Web.Http.HttpConfiguration" /> instance.</param>
        /// <returns>A configured <see cref="T:System.Web.Http.HttpConfiguration" /> instance.</returns>
        public static HttpConfiguration ConfigWith(
            this HttpConfiguration httpConfig, Action<HttpConfiguration> cfgAction)
        {
            if (cfgAction == null)
            {
                throw new ArgumentNullException(nameof(cfgAction));
            }

            cfgAction(httpConfig);
            return httpConfig;
        }

        /// <summary>
        /// Populates the <see cref="P:System.Web.Http.HttpConfiguration.DependencyResolver" /> property for a provided <see cref="T:System.Web.Http.HttpConfiguration" /> object using a provided action.
        /// </summary>
        /// <param name="httpConfig">A <see cref="T:System.Web.Http.HttpConfiguration" /> instance to set a dependency resolver for.</param>
        /// <param name="cfgAction">An action, which returns a dependency resolver for a provided <see cref="T:System.Web.Http.HttpConfiguration" /> instance.</param>
        /// <returns>A <see cref="T:System.Web.Http.HttpConfiguration" /> instance with dependency resolver provided by a <paramref name="cfgAction"/> action.</returns>
        public static HttpConfiguration ConfigWithDependencyResolver(
            this HttpConfiguration httpConfig, Func<IDependencyResolver> cfgAction)
        {
            if (cfgAction == null)
            {
                throw new ArgumentNullException(nameof(cfgAction));
            }

            httpConfig.DependencyResolver = cfgAction();
            return httpConfig;
        }
    }
}