using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Models.ViewModel
{
    public class PeopleViewModel
    {
        public string FilterText { get; set; }

        public List<Person> PersonList { get; set; }
    }
}
