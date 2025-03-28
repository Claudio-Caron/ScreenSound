﻿using ScreenSound.API.Response;
using ScreenSound.Web.Requests;
using ScreenSound.Web.Response;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services;

public class ArtistaAPI
{
    private readonly HttpClient _httpClient;

    public ArtistaAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<ArtistaResponse>?> GetArtistasAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("artistas");
    }

    public async Task AddArtistaAsync(ArtistaRequest artista)
    {
        await _httpClient.PostAsJsonAsync("artistas", artista);
    }

    public async Task<ArtistaResponse?> GetArtistaPorNomeAsync(string nome)
    {
        return await _httpClient.GetFromJsonAsync<ArtistaResponse>($"artistas/{nome}");
    }
    public async Task DeleteArtistaAsync(int id)
    {
        await _httpClient.DeleteAsync($"artistas/{id}");
    }

    public async Task UpdateArtistaAsync(ArtistaRequestEdit artista)
    {        
       await _httpClient.PutAsJsonAsync($"artistas", artista);
    }
    public async Task AvaliarArtistaAsync(int nota, int ArtistaId)
    {
        await _httpClient.PostAsJsonAsync($"artistas/avaliacao", new {ArtistaId, nota });
    }
    public async Task<AvaliacaoArtistaResponse?> GetAvaliacaoDaPessoaLogadaAsync(int artistaId)
    {
        return await _httpClient.GetFromJsonAsync<AvaliacaoArtistaResponse>($"artistas/{artistaId}/avaliacao");
    }
}
