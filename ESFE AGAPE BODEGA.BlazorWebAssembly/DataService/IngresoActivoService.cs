using ESFE_AGAPE_BODEGA.DTOs.ActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.BodegaDTOs;
using ESFE_AGAPE_BODEGA.DTOs.EstanteDTOs;
using ESFE_AGAPE_BODEGA.DTOs.IngresoActivoDTOs;
using ESFE_AGAPE_BODEGA.DTOs.UsuarioDTOs;
using System.Net.Http.Json;

namespace ESFE_AGAPE_BODEGA.BlazorWebAssembly.DataService
{
	public class IngresoActivoService
	{
		private readonly HttpClient _httpClient;
		public IngresoActivoService(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("BodegaAPI");
		}

		public async Task<List<SearchResultActivoDTO.ActivoDTO>> ObtenerActivos()
		{
			var response = await _httpClient.GetAsync("Activo");
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<List<SearchResultActivoDTO.ActivoDTO>>();
				return result ?? new List<SearchResultActivoDTO.ActivoDTO>();
			}
			return new List<SearchResultActivoDTO.ActivoDTO>();
		}
		public async Task<List<SearchResultBodegaDTO.BodegaDTO>> ObtenerBodegas()
		{
			var response = await _httpClient.GetAsync("Bodega");
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<List<SearchResultBodegaDTO.BodegaDTO>>();
				return result ?? new List<SearchResultBodegaDTO.BodegaDTO>();
			}
			return new List<SearchResultBodegaDTO.BodegaDTO>();
		}
		public async Task<List<SearchResultEstanteDTO.EstanteDTO>> ObtenerEstantes()
		{
			var response = await _httpClient.GetAsync("Estante");
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<List<SearchResultEstanteDTO.EstanteDTO>>();
				return result ?? new List<SearchResultEstanteDTO.EstanteDTO>();
			}
			return new List<SearchResultEstanteDTO.EstanteDTO>();
		}
		public async Task<string> ObtenerCorrelativo()
		{
			try
			{
				// Obtener todos los correlativos de ambos servicios
				var ingresosResponse = await _httpClient.GetAsync("IngresoActivo");

				int maxNumero = 0;

				if (ingresosResponse.IsSuccessStatusCode)
				{
					var ingresos = await ingresosResponse.Content.ReadFromJsonAsync<List<GetIdResultIngresoActivoDTO>>();
					if (ingresos != null)
					{
						foreach (var ingreso in ingresos)
						{
							if (string.IsNullOrEmpty(ingreso.Correlativo)) continue;
							string[] partes = ingreso.Correlativo.Split('-');
							if (partes.Length == 2 && int.TryParse(partes[1], out int numero))
							{
								maxNumero = Math.Max(maxNumero, numero);
							}
						}
					}
				}



				// Incrementar el número más alto encontrado
				return $"IG-{(maxNumero + 1):000}";
			}
			catch
			{
				return "IG-001";
			}
		}
		public async Task<List<GetIdResultUsuarioDTO.UsuarioDTO>> ObtenerUsuario()
		{
			var response = await _httpClient.GetAsync("Usuario");
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<List<GetIdResultUsuarioDTO.UsuarioDTO>>();
				return result ?? new List<GetIdResultUsuarioDTO.UsuarioDTO>();
			}
			return new List<GetIdResultUsuarioDTO.UsuarioDTO>();
		}

		// Obtener un IngresoActivo por su ID
		public async Task<GetIdResultIngresoActivoDTO> ObtenerIngresoActivoPorId(int id)
		{
			var response = await _httpClient.GetAsync($"IngresoActivo/{id}");

			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<GetIdResultIngresoActivoDTO>();
				return result ?? new GetIdResultIngresoActivoDTO();
			}

			return new GetIdResultIngresoActivoDTO();
		}

		// Crear un nuevo IngresoActivo
		public async Task<int> CrearIngresoActivo(CrearIngresoActivoDTO crearIngresoActivoDTO)
		{
			// Validación adicional antes de hacer la llamada a la API
			if (!crearIngresoActivoDTO.TieneDetalles())
			{
				return 0;
			}
			var response = await _httpClient.PostAsJsonAsync("IngresoActivo", crearIngresoActivoDTO);

			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadAsStringAsync();
				return int.TryParse(result, out var id) ? id : 0;
			}

			return 0;
		}

		// Actualizar un IngresoActivo existente
		public async Task<int> ActualizarIngresoActivo(EditIngresoActivoDTO editIngresoActivoDTO)
		{
			// Validación adicional antes de hacer la llamada a la API
			if (!editIngresoActivoDTO.TieneDetalles())
			{
				return 0;
			}

			var response = await _httpClient.PutAsJsonAsync($"IngresoActivo/{editIngresoActivoDTO.Id}", editIngresoActivoDTO);

			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadAsStringAsync();
				return int.TryParse(result, out var id) ? id : 0;
			}

			return 0;
		}

		// Eliminar un IngresoActivo por su ID
		public async Task<int> EliminarIngresoActivo(int id)
		{
			int result = 0;
			var response = await _httpClient.DeleteAsync($"IngresoActivo/{id}");

			if (response.IsSuccessStatusCode)
			{
				var responseBody = await response.Content.ReadAsStringAsync();
				if (int.TryParse(responseBody, out result) == false)
					return result = 0;
			}
			return result;
		}

		// Buscar IngresoActivo con parámetros de búsqueda y paginación
		public async Task<SearchResultIngresoActivoDTO> Buscar(SearchQueryIngresoActivoDTO searchQuery)
		{
			var response = await _httpClient.PostAsJsonAsync("IngresoActivo/buscar", searchQuery);

			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<SearchResultIngresoActivoDTO>();
				return result ?? new SearchResultIngresoActivoDTO();
			}

			return new SearchResultIngresoActivoDTO();
		}
	}
}
