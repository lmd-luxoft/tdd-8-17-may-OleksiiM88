using Microsoft.Extensions.DependencyInjection;
using TaskManagementService.BL;
using TaskManagementService.BL.Interfaces;

namespace TaskManagementService.UT
{
	public class SimpleBLOperationsTestFixture : BaseDITest
	{
		[Fact]
		public void SampleTestForDemo()
		{
			var bl = GetService<IBusinessLogic>();
		}

		protected override void Configure(IServiceCollection services)
		{
			services.AddScoped<IBusinessLogic, BusinessLogicImpl>();
		}
	}
}