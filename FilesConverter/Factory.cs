using Newtonsoft.Json;
using System.Xml.Serialization;


namespace FilesConverter

{
    public class Factory
    {
        public List<Person> createPeopleList()
        {
            List<Person> people = new List<Person>
{
    new Person
    {
        FirstName = "John",
        LastName = "Doe",
        Age = 30,
        Gender = Gender.Male,
        Address = new Address
        {
            Street = "123 Main St",
            City = "New York"
        }
    },
    new Person
    {
        FirstName = "Jane",
        LastName = "Doe",
        Age = 25,
        Gender = Gender.Female,
        Address = new Address
        {
            Street = "456 Main St",
            City = "New York"
        }
    },
    new Person
    {
        FirstName = "Bob",
        LastName = "Smith",
        Age = 35,
        Gender = Gender.Male,
        Address = new Address
        {
            Street = "789 Main St",
            City = "Chicago"
        }
    },
    new Person
    {
        FirstName = "Alice",
        LastName = "Smith",
        Age = 40,
        Gender = Gender.Female,
        Address = new Address
        {
            Street = "321 Main St",
            City = "Chicago"
        }
    },
    new Person
    {
        FirstName = "Eve",
        LastName = "Jackson",
        Age = 45,
        Gender = Gender.Female,
        Address = new Address
        {
            Street = "654 Main St",
            City = "Los Angeles"
        }
    }
};
            return people;

        }
        public List<Person> ReadFromFile(string filePath)
        {
            List<Person> people = new List<Person>();

            if (Path.GetExtension(filePath) == ".xml")
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
                using (FileStream stream = File.OpenRead(filePath))
                {
                    people = (List<Person>)serializer.Deserialize(stream);
                }
            }
            else if (Path.GetExtension(filePath) == ".json")
            {
                string json = File.ReadAllText(filePath);
                people = JsonConvert.DeserializeObject<List<Person>>(json);
            }
           /* else if (Path.GetExtension(filePath) == ".xlsx")
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Workbooks.Open(filePath);
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                Excel.Range range = worksheet.UsedRange;
                for (int i = 2; i <= range.Rows.Count; i++)
                {
                    string firstName = (string)(range.Cells[i, 1] as Excel.Range).Value2;
                    string lastName = (string)(range.Cells[i, 2] as Excel.Range).Value2;
                    int age = (int)(range.Cells[i, 3] as Excel.Range).Value2;
                    Gender gender = (Gender)Enum.Parse(typeof(Gender), (string)(range.Cells[i, 4] as Excel.Range).Value2);
                    Address address = new Address
                    {
                        Street = (string)(range.Cells[i, 5] as Excel.Range).Value2,
                        City = (string)(range.Cells[i, 6] as Excel.Range).Value2
                    };

                    Person person = new Person
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        Gender = gender,
                        Address = address
                    };
                    people.Add(person);
                }

                workbook.Close();
                excel.Quit();
            }
           */

            else
            {
                throw new Exception("The file is not valid.");
            }

            return people;
        }


        public Boolean WriteToFile(List<Person> people, string filePath)
        {

            if (Path.GetExtension(filePath) == ".xml")
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
                using (FileStream stream = File.Create(filePath))
                {
                    serializer.Serialize(stream, people);
                }
                return true;
            }
            else if (Path.GetExtension(filePath) == ".json")
            {
                string json = JsonConvert.SerializeObject(people);
                File.WriteAllText(filePath, json);
                return true;
            }
          /*  else if (Path.GetExtension(filePath) == ".xlsx")
            {
                Excel.Application excel = new Excel.Application();
                excel.Workbooks.Add();
                Excel.Worksheet worksheet = excel.ActiveSheet;
                worksheet.Cells[1, 1] = "First Name";
                worksheet.Cells[1, 2] = "Last Name";
                worksheet.Cells[1, 3] = "Age";
                worksheet.Cells[1, 4] = "Gender";
                worksheet.Cells[1, 5] = "Street";
                worksheet.Cells[1, 6] = "City";
                for (int i = 0; i < people.Count; i++)
                {
                    worksheet.Cells[i + 2, 1] = people[i].FirstName;
                    worksheet.Cells[i + 2, 2] = people[i].LastName;
                    worksheet.Cells[i + 2, 3] = people[i].Age;
                    worksheet.Cells[i + 2, 4] = people[i].Gender;
                    worksheet.Cells[i + 2, 5] = people[i].Address.Street;
                    worksheet.Cells[i + 2, 6] = people[i].Address.City;
                }
  
                excel.ActiveWorkbook.SaveAs(filePath);
               
                excel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                excel = null;
                return true;

            }*/
            else
            {
                return false;
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
                Address a = person.Address;
                a.printAddress();

            }
        }


    }
}

   

