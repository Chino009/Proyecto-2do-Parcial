using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.WebSite.Service.Interfaces;

public interface IUserService
{
    Task<Response<List<UserDto>>> GetAllAsync();

    Task<Response<UserDto>> GetById(int id);

    Task<Response<UserDto>> SaveAsync(UserDto user);

    Task<Response<UserDto>> UpdateAsync(UserDto user);

    Task<Response<bool>> DeleteAsync(int id);
    
}