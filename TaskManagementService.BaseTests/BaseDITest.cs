

namespace TaskManagementService.BaseTests
{
	public abstract class BaseDITest
	{
		private IServiceProvider _serviceProvider;
		private IServiceCollection _serviceCollection;

		protected abstract void Configure(IServiceCollection services);

		protected BaseDITest()
		{
			_serviceCollection = new ServiceCollection();
			Configure(_serviceCollection);
			_serviceProvider = _serviceCollection.
		}
	}
}