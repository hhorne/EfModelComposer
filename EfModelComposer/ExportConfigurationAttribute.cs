using System.ComponentModel.Composition;

namespace EfModelComposer
{
	public class ExportConfigurationAttribute : ExportAttribute
	{
		public ExportConfigurationAttribute() : base(typeof(IEntityConfiguration)) { }
	}
}