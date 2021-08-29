using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MobilePhone { get; set; }

        public string City { get; set; }
    }
}
