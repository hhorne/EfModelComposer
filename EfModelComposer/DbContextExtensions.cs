using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Reflection;
using EfModelComposer;

public static class DbContextExtensions
{
	/// <summary>
	/// Loads all EntityConfigurations from a specific assembly.
	/// </summary>
	/// <param name="modelBuilder"></param>
	/// <param name="assembly"></param>
	public static void ComposeModelConfiguration(this DbModelBuilder modelBuilder, Assembly assembly)
	{
		DbContextExtensions.ComposeModelConfiguration(modelBuilder, new[]{ assembly });
	}

	/// <summary>
	/// Loads all EntityConfigurations from the assemblies given.
	/// </summary>
	/// <param name="modelBuilder"></param>
	/// <param name="assemblies"></param>
	public static void ComposeModelConfiguration(this DbModelBuilder modelBuilder, IEnumerable<Assembly> assemblies)
	{
		var contextConfiguration = new ContextConfiguration();
		foreach (var assembly in assemblies)
		{
			using (var catalog = new AssemblyCatalog(assembly))
			{
				using (var container = new CompositionContainer(catalog))
				{
					container.ComposeParts(contextConfiguration);
					foreach (var configuration in contextConfiguration.Configurations)
					{
						configuration.AddConfiguration(modelBuilder.Configurations);
					}
				}
			}
		}
	}
}