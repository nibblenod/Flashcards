using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flashcards.Models;

namespace Flashcards.DTOs
{
    internal static class DTOMapper
    {
        internal static StackDTO toStackDTO(Stack stack)
            => new StackDTO { Name = stack.Name };
       
        
    }
}
