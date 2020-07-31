using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PacketTrigger
{
    public class AllowList
    {
        List<string> list = new List<string> { "127.0.0.1" };

        public List<string> List 
        { 
            get { return list; }
            set { list = value; }
        }

        public void Serialize(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                foreach(var item in list)
                {
                    writer.WriteLine(item);
                }
                writer.Close();
            }
        }

        public void Deserialize(string path)
        {
            var l = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
                {
                    while (reader.Peek() != -1)
                    {
                        string line = reader.ReadLine();
                        //Console.WriteLine(line);
                        l.Add(line);
                    }
                    reader.Close();
                }

                list = l;
            }
            catch
            {
                Serialize(path);
            }
        }
    }
}
