using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace RSACalculate
{
    class RSACrypto
    {

        /// <summary>
        /// Metoda odpowiedzialna za dzielenie listy na podgrupy
        /// </summary>
        /// <typeparam name="T">Zmienna typu T</typeparam>
        /// <param name="locations">Lista zmiennych</param>
        /// <param name="nSize">Rozmiar grup</param>
        /// <returns></returns>
        private static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize)
        {
            for (int i = 0; i < locations.Count; i += nSize)
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
        }

        /// <summary>
        /// Metoda odpowiedzialna za generowanie ciągu znaków o podanej długości
        /// </summary>
        /// <param name="length">Wymagana długość ciągu</param>
        /// <returns></returns>
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

        /// <summary>
        /// Metoda odpowiedzialna za dzielenie ciągu znaków na mniejsze grupki
        /// </summary>
        /// <param name="str">Ciąg znaków</param>
        /// <param name="chunkSize">Rozmiar grup</param>
        /// <returns></returns>
        private static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        /// <summary>
        /// Metoda sprawdzająca czy stringi są identyczne
        /// </summary>
        /// <param name="msg">Tekst zwykły</param>
        /// <param name="result">Tekst odszyfrowany</param>
        public static void isSame(string msg, string result)
        {
            if (msg.Equals(result))
                Console.WriteLine("The decrypted text is identical to plain text");
            else
                Console.WriteLine("Something is wrong! Decrypted textand plain text are not equal");
        }

        /// <summary>
        /// Metoda za szyfrowanie podanego ciągu znaków
        /// </summary>
        /// <param name="msg">Tekst zwykły</param>
        /// <param name="e">Wartość zmiennej e</param>
        /// <param name="n">Wartość zmiennej n</param>
        /// <returns></returns>
        public static List<BigInteger> encryptMessage(string msg, BigInteger e, BigInteger n)
        {
            Console.WriteLine("=== ENCRYPTION ===");
            //IEnumerable<string> listOfString = new List<string>();
            List<int> intList = new List<int>();
            List<BigInteger> encryptList = new List<BigInteger>();

            Console.WriteLine($"{msg} | Length: {msg.Length}");
            byte[] asciiBytes = Encoding.ASCII.GetBytes(msg);
            foreach (var element in asciiBytes)
            {
                intList.Add(element);
                Console.Write(element);
            }
            Console.Write($" | Length: {asciiBytes.Length}");
            Console.WriteLine();

            //IEnumerable<List<int>> listOfInt = new List<List<int>>();
            //listOfInt = SplitList(intList, (int)e - 1);

            foreach (var element in intList)
            {
                //foreach (var el in element)
                encryptList.Add(BigInteger.Pow(element, (int)e) % n);
            }
            for (int i = 0; i < encryptList.Count; i++)
                Console.WriteLine($"{i} | {encryptList[i]}");
            return encryptList;
        }


        /// <summary>
        /// Metoda odpowiedzialna za deszyfrowanie podanego ciągu
        /// </summary>
        /// <param name="encryptList">Zaszyfrowania wiadomość</param>
        /// <param name="d">Wartość zmiennej d</param>
        /// <param name="n">Wartość zmiennej n</param>
        /// <returns></returns>
        public static string decryptMessage(List<BigInteger> encryptList, BigInteger d, BigInteger n)
        {
            Console.WriteLine("=== DECRYPTION ===");
            var decryptList = new List<BigInteger>();
            var charList = new List<Char>();

            foreach (var element in encryptList)
                decryptList.Add(BigInteger.ModPow(element, (int)d, n));

            //IEnumerable<List<BigInteger>> listOfInt = SplitList(decryptList, 2);

            foreach (var element in decryptList)
                //foreach (var e in element)
                Console.WriteLine(element);

            foreach (var element in decryptList)
            {
                //foreach (var e in element)
                //{
                char r = (char)element;
                Console.Write(r);
                charList.Add(r);
                //}
            }
            Console.Write($" | Length: {charList.Count}");
            Console.WriteLine();

            return new string(charList.ToArray());
        }
    }
}
