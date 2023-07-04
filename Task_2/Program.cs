using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2
{

    public struct FileNames
    {
        public string NameFilIn { get; set; }
        public string NameFilOu { get; set; }

        public FileNames(string nameFilIn, string nameFilOu)
        {
            NameFilIn = nameFilIn;
            NameFilOu = nameFilOu;
        }

    }


    internal class Program
    {

        public static object ob = new object();

        public static void CotiFile(object fileNames)
        {
            FileNames name = (FileNames)fileNames;

            using StreamReader reader = new StreamReader(name.NameFilIn);
            string temp = reader.ReadToEnd();
            Console.WriteLine(temp);


            //Monitor.Enter(ob);

            using StreamWriter writer = File.AppendText(name.NameFilOu);
            writer.WriteLine(temp);

            //Monitor.Exit(ob);
        }

        static void Main()
        {

            FileNames fileNames1 = new FileNames("FilIn1.txt", "Res.txt");
            FileNames fileNames2 = new FileNames("FilIn2.txt", "Res.txt");

            Thread thread = new Thread(CotiFile);
            Thread thread2 = new Thread(CotiFile);
            thread.Start(fileNames1);

            //thread.Join(); Если нужно прям вызов по порядкуж
            thread2.Start(fileNames2);



            Console.ReadKey();
        }
    }
}
