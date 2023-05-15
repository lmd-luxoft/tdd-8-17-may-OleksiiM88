using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone
{
	public class Quadrocopter
	{
		private readonly Compass _compass;
		private readonly GpsModule _gpsModule;
		private readonly FlyController _flyController;

		public Quadrocopter(Compass compass, GpsModule gpsModule, FlyController flyController)
		{
			_compass = compass;
			_gpsModule = gpsModule;
			_flyController = flyController;
		}

		public void TakeOff()
		{
			throw new NotImplementedException();
		}
	}
}
