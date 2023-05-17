using TaskManagementService.BL.Interfaces;
using TaskManagementService.BL.Interfaces.DTO;
using TaskManagementService.BL.Interfaces.Exceptions;
using TaskManagementService.DA.Interfaces;
using TaskManagementService.DA.Interfaces.DTO;
using TaskManagementService.DA.Interfaces.Exceptions;

namespace TaskManagementService.BL
{
    public class BusinessLogicImpl : IBusinessLogic
	{
		private readonly IDataAccess _dataAccess;
		public BusinessLogicImpl(IDataAccess dataAccess) 
		{
			_dataAccess = dataAccess;
		}

		public UserTask[] GetTaskListByUser(int userId)
		{
			try
			{
				if (userId < 0)
					throw new ArgumentException("UserID is negative!");

				DataTask[] tasks = _dataAccess.GetTasks(userId);
				//AutoMapper to read!

				var domainTasks = tasks.Select(x => new UserTask { Title = x.Title, Id = x.Id, DueDate = x.DueDate, Comments = x.Comments });
				return domainTasks.ToArray();
			}
			catch (DataAccessException e) 
			{
				throw new UserTaskException("Unable to get list of tasks", e);
			}
		}
	}
}
