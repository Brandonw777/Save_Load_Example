using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Save_Load_Example
{
    class Program
    {
        static void Main()
        {
            string filename;

            Console.Write("Enter your name");
            string name = Console.ReadLine();
            Person p = new Person(name);
            
            Console.Write("Enter a filename for saving:");
            filename = Console.ReadLine();
            savePerson(p,filename);
            Console.ReadKey();
            
            Console.Write("Enter a filename for loading:");
            filename = Console.ReadLine();
            p = loadPerson(p, filename);
            Console.ReadKey();
            Console.Write(p.Name);
            Console.ReadKey();

        }
        public static void savePerson(Person p, string filename = "test.dat")
        {
            //Create the stream and and the file object to it
            System.IO.Stream fs = File.OpenWrite(filename);

            //The object that will format our data to binary while streaming
            BinaryFormatter formatter = new BinaryFormatter();

            //Serialize the data
            formatter.Serialize(fs, p);

            fs.Flush();
            fs.Close();
            fs.Dispose();
        }

        public static Person loadPerson(Person p, string filename = "test.dat")
        {
            //Create the stream and and the file object to it
            System.IO.Stream fs = File.Open(filename, FileMode.Open);

            //The object that will format our data to binary while streaming
            BinaryFormatter formatter = new BinaryFormatter();

            //Serialize the data
            Object obj = formatter.Deserialize(fs);
            p = (Person)obj; //cast the object as our person class before returning

            fs.Flush();
            fs.Close();
            fs.Dispose();

            return p;
        }
    }

    [Serializable]
    class Person
    {
        public string Name { get; set; }

        public Person(string n)
        {
            Name = n;
        }
    }
}