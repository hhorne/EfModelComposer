using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace EfModelComposer
{
	public class EntityConfiguration<T> : EntityTypeConfiguration<T>, IEntityConfiguration where T : class
	{
		public void AddConfiguration(ConfigurationRegistrar registrar)
		{
			registrar.Add(this);
		}
	}

	public interface IEntityConfiguration
	{
		void AddConfiguration(ConfigurationRegistrar registrar);
	}
}