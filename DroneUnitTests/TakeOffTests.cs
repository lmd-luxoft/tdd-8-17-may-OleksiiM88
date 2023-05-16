using Drone;
using Drone.Exceptions;

namespace DroneUnitTests
{
	public class TakeOffTests : IDisposable
	{
        private readonly Quadrocopter _quadrocopter;
		private readonly GpsModule _gpsModule;
		private readonly FlyController _flyController;

        public TakeOffTests()
        {
			_flyController = new FlyController();
			_gpsModule = new GpsModule();
			var compass = new Compass();
			_quadrocopter = new Quadrocopter(compass, _gpsModule, _flyController);
		}

        [Fact]
		public void TakeOffNotAvailableIfBadGpsSignal()
		{
			Assert.Throws<GpsException>(() => _quadrocopter.TakeOff());
		}

		[Fact]
		public void TakeOffNotAvailableIfCompassNotCalibration()
		{
			//Arrange
			var mockCompass = Substitute.For<Compass>();
			mockCompass.IsCalibration().Returns(false);
			Quadrocopter quadrocopter = new Quadrocopter(mockCompass, _gpsModule, _flyController);

			//Act + Assert
			Assert.Throws<CompassException>(() => quadrocopter.TakeOff());
			mockCompass.DidNotReceive().HorizontalCalibration();
			mockCompass.DidNotReceive().VerticalCalibration();
		}

		[Fact]
		public void NormalTakeoff()
		{
			//Arrange
			var mockCompass = Substitute.For<Compass>();
			mockCompass.IsCalibration().Returns(true);
			Quadrocopter quadrocopter = new Quadrocopter(mockCompass, _gpsModule, _flyController);
			//Act
			quadrocopter.TakeOff();

			//Assert
			mockCompass.Received().HorizontalCalibration();
			mockCompass.Received().VerticalCalibration();
		}

		public void Dispose()
		{
			//TODO as TearDown!
		}
	}
}