namespace RandomDataGenerator
{
    internal class Dependent : Person
    {
        public Dependent()
        {
            Random rand = new Random();
            DateTime dateToday = DateTime.Now;

            int year = rand.Next(dateToday.Year, dateToday.Year + 11);
            int month = rand.Next(1, 13);
            int day = rand.Next(1, 32);

            BirthDate = new DateTime(year, month, day);
        }
    }
}