namespace MVCPerson.Models
{
    public class Person
    {
        public Person(string name, string phonenumber, string cityname)
        {
            Name = name;
            PhoneNumber = phonenumber;
            CityName = cityname;
        }

        public Person()
        {

        }
        public int PersonId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CityName { get; set; }


    }
}
