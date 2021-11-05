﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarafonSKills.Model;

namespace MarafonSKills.Model
{
    public partial class Runner
    {
        public byte[] image
        {
            get
            {
                byte[] photo = File.ReadAllBytes($"{Photo}");
                return photo;
            }
        } 
    }
}
