﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Models
{
    internal class StackModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StackModel() { } //for dapper
    }
}
