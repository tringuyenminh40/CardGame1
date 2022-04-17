using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLayer
{
    public class Hand
    {
        private List<Card> cards = new List<Card>();

        public int Count
        {
            get
            {
                return cards.Count();
            }
        }


        public Card this[int index]
        {
            get
            {
                return cards[index];
            }
        }


        public void AddCard(Card newCard)
        {
            if (ContainsCard(newCard))
            {
                throw new ConstraintException(newCard.FaceValue.ToString() + " of " +
                    newCard.Suit.ToString() + " already exists in the Hands");
            }

            cards.Add(newCard);
        }


        private bool ContainsCard(Card cardToCheck)
        {
            return cards.Where(card => card.FaceValue == cardToCheck.FaceValue && card.Suit == cardToCheck.Suit).Count() != 0;

        }


        private Suit[] suit;
        private FaceValue faceValue;

        private void HandTotal()
        {
            int handTotal = 0;
 //           handTotal = handTotal + Hand
        }
    }
}
