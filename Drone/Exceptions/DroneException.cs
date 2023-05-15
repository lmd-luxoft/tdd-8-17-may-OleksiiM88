using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone.Exceptions
{
	public class DroneException : Exception
	{
		public DroneException(string message, Exception e) : base(message, e)
		{ 
				
		}
	}
}
