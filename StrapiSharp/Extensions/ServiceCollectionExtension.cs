using Microsoft.Extensions.DependencyInjection;

namespace StrapiSharp.Extensions
{
	public static class ServiceCollectionExtension
	{
		/// <summary>
		/// Adds a <see cref="Strapi"/> object as a singleton instance.
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/>.</param>
		/// <param name="host">The Strapi host to make requests against.</param>
		/// <returns>Continues the <see cref="IServiceCollection"/> chain.</returns>
		public static IServiceCollection AddStrapiSharp(this IServiceCollection services, string host)
		{
			services.AddSingleton(new Strapi(host));
			return services;
		}
	}
}

