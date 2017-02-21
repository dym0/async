using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace async
{
    public class Program
    {
        

        public static void Main(string[] args)
        {

            string input = "";
            CreateIfNotExist();
            do
            {
                input = Console.ReadLine();

                if(input == "read")
                {
                    Display();
                }


            }
            while(input != "exit"
            );


        }

        public async static void CreateIfNotExist()
        {
            FileInfo file = new FileInfo("D://async.txt");

      
                using (Stream stream = new  FileStream("D://async.txt", FileMode.Create))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                 await  writer.WriteLineAsync("async async async ");
                 await  writer.WriteLineAsync("async async async ");
                 await  writer.WriteLineAsync("async async async ");

                }
               
          

        }



        public static string ReadContent()
        {


            string content;
            using (Stream stream = new FileStream("D:/async.txt", FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                System.Threading.Thread.Sleep(10000);
                content = reader.ReadToEnd();

            }

            return content;
        }

        public async static void Display()
        {
            Task<string> task = new Task<string>(ReadContent);
            
            task.Start();

            Console.Clear();

            while(!task.IsCompleted)
                {

                Console.Write("Please wait, loading text");
                for (int i = 0; i < 4; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
                Console.Clear();
               
            } 

            if(task.IsCompleted)
            {
                Console.Clear();
                Console.WriteLine("Loading Text completed");
            }

        
            string text = await task;

            Console.WriteLine(text);

        }
    }
}
