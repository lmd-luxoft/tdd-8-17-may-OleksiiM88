using System.Data.Common;
using System.Reflection.Metadata;
using TDDKataCalc;

namespace TDDKata
{
	public class CalcTests
	{
		private readonly Calc _calc;
        public CalcTests()
        {
            _calc = new Calc();
        }

        [Fact]
		public void ReturnZeroAsEmptyInputString()
		{
			//Arrange
			int expected = 0;

			//Act
			decimal actual = _calc.Add(String.Empty);

			//Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void ReturnZeroAsNullInputString()
		{
			//Arrange
			int expected = 0;

			//Act
			decimal actual = _calc.Add(digits: null);

			//Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PassOnlyOneParameter()
		{
			//Arrange
			string parameter = "1";
			int expected = 1;

			//Act
			decimal actual = _calc.Add(parameter);

			//Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PassOnlyOneParameterButNotDigitShouldThrowException()
		{
			//Arrange
			string parameter = "T";

			//Act & Assert
			Assert.Throws<InvalidOperationException>(() => _calc.Add(parameter));
		}

		[Fact]
		public void PassTwoParametersAsDigits()
		{
			//Arrange
			string parameters = "1,2";
			int expected = 3;

			//Act
			decimal actual = _calc.Add(parameters);

			//Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PassMoreThenTwoParametersAsDigits()
		{
			//Arrange
			string parameters = "1,24,15";
			int expected = 40;

			//Act
			decimal actual = _calc.Add(parameters);

			//Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PassFloatsParametersAsDigits()
		{
			//Arrange
			string parameters = "1.5,2.6";
			decimal expected = 4.1m;

			//Act
			decimal actual = _calc.Add(parameters);

			//Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PassCharAndDigitAsParametersShouldThrowException()
		{
			//Arrange
			string parameters = "#,2.6";

			//Act & Assert
			Assert.Throws<InvalidOperationException>(() => _calc.Add(parameters));
		}

		[Fact]
		public void PassNegativeParametersAsDigits()
		{
			//Arrange
			string parameters = "-45,-2";
			decimal expected = -47;

			//Act
			decimal actual = _calc.Add(parameters);

			//Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PassBigLongParametersAsDigitsShouldThrowException()
		{
			//Arrange
			string parameters = "23435345546546456546890797897897,123132131344553423423423478978976767858";

			//Act & Assert
			Assert.Throws<InvalidOperationException>(() => _calc.Add(parameters));
		}

		[Fact]
		public void PassDecimalsParametersAsDigits()
		{
			//Arrange
			string parameters = "5.4,3.8";
			decimal expected = 9.2m;

			//Act
			decimal actual = _calc.Add(parameters);

			//Assert
			Assert.Equal(expected, actual);
		}
	}
}