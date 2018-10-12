using AutoMapper;
using swag.Core.Domain;
using swag.Core.DTO;
using swag.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace swag.Core.Services
{
    public class CardService : ICardService

    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public CardService(ICardRepository cardRepository,IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<CardDTO> GetAsync(string cardnumber)
        {
            var card = await _cardRepository.GetOrFailAsync(cardnumber);
            return _mapper.Map<CardDTO>(card); ;
        }

        public async Task AddAsync(CardDTO carddto)
        {
            var card = await _cardRepository.GetOrFailAsync(carddto.Cardnumber);
            if (card != null)
            {
                throw new SwagException("Card_already_exists", $"Card '{carddto.Cardnumber}' already exists.");
            }
            card = new Cards(Guid.NewGuid(), carddto.Cardnumber, Convert.ToDateTime(carddto.ExpiryDate));
            await _cardRepository.AddAsync(card);

        }

        public async Task RemoveAsync(string cardnumber)
        => await _cardRepository.RemoveAsync(cardnumber);

        public async Task UpdateAsync(CardDTO carddto)
        {
            var card = await _cardRepository.GetAsync(carddto.Cardnumber);
            var _card = new Cards(card.Id, carddto.Cardnumber, Convert.ToDateTime(carddto.ExpiryDate));

            await _cardRepository.UpdateAsync(_card);

        }

        public async Task<Response> ValidateAsync(CardDTO carddto)
        {
            string result = string.Empty;
            var _card = await _cardRepository.GetOrFailAsync(carddto.Cardnumber);

            if (_card != null)
                result = "exist";
            else
                result = "Does not exist";

            var response = new Response { Result = "valid", CardType = "visa" };

            return response;
        }

    }
}
