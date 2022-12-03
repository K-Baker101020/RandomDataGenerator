using RandomDataGenerator;
public class Program
{
    static List<Person> people = new List<Person>();

    public static void Main(string[] args)
    {
        var option = 0;
        var invalidEntry = false;
        do
        {
            DisplayMenu();
            try
            {
                option = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                //Catch an invalid non-numeric key stroke
                invalidEntry = true;
                Console.WriteLine("You have entered an invalid entry.");
            }

            if (!invalidEntry)
            {
                MenuChoice(option);
            }
            else
            {
                //Assign an arbitrary unused value to stay in the do/while loop
                option = 7;
            }

            Console.WriteLine("\nHit Enter to return to menu...");
            Console.ReadLine();
            Console.Clear();
            invalidEntry = false;
        } while (option != 0);
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("------ Menu ------");
        Console.WriteLine("1. Create a new Person");
        Console.WriteLine("2. View all people");
        Console.WriteLine("3. Remove a person");
        Console.WriteLine("4. Display a random last name");
        Console.WriteLine("5. Get and display a random SSN");
        Console.WriteLine("6. Get and display a random phone number");
        Console.WriteLine("0. Exit");
        Console.WriteLine("------------------");
    }

    private static void MenuChoice(int option)
    {
        Random random = new Random();
        switch (option)
        {
            case 1:
                people.Add(new Person());
                break;
            case 2:
                if (people.Count == 0)
                {
                    //If no objects are present in the list, create a default Person object 
                    people.Add(new Person());
                }
                foreach (Person p in people)
                {
                    //Write each Person object to string on the console
                    Console.WriteLine(p.ToString());
                }
                break;
            case 3:
                if (people.Count == 0)
                {
                    Console.WriteLine("There are no people to remove.");
                }
                else
                {
                    int count = 1;
                    Console.WriteLine("");
                    Console.WriteLine("Please select the entry from the list to remove: ");
                    Console.WriteLine("");

                    foreach (Person p in people)
                    {
                        //Display each person in the list
                        Console.WriteLine(count + $".\t" + p.FirstName + " " + p.LastName + $"\n");
                        count++;
                    }
                    Console.WriteLine("");

                    var selection = Int32.Parse(Console.ReadLine());

                    if (selection < 0 || selection > people.Count)
                    {
                        Console.WriteLine("You have entered an invalid entry.");
                    }
                    else
                    {
                        //Get the person's name, remembering it is in a 0 indexed list
                        string name = people[selection - 1].FirstName + " " + people[selection - 1].LastName;

                        //Remove the selected entry
                        people.RemoveAt(selection);

                        //Indicate that the entry has been removed
                        Console.WriteLine("");
                        Console.WriteLine("Congratulations! You have removed " + name + " from existence!");
                    }
                }
                break;
            case 4:
                //Get a random last name and write it to the console
                Random rand = new Random();
                var lastArray = Enum.GetValues(typeof(LastName));
                var value = (LastName)lastArray.GetValue(rand.Next(lastArray.Length));
                Console.WriteLine("Here is a random last name for you: " + value.ToString());
                break;
            case 5:
                SSN ssn = new SSN();
                Console.WriteLine("Here is a random social security number (SSN): " + ssn.Number);
                break;
            case 6:
                Console.WriteLine("");
                Console.WriteLine("Please specify separator to use for a random phone number: ");
                Console.WriteLine("");
                
                var key = Console.ReadKey();

                Console.WriteLine("");
                Console.WriteLine("You have specified '" + key.KeyChar.ToString() + "' as the separator.");

                Phone randNumb = new Phone(key.KeyChar);

                Console.WriteLine("Here is your random phone number with your custom separator: " + randNumb.Number);
                break;
            case 0:
                Console.WriteLine("See ya!");
                break;
            default:
                Console.WriteLine("Invalid option. Can you read?");
                break;
        }
    }
}




























