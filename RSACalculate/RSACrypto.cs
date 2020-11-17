using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace RSACalculate
{
    class RSACrypto
    {
        public static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize)
        {
            for (int i = 0; i < locations.Count; i += nSize)
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
        }

        public static string generateMessage(int length)
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

        public static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        public static void isSame(string msg, string result)
        {
            if (Equals(msg, result))
                Console.WriteLine("The decrypted text is identical to plain text");
            else
                Console.WriteLine("Something is wrong! Decrypted textand plain text are not equal");
        }

        public static List<BigInteger> encryptMessage(string msg, BigInteger e, BigInteger n)
        {
            Console.WriteLine("=== ENCRYPTION ===");
            IEnumerable<string> listOfString = new List<string>();
            List<int> intList = new List<int>();
            List<BigInteger> encryptList = new List<BigInteger>();
            List<int> asc = new List<int>();

            Console.WriteLine($"{msg} | Length: {msg.Length}");
            byte[] asciiBytes = Encoding.ASCII.GetBytes(msg);
            foreach (var element in asciiBytes)
            {
                intList.Add(element);
                Console.Write(element);
            }
            Console.Write($" | Length: {asciiBytes.Length}");
            Console.WriteLine();

            IEnumerable<List<int>> listOfInt = new List<List<int>>();
            listOfInt = SplitList(intList, (int)e - 1);

            foreach (var element in listOfInt)
            {
                foreach (var el in element)
                    encryptList.Add(BigInteger.Pow(el, (int)e) % n);
            }
            for (int i = 0; i < encryptList.Count; i++)
                Console.WriteLine($"{i} | {encryptList[i]}");
            return encryptList;
        }

        private static List<int> stringToAscii(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Value cannot be null or empty.", nameof(value));
            return value.Select(System.Convert.ToInt32).ToList();
        }

        public static string decryptMessage(List<BigInteger> encryptList, BigInteger d, BigInteger n)
        {
            Console.WriteLine("=== DECRYPTION ===");
            var decryptList = new List<BigInteger>();
            var charList = new List<Char>();

            foreach (var element in encryptList)
                decryptList.Add(BigInteger.Pow(element, (int)d) % n);

            foreach (var element in decryptList)
                Console.Write(element);

            IEnumerable<BigInteger> listOfInt = new List<BigInteger>();
            listOfInt = (IEnumerable<BigInteger>)SplitList(decryptList, 2);

            foreach (var element in listOfInt)
                Console.WriteLine(element);

            foreach (var element in listOfInt)
            {
                char e = (char)element;
                Console.Write(e);
                charList.Add(e);
            }
            Console.Write($" | Length: {charList.Count}");
            Console.WriteLine();

            return charList.ToString();
        }
    }
}
