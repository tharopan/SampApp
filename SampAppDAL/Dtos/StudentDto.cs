﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampAppDAL.Dtos
{
    public class StudentDto : Dto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public byte[] Picture { get; set; }
    }
}
