using Flashcards.Models;

namespace Flashcards.DTOs
{
    internal static class DTOMapper
    {
        internal static StackDTO toStackDTO(StackModel stack)
            => new StackDTO { Name = stack.Name };



    }
}
