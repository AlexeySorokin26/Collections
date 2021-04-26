namespace Collections
{
   
    using System.Collections.Generic;
    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    using System.Linq;


    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            LinkedList<string> ll = new LinkedList<string>();
            List<string> list = new List<string>();
            Stopwatch timer = new Stopwatch();
            
            string filePath = "Text1.txt";
            if (File.Exists(filePath)) {

                // 1 task 
                StreamReader sr = File.OpenText(filePath);
                string str = "";
                timer.Start();
                while ((str = sr.ReadLine()) != null)
                    ll.AddLast(str);
                timer.Stop();
                Console.WriteLine(ll.Count);
                Console.WriteLine(timer.ElapsedMilliseconds);

                sr.DiscardBufferedData();
                sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                timer.Restart();
                while ((str = sr.ReadLine()) != null)
                    list.Add(str);
                timer.Stop();
                Console.WriteLine(list.Count);
                Console.WriteLine(timer.ElapsedMilliseconds);

                // 2 task 
                Dictionary<string, int> wordsUnique = new Dictionary<string, int>();
                foreach(string el in list)
                {
                    string[] words = el.Split(' ');
                    foreach(string w in words)
                    {
                        string clearWord = Regex.Replace(w, @"[^\w\d\s]", "");
                        if (wordsUnique.ContainsKey(clearWord))
                        {
                            wordsUnique[clearWord] += 1;
                        }
                        else
                        {
                            wordsUnique.Add(clearWord, 1);
                        }
                    }
                }

                var sortedUniqueWords = wordsUnique.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                string blank = "";
                sortedUniqueWords.Remove(blank);
                int counter = 0;
                foreach (var w in sortedUniqueWords)
                {
                    if (counter < 10)
                        Console.WriteLine(w.Key + " - " + w.Value);
                    else
                        break;
                    counter++;
                }
                    

                Console.ReadLine();
            }



        }
    }
}
