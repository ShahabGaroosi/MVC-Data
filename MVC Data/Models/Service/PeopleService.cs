using MVC_Data.Models.Repo;
using MVC_Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Models.Service
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public Person Add(CreatePersonViewModel createPerson)
        {
            Person person = new Person();

            if (!createPerson.CheckExists(_peopleRepo, createPerson.Name, createPerson.MobilePhone, createPerson.City))
            {
                person = _peopleRepo.Create(createPerson.Name, createPerson.MobilePhone, createPerson.City);
            }

            return person;
        }

        public PeopleViewModel All()
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.PersonList = _peopleRepo.Read();
            return peopleViewModel;
        }

        public Person Edit(int id, Person person)
        {
            throw new NotImplementedException();
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.PersonList = new List<Person>();

            if (search.FilterText == null)
            {
                return All();
            }
            foreach (Person person in _peopleRepo.Read())
            {
                if ((person.Name.Contains(search.FilterText, StringComparison.OrdinalIgnoreCase)) || (person.MobilePhone.Contains(search.FilterText, StringComparison.OrdinalIgnoreCase)) || (person.City.Contains(search.FilterText, StringComparison.OrdinalIgnoreCase)))
                {
                    peopleViewModel.PersonList.Add(person);
                }
            }
            return peopleViewModel;
        }

        public Person FindBy(int id)
        {
            foreach (Person person in _peopleRepo.Read())
            {
                if (person.Id == id)
                {
                    return person;
                }
            }
            return null;
        }

        public bool Remove(int id)
        {
            foreach (Person person in _peopleRepo.Read())
            {
                if (person.Id == id)
                {
                    return _peopleRepo.Delete(person);
                }
            }
            return false;
        }
    }
}
