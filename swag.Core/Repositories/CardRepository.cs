using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using swag.Core.Domain;
using System.Linq;
using swag.Core.EF;

namespace swag.Core.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly SwagContext _context;

        public CardRepository(SwagContext context)
        {
            _context = context;
        }
        public async Task<Cards> GetAsync(string cardnumber)
        {
            var card = _context.Cards.SingleOrDefault(x => x.Cardnumber == cardnumber.ToLowerInvariant());

            return await Task.FromResult(card);
        }
        public async Task AddAsync(Cards card)
        {
            _context.Add(card);
            await Task.CompletedTask;
        }
        public async Task UpdateAsync(Cards card)
        {
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(string cardnumber)
        {
            _context.Remove(await GetAsync(cardnumber));
        }

        
    }
}
