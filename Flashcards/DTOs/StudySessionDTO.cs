﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.DTOs
{
    internal class StudySessionDTO
    {
        public int ID { get; set; }
        public DateTime SessionDate { get; set; }
        public string? StackName { get; set; }
        public int Score { get; set; }
    }
}
