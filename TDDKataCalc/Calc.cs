namespace TDDKataCalc
{
	public class Calc
	{
		public decimal Add(string digits)
		{
			if(String.IsNullOrEmpty(digits))
				return 0;
			
			if (digits.Length == 1)
			{
				return ValueParser(digits);
				
			}

			string[] values = digits.Split(',');
			decimal result = 0;
			foreach(string value in values)
			{
				result += ValueParser(value);
			}
			
			return result;
			
		}

		private decimal ValueParser(string value)
		{
			if (decimal.TryParse(value, out decimal digit))
			{
				return digit;
			}
			else
			{
				throw new InvalidOperationException("Value can't be parsed");
			}
		}
	}
}