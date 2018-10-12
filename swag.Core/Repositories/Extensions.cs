using swag.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace swag.Core.Repositories
{
    public static class Extensions
    {
        public static async Task<Cards> GetOrFailAsync(this ICardRepository repository, string cardnumber)
        {
            var card = await repository.GetAsync(cardnumber);
            if (card== null)
            {
                throw new SwagException("card_not_found", $"Card: '{cardnumber}' was not found.");
            }

            return card;
        }
    }
}
