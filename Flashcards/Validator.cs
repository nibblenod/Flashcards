using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flashcards.DTOs;

namespace Flashcards
{
    internal class Validator
    {
        internal static bool StackValidator(string name, List<StackDTO> stacks)
        {
            if (stacks.Exists(stack => stack.Name == name))
            {
                return true;
            }
            return false;
        }
    }
}
