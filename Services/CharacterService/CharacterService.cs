using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstNet.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Name = "Paimon", Id=1}
        };

        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        {
            var ServiceResponse = new ServiceResponse<List<Character>>();
            characters.Add(newCharacter);
            ServiceResponse.Data = characters;
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var ServiceResponse = new ServiceResponse<List<Character>>()
            {
                Data = characters
            };
            return ServiceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var ServiceResponse = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            ServiceResponse.Data = character;
            if (character is null)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "No character with given id";
            }
            return ServiceResponse;
        }
    }
}