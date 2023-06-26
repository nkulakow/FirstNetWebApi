namespace FirstNet.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> _characters = new List<Character>{
            new Character(),
            new Character { Name = "Paimon", Id=1}
        };

        IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = this._mapper.Map<Character>(newCharacter);
            character.Id = _characters.Max(c => c.Id) + 1;
            _characters.Add(character);
            ServiceResponse.Data = _characters.Select(c => this._mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>()
            {
                Data = _characters.Select(c => this._mapper.Map<GetCharacterDto>(c)).ToList()
            };
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var ServiceResponse = new ServiceResponse<GetCharacterDto>();
            var character = _characters.FirstOrDefault(c => c.Id == id);
            ServiceResponse.Data = this._mapper.Map<GetCharacterDto>(character);
            if (character is null)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = "No character with given id";
            }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var ServiceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = _characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                if (character is null)
                {
                    throw new Exception($"No character with given id = '{updatedCharacter.Id}'");
                }
                character.Name = updatedCharacter.Name;
                character.Class = updatedCharacter.Class;
                character.Defense = updatedCharacter.Defense;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Strenght = updatedCharacter.Strenght;

                ServiceResponse.Data = this._mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                var character = _characters.FirstOrDefault(c => c.Id == id);
                if (character is null)
                {
                    throw new Exception($"No character with given id = '{id}'");
                }
                _characters.Remove(character);

                ServiceResponse.Data = _characters.Select(c => this._mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                ServiceResponse.Success = false;
                ServiceResponse.Message = ex.Message;
            }
            return ServiceResponse;
        }
    }
}