using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPerson.Models.Repos
    {
        public class InMemoryPeopleRepo : IPeopleRepo
        {
            private static List<Person> peopleList = new List<Person>();
            private static int idCounter = 0;
            public Person Create(Person person)
            {
              //  Person person = new Person(name,phonenumber,cityname);

               person.PersonId = ++idCounter;
               // person.Name = name;
               // person.PhoneNumber = phonenumber;
              //  person.CityName = cityname;
                peopleList.Add(person);
                return person;
            }

            public List<Person> GetAll()
            {
                return peopleList;
            }

            public Person GetById(int id)
            {
            Person person = null;
            
                foreach (Person aPerson in peopleList)
                {
                    if (aPerson.PersonId == id)
                    {
                        return aPerson;
                        break;
                    }
                }
                return person;
            }
        public List<Person> GetByCity(string City)
        {
            throw new NotImplementedException();
        }

        public bool Update(Person person)
            {
                Person orgPerson = GetById(person.PersonId);
                if (orgPerson == null)
                {
                   return false;
                }
                else
                {
                    orgPerson.Name = person.Name;
                    orgPerson.CityName = person.CityName;
                    orgPerson.PhoneNumber = person.PhoneNumber;
                    return true;
                }
            }
            public void Delete(Person person)
            {
                peopleList.Remove(person);
            }

       
    }
}
