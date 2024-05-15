global using AutoMapper;
using dotnet_rpg.Controllers;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Id = 1, Name = "Same"}
        };

        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharachterDto>>> AddCharacter(AddCharacterDto newcharacter)
        {
            var servicesResponse = new ServiceResponse<List<GetCharachterDto>>();
            characters.Add(_mapper.Map<Character>(newcharacter));
            servicesResponse.Data = characters.Select(c => _mapper.Map<GetCharachterDto>(c)).ToList();
            return servicesResponse;
        }

        public async Task<ServiceResponse<List<GetCharachterDto>>> GetAllCharacters()
        {
            var servicesResponse = new ServiceResponse<List<GetCharachterDto>>();
            servicesResponse.Data = characters.Select(c => _mapper.Map<GetCharachterDto>(c)).ToList();
            return servicesResponse;
        }

        public async Task<ServiceResponse<GetCharachterDto>> GetCharacterById(int id)
        {
            var servicesResponse = new ServiceResponse<GetCharachterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id)!;
            servicesResponse.Data = _mapper.Map<GetCharachterDto>(character);;
            return servicesResponse;

            throw new Exception("Could not find character");
        }
    }
}