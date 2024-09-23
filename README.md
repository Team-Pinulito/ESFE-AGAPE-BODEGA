Configuración de CORS para Blazor WebAssembly
Para permitir que tu aplicación Blazor WebAssembly se comunique correctamente con el servidor, es necesario configurar CORS (Cross-Origin Resource Sharing) en tu servidor API. A continuación, se detallan los pasos necesarios.

Configuración de Servicios
Agrega la siguiente configuración en tu clase de Startup.cs o en el archivo correspondiente:

Copiar
// Configurar servicios
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("https://localhost:7293") // Cambia esto al origen de tu aplicación
            .AllowAnyMethod()
            .AllowAnyHeader());
});
Configuración del Middleware
Asegúrate de agregar el middleware de CORS en tu configuración de aplicación:

Copiar
// Configurar middleware
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();
Solución de Problemas CORS
Si experimentas el error "has been blocked by CORS", es probable que necesites:

Confirmar que la configuración de CORS está correctamente aplicada en el servidor API.
Verificar que el origen (https://localhost:7293) esté habilitado para enviar y recibir solicitudes.
Nota
Si cambias la dirección de tu aplicación, asegúrate de actualizar el valor en WithOrigins para que coincida con el nuevo origen.
