using System;

namespace OOPProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = ReadFile("values.csv");
            List<Person> people = new List<Person>();

            people = GetPeople(file);
            PrintPeople(people);

        }
        
        static string[] ReadFile(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            return lines;
        }

        static List<Person> GetPeople(string[] file)
        {
            Dictionary<int, List<string>> file_items = new Dictionary<int, List<string>>();
            List<Person> people = new List<Person>();

            // get items from file 
            for (int i = 0; i < file.Length; i++) file_items.Add(i, GetItems(file[i]));

            // create person objects
            for (int i = 1; i < file.Length; i++)
            {
                Person p;
                string firstname = "", lastname = "", occupation ="";
                int age = 0;

                for (int j = 0; j < file_items[0].Count(); j++)
                {

                    // check what value we are on
                    switch(file_items[0][j].ToLower())
                    {
                        case "firstname":
                            firstname = file_items[i][j];
                            break;
                        case "lastname":
                            lastname = file_items[i][j];
                            break;
                        case "occupation":
                            occupation = file_items[i][j];
                            break;
                        case "age":
                            age = int.Parse(file_items[i][j]);
                            break;
                        default:
                            Console.WriteLine($"Header '{file_items[0][j]}' is not a valid header");
                            break;
                    }
                }

                p = new Person(firstname, lastname, occupation, age);
                people.Add(p);
            }

            // return new instance of people
            return new List<Person>(people);
        } 
         
        static  List<string> GetItems(string line)
        {
            string current_word = "";
            List<string> items = new List<string>();

            // split line
            foreach (char c in line)
            {
                if (c == ',')
                {
                    if (current_word != "")
                    {
                        items.Add(current_word);
                        current_word = "";
                    }
                }
                else
                {
                    current_word += c.ToString();
                }
            }

            // add left over iten if exists
            if (current_word != "") items.Add(current_word);

            // return new instance of item
            return new List<string>(items);
        }

        // Print information about every person in people
        static void PrintPeople(List<Person> people)
        {
            foreach (Person p in people)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName} is {p.Age.ToString()} years old and works as a(n) {p.Occupation}.");
            }
        }
    }
}