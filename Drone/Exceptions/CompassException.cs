namespace Drone.Exceptions
{
	public class CompassException : DroneException
	{
		public CompassException(string message, Exception e) : base(message, e)
		{
		}
	}
}
