using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBSGenerator
{
    class Tests
    {
        //ZLICZANIE LOGICZNYCH JEDYNEK
        public static long countBits(List<int> list)
        {
            var count = 0;
            foreach (var element in list)
                if (element == 1)
                    count++;
            return count;
        }

        //SINGLE BIT TEST
        public static void SBTest(List<int> list)
        {
            Tests test = new Tests();
            var x = Tests.countBits(list);
            if (list.Count == 0)
            {
                Console.WriteLine("Nie utworzono ciagu bitowego!");
            }
            else if (x > 9725 && x < 10275)
            {
                Console.WriteLine($"[Single Bit Test] Zakonczono sukcesem! [9725 < {x} < 10275]");
            }
            else
            {
                Console.WriteLine("[Single Bit Test] Nie spelniono warunku testu!");
            }
        }

        //LONG SERIES TEST
        public static void LongSeriesTest(List<int> list)
        {
            int count0 = 0, count1 = 1;
            var countList0 = new List<int>();
            var countList1 = new List<int>();
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == 0 && list[i + 1] == 0)
                {
                    if (i + 2 < list.Count)
                    {
                        count0++;
                        if (list[i + 2] == 1)
                        {
                            countList0.Add(count0);
                            count0 = 0;
                        }
                    }

                }
                else if (list[i] == 1 && list[i + 1] == 1)
                {
                    if (i + 2 < list.Count)
                    {
                        count1++;
                        if (list[i + 2] == 0)
                        {
                            countList1.Add(count1);
                            count1 = 0;
                        }
                    }

                }
            }

            bool dex0 = false, dex1 = false;
            foreach (var element in countList0)
                if (element >= 26)
                {
                    Console.WriteLine($"[Long Series Test] Nie spelniono warunku testu {element} >= 26");
                    dex0 = true;
                    break;
                }
            foreach (var element in countList1)
                if (element >= 26)
                {
                    Console.WriteLine($"[Long Series Test] Nie spelniono warunku testu {element} >= 26");
                    dex1 = true;
                    break;
                }
            if (dex0 == false || dex1 == false)
                Console.WriteLine("[Long Series Test] Zakonczono sukcesem!");
        }

        public static void LSTest(List<int> input)
        {
            int count = 0;
            int biggestSeries = 0;

            bool isOne;
            if (input[0] == 0)
                isOne = false;
            else
                isOne = true;
            for (int i = 0; i < input.Count; i++)
            {
                if (isOne == true && input[i] == 1)
                    count++;
                else if (isOne == true && input[i] == 0)
                {
                    if (count > biggestSeries)
                        biggestSeries = count;
                    isOne = false;
                    count = 0;
                }
                else if (isOne == false && input[i] == 1)
                {
                    if (count > biggestSeries)
                        biggestSeries = count;
                    isOne = true;
                    count = 0;
                }
                else if (isOne == false && input[i] == 0)
                    count++;
            }

            if (biggestSeries < 26)
                Console.WriteLine("[Long Series Test] Zakonczono sukcesem!");
            else
                Console.WriteLine($"[Long Series Test] Nie spelniono warunku testu!");
        }

        //SERIES TEST
        public static void SeriesTest(List<int> list)
        {
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int count5 = 0;
            int count6 = 0;

            int count = 0;
            bool isOne;
            if (list.First() == 0)
                isOne = false;
            else
                isOne = true;
            for (int i = 0; i < list.Count; i++)
            {

                if (isOne == true && list[i] == 1)
                    count++;
                else if (isOne == true && list[i] == 0)
                {
                    if (count == 1) count1++;
                    if (count == 2) count2++;
                    if (count == 3) count3++;
                    if (count == 4) count4++;
                    if (count == 5) count5++;
                    if (count >= 6) count6++;
                    isOne = false;
                    count = 0;
                }
                else if (isOne == false && list[i] == 1)
                {
                    if (count == 1) count1++;
                    if (count == 2) count2++;
                    if (count == 3) count3++;
                    if (count == 4) count4++;
                    if (count == 5) count5++;
                    if (count >= 6) count6++;
                    isOne = true;
                    count = 0;
                }
                else if (isOne == false && list[i] == 0)
                    count++;
            }

            //Console.WriteLine("Count1: {0}", count1);
            //Console.WriteLine("Count2: {0}", count2);
            //Console.WriteLine("Count3: {0}", count3);   WYSWIETLANIE KROKU
            //Console.WriteLine("Count4: {0}", count4);
            //Console.WriteLine("Count5: {0}", count5);
            //Console.WriteLine("Count6: {0}", count6);

            if (count1 >= 2315 && count1 <= 2685 &&
                count2 >= 1114 && count2 <= 1386 &&
                count3 >= 527 && count3 <= 723 &&
                count4 >= 240 && count4 <= 384 &&
                count5 >= 103 && count5 <= 209 &&
                count6 >= 103 && count6 <= 209)
                Console.WriteLine($"[Series Test] Zakonczono sukcesem!");
            else
                Console.WriteLine("[Series Test] Nie spelniono warunku testu!");

        }

        //DZIELENIE LIST NA TABLICE O 4 ELEMENTACH
        public static List<int[]> batcherOfList(List<int> list)
        {
            var dividedList = new List<int[]>();
            var temp = new int[4];
            for (int i = 0; i < list.Count / 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    temp[j] = list[4 * i + j];
                }
                dividedList.Add(new int[] { temp[0], temp[1], temp[2], temp[3] });
            }
            return dividedList;
        }

        //KONWERTOWANIE LICZB BINARNYCH NA DZIESIETNE
        public static List<int> convertHexToDec(List<int[]> list)
        {
            var decList = new List<int>();
            var xdec = 0;
            foreach (int[] element in list)
            {
                for (int i = 0; i < 4; i++)
                {
                    xdec = element[3] * 1 + element[2] * 2 + element[1] * 4 + element[0] * 8;
                }
                decList.Add(xdec);
            }
            return decList;
        }

        //PRZELICZANIE CIAGOW LICZB WEDLUG WZORU
        public static float calculatePoker(IOrderedEnumerable<KeyValuePair<int, int>> list)
        {
            float value = 0;
            var sum = 0;
            foreach (var element in list)
            {
                sum += (element.Value * element.Value);
                //Console.WriteLine($"Value: {element.Value}, suma: {sum}");  WYSWIETLANIE KROKU
            }
            value = sum * 16 / 5000 - 5000;
            return value;
        }

        //POKER TEST
        public static void PokerTest(List<int> list)
        {
            int nSize = 4;
            Tests test = new Tests();
            var dividedList = Tests.batcherOfList(list);
            //foreach (int[] element in dividedList)
            //{
            //    for (int i = 0; i < 4; i++) //WYSWIETLANIE KROKU
            //    {
            //        Console.Write($"{element[i]}");
            //    }
            //    Console.WriteLine();
            //}
            var decimalList = Tests.convertHexToDec(dividedList);
            //foreach (var element in decimalList)
            //    Console.Write($" {element} "); //WYSWIETLANIE KROKU
            //Console.WriteLine();

            var frequency = decimalList.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var sortedFrequency = from entry in frequency orderby entry.Key ascending select entry;
            //foreach (var element in sortedFrequency)
            //    Console.WriteLine($" {element.Key} | {element.Value} ");

            var result = Tests.calculatePoker(sortedFrequency);
            if (result > 2.16 && result < 46.17)
                Console.WriteLine($"[Poker Test] Zakonczono sukcesem! [2,16 < {result} < 46,17]");
            else
                Console.WriteLine($"[Poker Test] ]Nie spelniono wymagan testu! [ {result} ]");
        }
    }
}
