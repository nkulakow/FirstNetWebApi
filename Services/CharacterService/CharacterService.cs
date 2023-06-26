namespace FirstNet.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {


        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            var character = this._mapper.Map<Character>(newCharacter);
            if (dbCharacters.Count > 0)
                character.Id = dbCharacters.Max(c => c.Id) + 1;
            else
                character.Id = 1; ;
            _context.Characters.Add(character);
            _context.SaveChanges();
            dbCharacters = await _context.Characters.ToListAsync();
            ServiceResponse.Data = dbCharacters.Select(c => this._mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var dbCharacters = await _context.Characters.ToListAsync();
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>()
            {
                Data = dbCharacters.Select(c => this._mapper.Map<GetCharacterDto>(c)).ToList()
            };
            return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var ServiceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacters = await _context.Characters.ToListAsync();
            var character = dbCharacters.FirstOrDefault(c => c.Id == id);
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
                var dbCharacters = await _context.Characters.ToListAsync();
                var character = dbCharacters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
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

                _context.Characters.Update(character);
                _context.SaveChanges();

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
            var dbCharacters = await _context.Characters.ToListAsync();
            try
            {
                var character = dbCharacters.FirstOrDefault(c => c.Id == id);
                if (character is null)
                {
                    throw new Exception($"No character with given id = '{id}'");
                }
                _context.Characters.Remove(character);
                _context.SaveChanges();
                dbCharacters = await _context.Characters.ToListAsync();
                ServiceResponse.Data = dbCharacters.Select(c => this._mapper.Map<GetCharacterDto>(c)).ToList();
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