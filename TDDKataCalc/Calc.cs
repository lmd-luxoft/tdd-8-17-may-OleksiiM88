namespace TDDKataCalc
{
	public class Calc
	{
		public int Add(string digits)
		{
			if(String.IsNullOrEmpty(digits))
				return 0;
			
			if (digits.Length == 1)
			{
				if (int.TryParse(digits, out int digit))
				{
					return digit;
				}
				else
				{
					return -1;
				}

			}

			string[] values = digits.Split(',');
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