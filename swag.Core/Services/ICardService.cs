using swag.Core.Domain;
using swag.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace swag.Core.Services
{
    public interface ICardService
    {
        Task<CardDTO> GetAsync(string cardnumber);
        Task AddAsync(CardDTO carddtp);
        Task UpdateAsync(CardDTO carddto);
        Task RemoveAsync(string cardnumber);
        Task<Response> ValidateAsync(CardDTO carddto);
    }
}
