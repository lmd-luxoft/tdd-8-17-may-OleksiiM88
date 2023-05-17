using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementService.DA.Interfaces.DTO;

namespace TaskManagementService.DA.Interfaces
{
    public interface IDataAccess
	{
		DataTask[] GetTasks(int userId);
	}
}
