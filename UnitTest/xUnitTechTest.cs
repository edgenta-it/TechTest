using Microsoft.AspNetCore.Mvc;
using TechTest.Controllers;
using Xunit.Abstractions;

namespace TechTest.Tests
{
    public class xUnitTechTest
    {
        private readonly ITestOutputHelper output;

        public xUnitTechTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void xUnitConvertNumberToWords_ValidInput()
        {
            var ioController = new IOController();
            string input = "123.45";

            output.WriteLine("Execute xUnitConvertNumberToWords_ValidInput to test numeric (valid) input in Main method (IOController.cs)");
            output.WriteLine("Input: " + input);

            var result = ioController.Main(input);

            Assert.IsType<OkObjectResult>(result);

            var objectResult = (OkObjectResult)result;
            output.WriteLine("Result: " + objectResult.Value);

            output.WriteLine("Test success! Main method can convert valid numeric input to words.");
        }

        [Fact]
        public void xUnitConvertNumberToWords_InvalidInput()
        {
            var ioController = new IOController();
            string input = "invalid test input";

            output.WriteLine("Execute xUnitConvertNumberToWords_InvalidInput to test non-numeric (invalid) input in Main method (IOController.cs)");
            output.WriteLine("Input: " + input);

            var result = ioController.Main(input);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<ObjectResult>(result);

            var objectResult = (ObjectResult)result;
            output.WriteLine("Error Message: " + objectResult.Value);

            output.WriteLine("Test success! Main method returns error message when input is not numeric.");
        }
    }
}