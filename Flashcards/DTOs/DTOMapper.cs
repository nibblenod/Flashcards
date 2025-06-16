using System.Globalization;
using Flashcards.Models;

namespace Flashcards.DTOs
{
    internal static class DTOMapper
    {
        private static Dictionary<int, int> _FlashcardIDMap = new Dictionary<int, int>();
        private static Dictionary<int, int> _StackIDMap = new Dictionary<int, int>();

        public static Dictionary<int, int> FlashcardIDMap
        {
            get { return _FlashcardIDMap; }
        }
        public static Dictionary<int, int> StackIDMap
        {
            get { return _StackIDMap; }
        }
        internal static StackDTO toStackDTO(StackModel stack, int dtoID)
        {
            int originalID = stack.Id;

            _StackIDMap[dtoID] = originalID;
            return new StackDTO { ID = dtoID ,Name = stack.Name };
        }

        internal static FlashcardDTO toFlashcardDTO(Flashcard flashcard, int dtoID)
        {
            int originalID = Convert.ToInt32(flashcard.ID);

            _FlashcardIDMap[dtoID] = originalID;
            return new FlashcardDTO { ID = dtoID, Front = flashcard.Front, Back = flashcard.Back };
        }


    }
}
