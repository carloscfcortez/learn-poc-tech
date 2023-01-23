namespace inverse_string
{
    public class Utils
    {

        public string InverseString(string value)
        {
            //char[] arrayValues = value.Split('');
            string result = "";
            for (int i = value.Length - 1; i >= 0; i--)
            {
                result += value[i];
            }

            return result;
        }

    }
}