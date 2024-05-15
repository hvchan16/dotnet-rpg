global using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharachterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharachterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharachterDto>>> AddCharacter(AddCharacterDto newcharacter);
    }
}