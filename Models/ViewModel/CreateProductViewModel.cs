﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
   public class CreateProductViewModel
    {
        public IEnumerable<Group> groups { get; set; }
        public Product product { get; set; }
    }
}
