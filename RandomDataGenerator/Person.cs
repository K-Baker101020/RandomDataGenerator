namespace RandomDataGenerator
{
    internal class Person
    {
        private string[] _arrayOfFirstNames = new string[] {
                "Will", "Jake", "Bob", "Anthony", "Jack",
                "Veronica", "Nichole", "Jane", "Allison", "Katy"};
        private List<Dependent> _dependents = new List<Dependent>();

        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime BirthDate { get; init; }
        public SSN SSN { get; init; }
        public Phone Phone { get; init; }

        public Person()
        {
            Random rand = new Random();
            //Init the first name
            FirstName = _arrayOfFirstNames[rand.Next(_arrayOfFirstNames.Length)];

            //Init the last name
            var lastArray = Enum.GetValues(typeof(LastName));
            var value = (LastName)lastArray.GetValue(rand.Next(lastArray.Length));
            this.LastName = value.ToString();

            //Init the date of birth
            DateTime dateToday = DateTime.Now;
            
            int year = rand.Next(dateToday.Year - 81, dateToday.Year - 19);
            int month = rand.Next(1, 13);
            int day;

            if (month == 2)
            {
                bool leapYear = DateTime.IsLeapYear(year);

                if (leapYear)
                {
                    day = rand.Next(1, 30);
                }
                else
                {
                    day = rand.Next(1, 29);
                }
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                //Random 30 day months (April, June, September, November)
                day = rand.Next(1, 31);
            }
            else
            {
                //Random 31 day months
                day = rand.Next(1, 32);
            }

            BirthDate = new DateTime(year, month, day);

            //Init the SSN
            this.SSN = new SSN();

            //Init the phone number
            this.Phone = new Phone();
        }

        public int Age()
        {
            var age = DateTime.Now - BirthDate;
            return age.Days / 365;
        }

        public void AddDependent()
        {
            if (_dependents.Count > 10)
            {
                Console.WriteLine("No more dependents can be added for " + FirstName + " " + LastName); 
            }

            _dependents.Add(new Dependent());
        }

        public override string ToString()
        {
            string person = $"-----------------------------------------\n" +
                            $"First Name:\t\t{FirstName}\n" +
                            $"Last Name:\t\t{LastName}\n" +
                            $"Birth Date:\t\t{BirthDate.ToShortDateString()}\n" +
                            $"Age:\t\t\t{Age()}\n" +
                            $"SSN:\t\t\t{SSN}\n" +
                            $"PHone Number:\t\t{Phone.Number}\n" +
                            $"\n" +
                            $"Dependents: \n" +
                            $"----------\n";

            int count = 1;
            foreach (Dependent dep in _dependents)
            {
                person += $"Dependint " + count.ToString() + "\n" +
                          $"First Name:\t\t{FirstName}\n" +
                          $"Last Name:\t\t{LastName}\n" +
                          $"Birth Date:\t\t{BirthDate.ToShortDateString()}\n" +
                          $"Age:\t\t\t{Age()}\n" +
                          $"SSN:\t\t\t{SSN}\n" +
                          $"PHone Number:\t\t{Phone.Number}\n" +
                          $"\n";
            }
            return person;
        }
    }
}