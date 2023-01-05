using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FilesConverter
{
    public class Factory
    {
        public Person ReadFromFile(string filePath)
        {
            Person person = new Person();

            if (Path.GetExtension(filePath) == ".txt")
            {
                string[] lines = File.ReadAllLines(filePath);
                person.FirstName = lines[0];
                person.LastName = lines[1];
                person.Age = int.Parse(lines[2]);
                person.Gender = (Gender)Enum.Parse(typeof(Gender), lines[3]);
                person.Address = new Address
                {
                    Street = lines[4],
                    City = lines[5],
                };
            }

            else if (Path.GetExtension(filePath) == ".xml")
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Person));
                using (FileStream stream = File.OpenRead(filePath))
                {
                    person = (Person)serializer.Deserialize(stream);
                }

            }

            else if (Path.GetExtension(filePath) == ".json")
            {
                string json = File.ReadAllText(filePath);
                person = JsonConvert.DeserializeObject<Person>(json);
            }

            


                return person;
        }

        public void WriteToFile(List<Person> people, string format, string filePath)
        {
            if (format == "txt")
            {
                // Write the list of people to a text file
            }
            else if (format == "xml")
            {
                // Write the list of people to an XML file
            }
            else if (format == "json")
            {
                // Write the list of people to a JSON file
            }
            else if (format == "excel" || format == "csv")
            {
                // Write the list of people to an Excel or CSV file
            }
            else
            {
                throw new ArgumentException("Invalid file format.");
            }
        }
        public void printPeople(List<Person> people)
        {
            foreach (Person person in people)
            {
                Console.WriteLine(person.FirstName);
                Console.WriteLine(person.LastName);
                Console.WriteLine(person.Age);
                Console.WriteLine(person.Gender);
               // person.Address.printAddress();
            }
        }


    }
}

   

