using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CardService : AbstractService
    {
        private Dictionary<int, string> ranks = new Dictionary<int, string>
        {
            { 0, "Vô Hạng" },
            { 1000, "Đồng" },
            { 2500, "Bạc" },
            { 5000, "Vàng" },
            { 10000, "Kim Cương" },
        };
        public void RegisterCard(Card card)
        {
            string rank;
            if(card.CardNumber.Trim().Length == 0)
            {
                throw new Exception("Mã card không được để trống");
            }

            card.Point = 0;
            if(!ranks.TryGetValue(0, out rank))
            {
                throw new Exception("Rank không hopwj lệ");
            }
            card.Rank = rank;
            CardDAL.Insert(card);
        }

        public void UpdatePoints(Card card)
        {
            Card c = CardDAL.GetCardByCardNumber(card.CardNumber);
            if (c == null)
            {
                throw new Exception("Không tim thấy thẻ");
            }
            foreach (var item in ranks)
            {
                if(card.Point > item.Key)
                {
                    card.Rank = item.Value;
                }
            }
            CardDAL.Update(card);
        }

        public void DeletaCard(Card card)
        {
            Card c = CardDAL.GetCardByCardNumber(card.CardNumber);
            if (c == null)
            {
                throw new Exception("Không tim thấy thẻ");
            }
            CardDAL.Delete(card);
        }
    }
}
