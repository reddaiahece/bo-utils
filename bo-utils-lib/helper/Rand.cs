
namespace BusinessObjectsUtils.helper
{
    class Rand
    {
        static System.Random random = new System.Random();

        public static int Number(int min, int max)
        {
            return random.Next(min, max+1);
        }

        public static void Exception(int chances, string message)
        {
            if (random.Next(1, chances) == 1)
                throw new System.Exception(message);
        }

        public static string Time(string minTime, string maxTime)
        {
            System.DateTime minTime_ = System.DateTime.Parse(minTime);
            System.DateTime maxTime_ = System.DateTime.Parse(maxTime);
            int nbsec = random.Next(0, (int)((maxTime_ - minTime_).TotalSeconds));
            return minTime_.AddSeconds(nbsec).ToString("HH:mm:ss");
        }

        public static System.DateTime Date(System.DateTime minDate, System.DateTime maxDate)
        {
            int nbdays = random.Next(0, (int)((maxDate - minDate).TotalDays));
            return minDate.AddDays(nbdays);
        }

        public static System.DateTime DateTime(System.DateTime minDateTime, System.DateTime maxDateTime)
        {
            int nbseconds = random.Next(0, (int)((maxDateTime - minDateTime).TotalSeconds));
            return minDateTime.AddSeconds(nbseconds);
        }

        public static string Date(string minDate, string maxDate, string format)
        {
            return Rand.Date(System.DateTime.Parse(minDate), System.DateTime.Parse(maxDate)).ToString(format);
        }

        public static string DateTime(string minDateTime, string maxDateTime, string format)
        {
            return Rand.DateTime(System.DateTime.Parse(minDateTime), System.DateTime.Parse(minDateTime)).ToString(format);
        }

        public static string DateFromNow(int nbDays, string format)
        {
            int lNbDays;
            if(nbDays<0){
                lNbDays = -Rand.Number(0, -nbDays);
            }else{
                lNbDays = Rand.Number(0, nbDays);
            }
            return System.DateTime.Now.AddDays(lNbDays).AddHours(Rand.Number(0, 23)).AddMinutes(Rand.Number(0, 59)).AddSeconds(Rand.Number(0, 59)).ToString(format);
        }

        public static string DateTimeFromNow(int nbDays, string format)
        {
            return System.DateTime.Now.AddDays(Rand.Number(0, nbDays)).ToString(format);
        }

        public static string List(params string[] list)
        {
            int index = random.Next(1, list.Length + 1);
            return list[index - 1];
        }

        /// <summary>
        /// Generates a random string with the given length
        /// </summary>
        /// <param name="size">Size of the string</param>
        /// <param name="lowerCase">If true, generate lowercase string</param>
        /// <returns>Random string</returns>
        public static string String(int size, bool lowerCase = false)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = System.Convert.ToChar(System.Convert.ToInt32(System.Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase) return builder.ToString().ToLower();
            return builder.ToString();
        }


    }
}
