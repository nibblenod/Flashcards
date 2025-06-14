using System.Globalization;
using Flashcards.Models;

namespace Flashcards.DTOs
{
    internal class DTOMapper
    {
        private Dictionary<int, int> _FlashcardIDMap = new Dictionary<int, int>();
        private Dictionary<int, int> _StackIDMap = new Dictionary<int, int>();

        public Dictionary<int, int> FlashcardIDMap
        {
            get { return _FlashcardIDMap; }
        }
        public Dictionary<int, int> StackIDMap
        {
            get { return _StackIDMap; }
        }
        internal StackDTO toStackDTO(StackModel stack, int dtoID)
        {
            int originalID = stack.Id;

            _StackIDMap[dtoID] = originalID;
            return new StackDTO { ID = dtoID ,Name = stack.Name };
        }

        internal FlashcardDTO toFlashcardDTO(Flashcard flashcard, int dtoID)
        {
            int originalID = Convert.ToInt32(flashcard.ID);

            _FlashcardIDMap[dtoID] = originalID;
            return new FlashcardDTO { ID = dtoID, Front = flashcard.Front, Back = flashcard.Back };
        }


    }
}
