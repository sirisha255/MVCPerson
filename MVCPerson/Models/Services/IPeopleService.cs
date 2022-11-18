using MVCPerson.Models.ViewModels;

namespace MVCPerson.Models.Services
{
    public interface IPeopleService 
    {
        Person Add(CreatePersonViewModel createPerson);
        List<Person> All();
        List<Person> Search(string search);
        Person FindById(int id);
        bool Edit(int id, CreatePersonViewModel editPerson);

        bool Remove(int id);
    }
}
