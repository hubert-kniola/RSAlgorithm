using BBSGenerator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace RSACalculate
{
    public class RSA
    {
        public static void RSAalgorithm()
        {
            #region Generating
            var plainText = RSACrypto.generateMessage(50);  
            Console.WriteLine($"PlainText: {plainText} | Length: {plainText.Length}");

            Stopwatch sw = Stopwatch.StartNew();

            sw.Start();
            var p = RSACalculations.randomInteger();
            Thread.Sleep(100);
            var q = RSACalculations.randomInteger();
            sw.Stop();
            Console.WriteLine($"Value of p: {p}, q: {q} | Generation time [ms]: {sw.Elapsed}");

            sw.Start();
            var n = RSACalculations.nAndPhiGenerator("n", p, q);
            sw.Stop();
            Console.WriteLine($"Value of n: {n} | Generation time [ms]: {sw.Elapsed}");

            sw.Start();
            var phi = RSACalculations.nAndPhiGenerator("phi", p, q);
            sw.Stop();
            Console.WriteLine($"Value of phi: {phi} | Generation time [ms]: {sw.Elapsed}");

            sw.Start();
            var e = RSACalculations.eGenerator(phi);
            sw.Stop();
            Console.WriteLine($"Public key: {e} | Generation time [ms]: {sw.Elapsed}");

            sw.Start();
            var d = RSACalculations.dGenerator(e, phi);
            sw.Stop();
            Console.WriteLine($"Private key: {d} | Generation time [ms]: {sw.Elapsed}");
            #endregion

            var encryptList = RSACrypto.encryptMessage(plainText,e, n);

            Console.WriteLine("=== TESTS ===");
            BlumBlumShub.N = phi;
            BlumBlumShub.generatorBBS();

            var decryptText = RSACrypto.decryptMessage(encryptList, d, n);

            Console.WriteLine(plainText);
            RSACrypto.isSame(plainText, decryptText);
        }
    }
}
