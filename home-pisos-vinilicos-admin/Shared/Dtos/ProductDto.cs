﻿using System;
using System.Collections.Generic;
using System.Text;

namespace home_pisos_vinilicos_admin.Shared.Dtos
{
    public class ProductDto
    {
        public string IdProduct { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public String Description { get; set; }
        public decimal Size { get; set; }
        public String Color { get; set; }
        public int Quantity { get; set; }
        //public Category category { get; set; }
    }
}
