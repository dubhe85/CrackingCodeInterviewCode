using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCodeInterviewSample.ObjectOriented_Design
{
    /*
     Deck of Cards: Design the data structures for a generic deck of cards. Explain how you would
    subclass the data structures to implement blackjack.
    */

    public enum Suit
    { 
        Club = 0,
        Diamond = 1,
        Heart = 2,
        Spade = 3
    }

    public abstract class Card
    {
        private bool available = true;

        /* number or face that's on card - a number 2 through 10, or 11 for Jack, 
           12 for Queen, 13 for King, or 1 for Ace.*/
        protected int faceValue;
        protected Suit suit;

        public Card(int c, Suit s)
        {
            faceValue = c;
            suit = s;
        }

        public abstract int value();

        public Suit Suit()
        {
            return suit;
        }

        /* Checks if the card is available to be given out to someone. */
        public bool isAvailable()
        {
            return available;
        }

        public void markUnavailable()
        {
            available = false;
        }

        public void markAvailable()
        {
            available = true;
        }
    }

    public class Deck<T> where T : Card 
    {
        private List<T> cards; // all cards, dealt or not
        private int dealtIndex = 0; // marks first undealt card

        public void setDeckOfCards(List<T> deckOfCards)
        { 
            // implementation here
        }

        public void shuffle()
        { }

        public int remainingCards() 
        { 
            return cards.Count - dealtIndex;
        }

        public T[] dealHand(int number)
        {
            throw new NotImplementedException();
        }

        public T delaCard()
        {
            throw new NotImplementedException();
        }   
    }

    public class Hand<T> where T : Card 
    {
        protected List<T> cards = new List<T>();

        public int score()
        {
            int score = 0;

            foreach (T card in cards)
            {
                score += card.value();
            }

            return score;
        }

        public void addCard(T card)
        {
            cards.Add(card);
        }    
    }

    public class BlackJackCard : Card
    {

        public BlackJackCard(int c, Suit s) : base(c, s)
        { 
        
        }

        public override int value()
        {
            if (isAce())
            {
                return 1;
            }
            else if (isFaceCard())
            {
                return 10;
            }
            else return faceValue;        
        }

        public int minValue()
        {
            if (isAce())
            {
                return 1;
            }
            else
            {
                return value();
            }
        }

        public int maxValue()
        {
            if (isAce())
            {
                return 11;
            }
            else
            {
                return value();
            }
        }

        private bool isAce()
        {
            return faceValue == 1;
        }

        public bool isFaceCard()
        {
            return faceValue >= 11 && faceValue <= 13;
        }
    }

    public class BlackJackHand : Hand<BlackJackCard>
    {

        public int score()
        {
            List<int> scores = possibleScores();
            int maxUnder = int.MinValue;
            int minOver = int.MaxValue;

            foreach (var score in scores)
            {
                if (score > 21 && score < minOver)
                {
                    minOver = score;
                }
                else if (score <= 21 && score > maxUnder)
                {
                    maxUnder = score;
                }           
            }

            return maxUnder == int.MinValue ? minOver : maxUnder;
        
        
        }

        /* retun a list of all possible scores this hand could have (evaluating each ace as both 1 and 11) */
        private List<int> possibleScores()
        {
            throw new NotImplementedException();
        }

        public bool busted()
        {
            return score() > 21;
        }

        public bool is21()
        {
            return score() == 21;
        }

        public bool isBlackJack()
        {
            return false;
        }
    }
}
