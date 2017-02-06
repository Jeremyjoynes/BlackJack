using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    public class Cards
    {
        public string ID { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }

        public Cards(string id, string suit, int value)
        {
            ID = id;
            Suit = suit;
            Value = value;
        }
    }

    public class Deck : Stack<Cards>
    {
        public Deck(IEnumerable<Cards> collection) : base(collection) { }
        public Deck() : base(52) { }


        //public Cards this[int index]
        //{
        //    get { }
        //}

    }
}
