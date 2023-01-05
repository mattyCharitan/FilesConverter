
using FilesConverter;

List<Person> people = new List<Person>();

// Read the people from the text file

Factory factory = new Factory();
people.Add(factory.ReadFromFile("\"C:\\Users\\מטי\\source\\repos\\FilesConverter\\FilesConverter\\MattyObj.txt\""));
factory.printPeople(people);

