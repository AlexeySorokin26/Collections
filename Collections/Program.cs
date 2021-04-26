namespace Collections
{
   
    using System.Collections.Generic;
    using System;
    using System.IO;
    using System.Diagnostics;



    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> ll = new LinkedList<string>();
            List<string> l = new List<string>();
            Stopwatch timer = new Stopwatch();
            
            
            
            string filePath = "Text1.txt";
            if (File.Exists(filePath)) {
                StreamReader sr = File.OpenText(filePath);
                string str = "";
                timer.Start();
                while ((str = sr.ReadLine()) != null)
                    ll.AddLast(str);
                timer.Stop();
                Console.WriteLine(ll.Count);
                Console.WriteLine(timer.ElapsedMilliseconds);

                str = "";
                sr.DiscardBufferedData();
                sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                timer.Restart();
                while ((str = sr.ReadLine()) != null)
                    l.Add(str);
                timer.Stop();
                Console.WriteLine(l.Count);
                Console.WriteLine(timer.ElapsedMilliseconds);
            }
        }
    }
}
