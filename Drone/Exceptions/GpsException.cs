using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone.Exceptions
{
	public class GpsException : DroneException
	{
		public GpsException(string message, Exception e) : base(message, e)
		{
		}
	}
}
