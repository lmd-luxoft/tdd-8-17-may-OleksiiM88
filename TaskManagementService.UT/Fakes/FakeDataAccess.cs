using Moq;
using TaskManagementService.DA.Interfaces;
using TaskManagementService.DA.Interfaces.DTO;

namespace TaskManagementService.UT.Fakes
{
	public class FakeDataAccess : IDataAccess
	{
		public readonly Mock<IDataAccess> _mock = new Mock<IDataAccess>();
		public DataTask[] GetTasks(int userId)
		{
			return _mock.Object.GetTasks(userId);
		}
	}
}
