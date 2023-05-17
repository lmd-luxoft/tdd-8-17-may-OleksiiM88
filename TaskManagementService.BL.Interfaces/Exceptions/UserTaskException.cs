using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementService.BL.Interfaces.Exceptions
{
	public class UserTaskException : Exception
	{
		public UserTaskException(string message, Exception e) : base(message,e) { }
	}
}
