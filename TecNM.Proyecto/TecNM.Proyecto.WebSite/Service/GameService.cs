using Newtonsoft.Json;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.WebSite.Service.Interfaces;

namespace TecNM.Proyecto.WebSite.Service;

public class GameService: IGameService
{
    private readonly string _baseurl = "https://localhost:7033/";
    private readonly string _endpoint = "api/Game";

    public GameService()
    {

    }

    public async Task<Response<List<GameDto>>> GetAllAsync()
    {
        var url = $"{_baseurl}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<List<GameDto>>>(json);
        return response;
    }

    public async Task<Response<GameDto>> GetById(int id)
    {
        var url = $"{_baseurl}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<GameDto>>(json);

        return response;
    }

    public async Task<Response<GameDto>> SaveAsync(GameDto game)
    {
        var url = $"{_baseurl}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(game);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<GameDto>>(json);
        return response;
    }

    public async Task<Response<GameDto>> UpdateAsync(GameDto game)
    {
        var url = $"{_baseurl}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(game);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<GameDto>>(json);
        return response;
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var url = $"{_baseurl}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.DeleteAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<bool>>(json);
        return response;
    }
}