using ScreenSound.Web.Response;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services
{
    public class AuthAPI(IHttpClientFactory factory)
    {
        private readonly HttpClient _httpClient= factory.CreateClient("API");
        public async Task<AuthResponse> LoginAsync(string email, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("auth/loign", new
            {
                email,
                password
            });
            if (response.IsSuccessStatusCode)
            {
                return new AuthResponse { success = true };

            }
            return new AuthResponse
            {
                success = false,
                Errors = "Email ou senha invalidos"
            };
        }
    }
}
