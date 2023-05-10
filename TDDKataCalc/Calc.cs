namespace TDDKataCalc
{
	public class Calc
	{
		public int Add(string digits)
		{
			if(String.IsNullOrEmpty(digits))
				return 0;

			string[] values = digits.Split(',');

			if (values.Length == 1)
				return -1;

			int result = 0;
			foreach(string value in values)
			{
				if (int.TryParse(value, out int digit))
				{
					result += digit;
				}
				else
				{
					return - 1;
				}
			}
			return result;
		}
	}
}