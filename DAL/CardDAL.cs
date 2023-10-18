using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CardDAL : AbstractDAL
    {
        public void Insert(Card card)
        {
            context.Cards.Add(card);
            context.SaveChanges();
        }

        public void Update(Card card)
        {
            Card c = context.Cards.FirstOrDefault(each => each.CardNumber == card.CardNumber);
            if(c != null)
            {
                c.Rank = card.Rank;
                c.Point = card.Point;
                c.UserId = card.UserId;
                context.SaveChanges();
            }
        }

        public void Delete(Card card)
        {
            Card c = context.Cards.FirstOrDefault(each => each.CardNumber == card.CardNumber);
            if(c != null)
            {
                context.Cards.Remove(c);
                context.SaveChanges();
            }
        }

        public Card GetCardByCardNumber(string cardNumber)
        {
            return context.Cards.FirstOrDefault(p => p.CardNumber == cardNumber);
        }

        public Card GetCardByUserId(int userId)
        {
            return context.Cards.FirstOrDefault(p => p.UserId == userId);
        }
    }
}
