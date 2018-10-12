using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace swag.Core.DTO
{
    public class CreditCardFactorycs : ICreditCardName
    {
       

        public async Task<Response> GetCreditCardName(CardDTO carddto)
        {
            var response = new Response();
            if (carddto.Cardnumber.StartsWith("4"))
            {
                response = new Response { CardNumber = carddto.Cardnumber, Result = "", CardType = "Visa" };
                if (Convert.ToDateTime(carddto.ExpiryDate).Year % 4 == 0 && carddto.Cardnumber.Length == 16)
                    response.Result = "Valid";
                else
                    response.Result = "InValid";
             }
            else if (carddto.Cardnumber.StartsWith("5"))
            {
                response = new Response { CardNumber = carddto.Cardnumber, Result = "", CardType = "MarterCard" };
                if (Check_Prime(Convert.ToDateTime(carddto.ExpiryDate).Year)!=0  && carddto.Cardnumber.Length == 16)
                    response.Result = "Valid";
                else
                    response.Result = "InValid";
            }
            else if (carddto.Cardnumber.StartsWith("34") || carddto.Cardnumber.StartsWith("35"))
            {
                response = new Response { CardNumber = carddto.Cardnumber, Result = "", CardType = "AmexCard" };
                if (carddto.Cardnumber.Length==15)
                    response.Result = "Valid";
                else
                    response.Result = "InValid";
            }
            else if (carddto.Cardnumber.StartsWith("3528–3589"))
            {
                response = new Response { CardNumber = carddto.Cardnumber, Result = "", CardType = "JCB" };
                 if (carddto.Cardnumber.Length == 16)
                    response.Result = "Valid";
                else
                    response.Result = "InValid";
            }
            else
                response = new Response { CardNumber = carddto.Cardnumber, Result = "", CardType = "Unknown" };

            return await Task.FromResult(response);
        }

        
        private static int Check_Prime(int number)
        {
            int i;
            for (i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                {
                    return 0;
                }
            }
            if (i == number)
            {
                return 1;
            }
            return 0;
        }
    }
}
