﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities
{
    public class Author : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
