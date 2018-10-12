using swag.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace swag.Core.Repositories
{
    public interface ICardRepository
    {
        Task<Cards> GetAsync(string cardnumber);
        Task AddAsync(Cards card);
        Task UpdateAsync(Cards card);
        Task RemoveAsync(string cardnumber);
       
    }
}
