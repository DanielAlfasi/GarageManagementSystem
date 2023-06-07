using System;

namespace ConsoleUI
{
    internal class UiValidator
    {
        public delegate bool TryParseDelegate<T>(string s, out T result);

        public static string InputValidatorGeneric<T>(Func<T, string, bool> i_ValidationFunc, T i_MaxValue)
        {
            string i_UserInput = Console.ReadLine();

            while (!i_ValidationFunc(i_MaxValue, i_UserInput))
            {
                i_UserInput = ConsoleRenderer.RenderRequest("The option you entered is invalid, try again");
            }

            return i_UserInput;
        }

        public static bool IsNumberTypeAndInRange<T>(T i_HighestOptionNumber, string i_OptionToParse, TryParseDelegate<T> i_ParseMethod) where T : IComparable<T>
        {
            T valueToValidate;
            bool isValid = false;

            if (i_ParseMethod(i_OptionToParse, out valueToValidate) &&
                valueToValidate.CompareTo(i_HighestOptionNumber) <= 0 &&
                valueToValidate.CompareTo(default(T)) > 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
