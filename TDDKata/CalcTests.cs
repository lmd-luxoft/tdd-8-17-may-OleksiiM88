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
			string parameter = "5";
			int expected = -1;

			//Act
			decimal actual = _calc.Add(parameter);

			//Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PassOnlyOneParameterButNotDigitShouldHaveMinusOne()
		{
			//Arrange
			string parameter = "T";
			int expected = -1;

			//Act
			decimal actual = _calc.Add(parameter);

			//Assert
			Assert.Equal(expected, actual);
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
			// ------  DO WE EXPECT MORE THAN 2 PARAMETERS? - Done!

			//Arrange
			string parameters = "1,24,15";
			int expected = 40;

			//Act
			int actual = _calc.Add(parameters);

			//Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PassFloatsParametersAsDigits()
		{
			// ------  DO WE EXPECT FLOATS AS PARAMETERS? - Done!

			//Arrange
			string parameters = "1.5,2.6";
			decimal expected = -1;

			//Act
			decimal actual = _calc.Add(parameters);

			//Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PassCharAndDigitAsParametersShouldMinusOne()
		{
			// ------  WHAT SHOULD BE AS OUTPUT (Exception?)?

			//Arrange
			string parameters = "#,2.6";
			int expected = -1;

			//Act
			decimal actual = _calc.Add(parameters);

			//Assert
			Assert.Equal(expected, actual);
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
		public void PassBigLongParametersAsDigitsShouldMinusOne()
		{
			// ------  DO WE EXPECT PARAMETERS THAT ARE OUT OF MEMORY SCOPE?

			//Arrange
			string parameters = "23435345546546456546890797897897,123132131344553423423423478978976767858";
			decimal expected = -1;

			//Act & Assert
			//Act
			decimal actual = _calc.Add(parameters);

			//Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PassDecimalsParametersAsDigits()
		{
			//Arrange
			string parameters = "5.4,3.8";
			decimal expected = -1;

			//Act
			decimal actual = _calc.Add(parameters);

			//Assert
			Assert.Equal(expected, actual);
		}
	}
}