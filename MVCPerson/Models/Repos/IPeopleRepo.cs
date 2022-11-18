namespace MVCPerson.Models.Repos
{
    public interface IPeopleRepo
    {

        //C Create
        public Person Create(string name, string phonenumber, string city);

        //R Read the People List
        public List<Person> Read();
        public Person Read(int id);
        //U Update the People List
        public bool Update(Person person);

        //D Delete a Person from the List
        public bool Delete(Person person);
    }
}
