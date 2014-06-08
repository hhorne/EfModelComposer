##EfModelComposer

Manually adding and maintaining EntityFramework type configurations can be a pain. K Scott Allen wrote [a great blog post](http://odetocode.com/blogs/scott/archive/2011/11/28/composing-entity-framework-fluent-configurations.aspx) showing how to use MEF in order to add configurations in a scalable way. This library packages the provided approach into a pluggable way.

[![Build status](https://ci.appveyor.com/api/projects/status/vpjnu4fhpkvq6pvk)](https://ci.appveyor.com/project/hhorne/efmodelcomposer)

**Install from Nuget**

	Install-Package EfModelComposer

**Example Usage** 

	class FooContext : DbContext
	{
		...
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.ComposeModelConfiguration(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
		...
	}
	
	class City
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	[ExportConfiguration]
	class CityConfig : EntityConfiguration<City>
	{
		public CityConfig()
		{
			Property(c => c.Name).HasMaxLength(100);
		}
	}

Once your DbContext is configured to call the ComposeModelConfiguration extension method any exported EntityConfiguration (a derived type of EntityTypeConfiguration) will be automatically found and loaded when OnModelCreating is called.