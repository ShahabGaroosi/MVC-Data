using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Models.Repo
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> _personList = new List<Person>();
        private static int idCounter = 0;

        public Person Create(string name, string mobilePhone, string city)
        {
            Person person = new Person();
            person.Name = name;
            person.MobilePhone = mobilePhone;
            person.City = city;
            person.Id = idCounter++;
            _personList.Add(person);
            return person;
        }

        public bool Delete(Person person)
        {
            _personList.Remove(person);
            return true;
        }

        public List<Person> Read()
        {
            return _personList;
        }

        public Person Read(int id)
        {
            foreach (Person person in _personList)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }
            return null;
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
