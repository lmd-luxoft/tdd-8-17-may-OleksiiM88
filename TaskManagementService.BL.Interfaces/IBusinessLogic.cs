using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementService.BL.Interfaces.DTO;

namespace TaskManagementService.BL.Interfaces
{
    public interface IBusinessLogic
	{
		UserTask[] GetTaskListByUser(int userId);
	}
}
