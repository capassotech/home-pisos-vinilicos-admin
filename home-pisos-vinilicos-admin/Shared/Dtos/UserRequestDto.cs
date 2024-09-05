using System;
using System.Collections.Generic;
using System.Text;

namespace home_pisos_vinilicos_admin.Shared.Dtos
{
    public class UserRequestDto
    {
        public string Iduser { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}