﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klimalauf
{
    public class Schule
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Klasse> Klassen { get; set; }


        public Schule()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
