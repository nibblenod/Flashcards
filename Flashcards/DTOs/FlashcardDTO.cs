﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.DTOs
{
    internal class FlashcardDTO
    {
        public int ID { get; set; }
        public string Front { get; set; }
        public string Back { get; set; }
    }
}
