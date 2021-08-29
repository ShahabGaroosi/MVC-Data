using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Data.Models.Repo;

namespace MVC_Data.Models.ViewModel
{
    public class CreatePersonViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string City { get; set; }

        public bool CheckExists(IPeopleRepo InMemoryPeopleRepo, string name, string mobilePhone, string city)
        {
            foreach (Person person in InMemoryPeopleRepo.Read())
            {
                if ((person.Name == name) & (person.MobilePhone == mobilePhone) & (person.City == city))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
