using NLayer.Core.DTOs;
using NLayer.Core.DTOs.GenericDTO;

namespace NLayer.Web.Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {


            _httpClient = httpClient;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CategoryDto>>>("categories");
            return response.Data;
        }
    }
}
