using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assignment
{
    public class Importer
    {
        private string _filepath { get; set; }
        private static object locker = new Object();

        public Importer()
        {
            // file name can be configure through Config Manager
            this._filepath = "Data.json";
        }

        public void WriteToFile(string text)
        {
            lock (locker)
            {
                using (FileStream file = new FileStream(_filepath, FileMode.Append, FileAccess.Write, FileShare.Read))
                {
                    using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
                    {
                        writer.Write(text);
                    }
                }
                Console.WriteLine("Writer completed its task, releasing lock.");
            }
        }
    }
}
