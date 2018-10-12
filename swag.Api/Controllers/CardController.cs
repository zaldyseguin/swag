using Microsoft.AspNetCore.Mvc;
using swag.Core.DTO;
using swag.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swag.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController:Controller
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var card = await _cardService.GetAsync("411111201811121");

            return Json(card);
        }

        [HttpGet("{cardnumber}")]
        public async Task<IActionResult> Get(string cardnumber)
        {
            var response = new Response();

            var card = await _cardService.GetAsync(cardnumber);
            

            if (card == null)
                response=new Response { CardNumber = cardnumber, CardType = "Unknown", Result = "Does not Exist" };
            else
            {
var factory = new CreditCardFactorycs() as ICreditCardName;
                response = factory.GetCreditCardName(card).Result;
            }

            return Json(response);
        }

    }
}
