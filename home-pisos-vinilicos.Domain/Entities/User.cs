using System;
using System.Collections.Generic;
using System.Text;

namespace home_pisos_vinilicos.Domain.Entities
{
    public class User
    {
        public string Iduser { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public bool status { get; set; }
    }
}
