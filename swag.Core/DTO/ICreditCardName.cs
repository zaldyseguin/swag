using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace swag.Core.DTO
{
    public interface ICreditCardName
    {
        Task<Response> GetCreditCardName(CardDTO carddto);
        
    }
}
