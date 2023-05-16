namespace Drone
{
	public class Compass
	{
		public virtual bool IsCalibration() => throw new NotImplementedException();
		public virtual void HorizontalCalibration () => throw new NotImplementedException();
		public virtual void VerticalCalibration () => throw new NotImplementedException();
	}
}
