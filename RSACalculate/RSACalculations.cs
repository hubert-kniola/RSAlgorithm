using System;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;

namespace RSACalculate
{
    public class RSACalculations
    {
        private static Random _rnx;

        public static BigInteger randomInteger()
        {
            BigInteger x = 0;
            do
            {
                x = randomNumber(100, 10000);
            } while (!checkIfPrime(x));
            return x;
        }

        public static BigInteger randomNumber(int min, int max)
        {
            _rnx = new Random();
            return _rnx.Next(min, max);
        }

        public static bool checkIfPrime(BigInteger n)
        {
            var isPrime = true;
            var sqrt = Math.Sqrt((int)n);
            for (var i = 2; i <= sqrt; i++)
                if ((n % i) == 0) isPrime = false;
            return isPrime;
        }

        public static BigInteger nAndPhiGenerator(String type, BigInteger p, BigInteger q)
        {
            if (type == "phi") return (p - 1) * (q - 1);
            else if (type == "n") return p * q;
            else return -1;
        }

        public static BigInteger eGenerator(BigInteger phi)
        {
            BigInteger e = 0;
            do
            {
                e = generatePrime(10);
            } while (!isPrime(e) && !(BigInteger.GreatestCommonDivisor(e, phi) == 1));
            return e;
        }

        public static BigInteger dGenerator(BigInteger e, BigInteger phi)
        {
            for(var i=0; i<phi*2; i++)
            {
                if ((e * i - 1) % phi == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool isPrime(BigInteger n)
        {
            var sqrt = Math.Sqrt((int)n);
            if (n <= 0) throw new IOException();
            if (n == 1 || n == 2) return true;
            if (n % 2 == 0) return false;
            for (var i = 3; i <= sqrt; i++)
            {
                if (BigInteger.GreatestCommonDivisor(i, n) == i)
                    return false;
            }
            return true;
        }

        public static BigInteger generatePrime(BigInteger min)
        {
            BigInteger primeNumber = 0;
            BigInteger temp;

            if (min % 2 == 0)
                temp = min + 1;
            else
                temp = min;
            bool flag = true;
            do
            {
                if (isPrime(temp) == true)
                    primeNumber = temp;
                else
                {
                    temp += 2;
                }
            } while (primeNumber == 0);
            return primeNumber;
        }
    }
}
