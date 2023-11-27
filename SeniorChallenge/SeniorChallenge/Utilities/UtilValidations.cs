namespace SeniorChallenge.Utilities
{
    /// <summary>
    /// This class will center the validations of this project.
    /// </summary>
    public static class UtilValidations
    {
        private static readonly string FIELD_IS_INVALID = "{0} is invalid";

        /// <summary>
        /// Verify if the string is a valid CPF.
        /// </summary>
        /// <param name="value">The string that will be tested if it is a valid CPF.</param>
        /// <exception cref="ArgumentException">If the value is not a valid cpf, throw a ArgumentException.</exception>
        public static void CheckCPFIsValid(this string value)
        {
            bool isValid = false;
            if (value == null)
            {
                return;
            }

            int position = 0;
            int valToDV1 = 0;
            int valToDV2 = 0;
            int dv1 = 0;
            int dv2 = 0;

            bool isRepeatedDigits = true;
            int lastDigit = -1;

            foreach (int digit in from char c in value
                                  where char.IsDigit(c)
                                  let digit = c - '0'
                                  select digit)
            {
                if (position != 0 && lastDigit != digit)
                {
                    isRepeatedDigits = false;
                }

                lastDigit = digit;
                if (position < 9)
                {
                    valToDV1 += digit * (10 - position);
                    valToDV2 += digit * (11 - position);
                }
                else if (position == 9)
                {
                    dv1 = digit;
                }
                else if (position == 10)
                {
                    dv2 = digit;
                }

                position++;
            }

            if (!(position > 11 || isRepeatedDigits))
            {
                int digit1 = valToDV1 % 11;
                digit1 = digit1 < 2
                    ? 0
                    : 11 - digit1;

                if (dv1 == digit1)
                {
                    valToDV2 += digit1 * 2;
                    int digit2 = valToDV2 % 11;
                    digit2 = digit2 < 2
                        ? 0
                        : 11 - digit2;

                    isValid = dv2 == digit2;
                }
            }

            if (!isValid)
            {
                throw new ArgumentException(string.Format(FIELD_IS_INVALID, "CPF"));
            }
        }
    }
}
