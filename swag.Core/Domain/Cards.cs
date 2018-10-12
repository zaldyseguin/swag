using System;
using System.Collections.Generic;
using System.Text;

namespace swag.Core.Domain
{
    public class Cards
    {
        public Guid Id { get; protected set; }
        public string Cardnumber { get; protected set; }
        public DateTime Expirydate { get; protected set; }

        public Cards()
        {              
        }

        public Cards(Guid id, string cardnumber,DateTime expirydate)
        {
            if (string.IsNullOrWhiteSpace(cardnumber))
            {
                throw new SwagException("empty_card_number",
                    "Cardnumber should not be empty.");
            }
            Id = id;
            Cardnumber = cardnumber;
            Expirydate = expirydate;
        }
    }
}
