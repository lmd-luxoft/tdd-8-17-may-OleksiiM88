using Drone;
using Drone.Exceptions;

namespace DroneUnitTests
{
	public class TakeOffTests : IDisposable
	{
        private readonly Quadrocopter _quadrocopter;

        public TakeOffTests()
        {
			var controller = new FlyController();
			var gps = new GpsModule();
			var compass = new Compass();
			_quadrocopter = new Quadrocopter(compass, gps, controller);
		}

        [Fact]
		public void TakeOffNotAvailableIfBadGpsSignal()
		{
			Assert.Throws<GpsException>(() => _quadrocopter.TakeOff());
		}

		[Fact]
		public void TakeOffNotAvailableIfCompassNotCalibration()
		{
			Assert.Throws<CompassException>(() => _quadrocopter.TakeOff());
		}

		[Fact]
		public void NormalTakeoff()
		{
			_quadrocopter.TakeOff();
		}

		public void Dispose()
		{
			//TODO as TearDown!
		}
	}
}