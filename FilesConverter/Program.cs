
using FilesConverter;





Factory factory = new Factory();
List<Person> generatedList = factory.createPeopleList();

// Write the people to the JSON file

string jsonPath = @"C:\Users\Public\Documents\people.json";
Console.WriteLine($"Writing people to JSON file: {factory.WriteToFile(generatedList, jsonPath)}");
//Read the people from the JSON file
List<Person> jsonPeople = factory.ReadFromFile(jsonPath);
factory.printPeople(jsonPeople);

// Write the people to the XML file
string xmlPath =   @"C:\Users\Public\Documents\people.xml";
Console.WriteLine($"Writing people to XML file: {factory.WriteToFile(generatedList, xmlPath)}");
//Read the people from the XML file

List<Person> xmlPeople = factory.ReadFromFile(xmlPath);
factory.printPeople(xmlPeople);