using ESFE_AGAPE_BODEGA.DTOs.AjustesInventarioDTOs;
using System.Net.Http.Json;
using static ESFE_AGAPE_BODEGA.DTOs.AjustesInventarioDTOs.GetIdResultAjusteInvetarioDTO;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
    public class AjusteInventarioService
    {
        private readonly HttpClient _httpClient;

        public AjusteInventarioService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BodegaAPI");
        }

        // Obtener todos los ajustes de inventario
        public async Task<List<GetIdResultAjusteInvetarioDTO.AjusteInventarioDTO>> ObtenerTodos()
        {
            var response = await _httpClient.GetAsync("AjusteInventario");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<GetIdResultAjusteInvetarioDTO.AjusteInventarioDTO>>();
                return result ?? new List<GetIdResultAjusteInvetarioDTO.AjusteInventarioDTO>();
            }
            return new List<GetIdResultAjusteInvetarioDTO.AjusteInventarioDTO>();
        }

        // Buscar ajustes de inventario con paginación y filtros
        public async Task<GetIdResultAjusteInvetarioDTO> Buscar(SearchQueryAjusteInvetarioDTO searchQueryAjusteInvetarioDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("AjusteInventario/buscar", searchQueryAjusteInvetarioDTO);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultAjusteInvetarioDTO>();
                return result ?? new GetIdResultAjusteInvetarioDTO();
            }
            return new GetIdResultAjusteInvetarioDTO();
        }

        // Obtener un ajuste de inventario por su ID
        public async Task<GetIdResultAjusteInvetarioDTO.AjusteInventarioDTO> ObtenerAjusteInventarioId(int id)
        {
            var rol = await _httpClient.GetAsync($"AjusteInventario/{id}");

            if (rol.IsSuccessStatusCode)
            {
                var result = await rol.Content.ReadFromJsonAsync<AjusteInventarioDTO>();
                return result ?? new AjusteInventarioDTO();
            }
            else
                return new AjusteInventarioDTO(); ;
        }

        // Crear un nuevo ajuste de inventario
        public async Task<int> CrearAjusteInventario(CreateAjusteInvetarioDTO crearAjusteInventarioDTO)
        {
            int result = 0;
            var response = await _httpClient.PostAsJsonAsync("AjusteInventario", crearAjusteInventarioDTO);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }

        // Actualizar un ajuste de inventario existente
        public async Task<int> ActualizarAjusteInventario(EditAjusteInvetarioDTO editAjusteInventarioDTO)
        {
            int result = 0;
            var response = await _httpClient.PutAsJsonAsync($"AjusteInventario/{editAjusteInventarioDTO.Id}", editAjusteInventarioDTO);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }

        // Eliminar un ajuste de inventario
        public async Task<int> EliminarAjusteInventario(int id)
        {
            int result = 0;
            var response = await _httpClient.DeleteAsync($"AjusteInventario/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    return result = 0;
            }
            return result;
        }
    }
}
