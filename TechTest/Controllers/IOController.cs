using Microsoft.AspNetCore.Mvc;

namespace TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IOController : ControllerBase
    {
        #region Main
        [HttpGet]
        public IActionResult Main(string inputNumber)
        {
            try
            {
                string result = GenerateResult(inputNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        #endregion

        #region GenerateResult
        public string GenerateResult(string inputNumber)
        {
            if (decimal.TryParse(inputNumber, out decimal number))
            {
                string dollars = ConvertNumberToWords((int)Math.Truncate(number));
                string cents = ConvertNumberToWords((int)((number - Math.Truncate(number)) * 100));

                if (string.IsNullOrEmpty(dollars) || string.IsNullOrEmpty(cents))
                {
                    return "Wrong input. User insert non numerical value";
                }

                string result = $"{dollars} DOLLARS AND {cents} CENTS";
                return result;
            }
            else
            {
                return "Wrong input. User insert non numerical value";
            }
        }
        #endregion

        #region ConvertNumberToWords
        private string ConvertNumberToWords(int number)
        {
            try
            {
                if (number == 0)
                {
                    return "ZERO";
                }

                if (number < 0)
                {
                    return "MINUS " + ConvertNumberToWords(Math.Abs(number));
                }

                string words = "";

                if ((number / 1000000) > 0)
                {
                    words += ConvertNumberToWords(number / 1000000) + " MILLION ";
                    number %= 1000000;
                }

                if ((number / 1000) > 0)
                {
                    words += ConvertNumberToWords(number / 1000) + " THOUSAND ";
                    number %= 1000;
                }

                if ((number / 100) > 0)
                {
                    words += ConvertNumberToWords(number / 100) + " HUNDRED ";
                    number %= 100;
                }

                if (number > 0)
                {
                    if (words != "")
                    {
                        words += "AND ";
                    }

                    string[] unitToWordList = { "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                    string[] tensToWordList = { "", "", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                    if (number < 20)
                    {
                        words += unitToWordList[number];
                    }
                    else
                    {
                        words += tensToWordList[number / 10];

                        if ((number % 10) > 0)
                        {
                            words += "-" + unitToWordList[number % 10];
                        }
                    }
                }

                return words.Trim();
            }
            catch (FormatException)
            {
                return "Wrong input. User insert non numerical value";
            }
        }
        #endregion
    }
}
