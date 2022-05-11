using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public class Human
    {
        public string Photo { get; set; }
        public string Name { get; set; }
        public string Surame { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
        public List<string> Phones { get; set; }
    }
}
