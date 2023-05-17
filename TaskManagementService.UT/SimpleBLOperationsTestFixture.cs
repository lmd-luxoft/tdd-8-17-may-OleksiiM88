using Microsoft.Extensions.DependencyInjection;
using TaskManagementService.BL;
using TaskManagementService.BL.Interfaces;
using TaskManagementService.BL.Interfaces.DTO;
using TaskManagementService.BL.Interfaces.Exceptions;
using TaskManagementService.DA.Interfaces;
using TaskManagementService.DA.Interfaces.Exceptions;
using TaskManagementService.UT.Fakes;
using TaskManagementService.UT.Helpers;

namespace TaskManagementService.UT
{
    public class SimpleBLOperationsTestFixture : BaseDITest
	{
		private IBusinessLogic _businessLogic;
		
		public SimpleBLOperationsTestFixture()
		{
			_businessLogic = GetService<IBusinessLogic>();
		}

		protected override void Configure(IServiceCollection services)
		{
			services.AddScoped<IBusinessLogic, BusinessLogicImpl>();
			services.AddSingleton<IDataAccess, FakeDataAccess>(); //as we're using fake and mock inside - nothing special!
		}

		[Fact]
		public void GetTaskListShouldBeSetOfTasks()
		{
			//Arrange
			int userId = 1; 
			UserTask[] expectedTaksList = new UserTask[] 
			{ 
				new UserTask {Title = "Test", Id = 1, DueDate = DateTime.Parse("18-05-2023")},
				new UserTask {Title = "Test 2", Id = 2 }
			};
			var comparer = new UserTaksComparer();

			//setup mock
			var fakeDb = (FakeDataAccess)GetService<IDataAccess>();
			fakeDb._mock.Setup(db => db.GetTasks(1))
				.Returns(new DA.Interfaces.DTO.DataTask[]
				{
					new DA.Interfaces.DTO.DataTask {Title = "Test", Id = 1, DueDate = DateTime.Parse("18-05-2023")},
					new DA.Interfaces.DTO.DataTask {Title = "Test 2", Id = 2 }
				});

			//Act
			UserTask[] actualTasksList = _businessLogic.GetTaskListByUser(userId);

			//Assert
			Assert.Equal(expectedTaksList, actualTasksList, comparer);
		}

		[Fact]
		public void GetTaskListWhenErrorShouldBeException()
		{
			//Arrange
			int userId = 1;

			//setup mock
			var fakeDb = (FakeDataAccess)GetService<IDataAccess>();
			fakeDb._mock.Setup(db => db.GetTasks(1))
				.Throws<DataAccessException>();

			//Act + Assert
			Assert.Throws<UserTaskException>(() => _businessLogic.GetTaskListByUser(userId));
		}

		[Fact]
		public void GetTaskListWhenErrorShouldBeEmptyList()
		{
			//Arrange
			int userId = 1;

			//setup mock
			var fakeDb = (FakeDataAccess)GetService<IDataAccess>();
			fakeDb._mock.Setup(db => db.GetTasks(1))
				.Returns(new DA.Interfaces.DTO.DataTask[]{ });

			//Act
			UserTask[] actualTasksList = _businessLogic.GetTaskListByUser(userId);

			//Assert
			Assert.Empty(actualTasksList);
		}

		[Fact]
		public void GetTaskListWhenUserIDNegativeShouldBeArgumentException()
		{
			//Arrange
			int userId = -1;

			//Act + Assert
			Assert.Throws<ArgumentException>(() => _businessLogic.GetTaskListByUser(userId));
		}
	}
}