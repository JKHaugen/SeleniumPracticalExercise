namespace SeleniumPracticalExercise.Common
{
    public class Utils
    {
        // Any methods that aren't WebDriver specific and are used by more than one page object and/or test go here

        /// <summary>
        /// Holds a static Random for use in the project.
        /// </summary>
        public static Random Rnd = new Random();

        /// <summary>
        /// Returns a randomly generated string of the desired length
        /// </summary>
        /// <param name="length">The number of characters in the random string</param>
        /// <returns>The generated string</returns>
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            return new string(Enumerable.Repeat(chars, length).Select(s => s[Rnd.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Returns a randomly generated int that can have up to as many digits as the given length
        /// </summary>
        /// <param name="length">The number of possible digits in the random int</param>
        /// <returns>The generated int</returns>
        public static int GenerateRandomInt(int length)
        {
            int generatedNumber = 0;
            for (int i = 0; i < length; i++)
                generatedNumber += Rnd.Next(10) * (int)Math.Pow(10, i);

            return generatedNumber;
        }

        /// <summary>
        /// Returns a randomly generated int as a string at the desired length by padding the leading
        /// missing digits with 0 when the int value is shorter than the desired length
        /// </summary>
        /// <param name="length">The number of characters in the random string of numbers</param>
        /// <returns>The generated string converted from an int</returns>
        public static string GenerateRandomIntAsString(int length)
        {
            return $"{GenerateRandomInt(length)}".PadLeft(length,'0');
        }
    }
}