namespace ProyectoFinal.VetSite.Utilities
{
    public class SessionMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Obtener el ID de usuario de la sesión
            var usuarioID = context.Session.GetString("UsuarioID");

            // Verificar si el usuario no está autenticado y está intentando acceder a una página protegida
            if (string.IsNullOrEmpty(usuarioID) && !context.Request.Path.Value.Contains("/Login"))
            {
                // Redirigir a la página de login
                context.Response.Redirect("/Login");
                return;
            }

            await _next(context);
        }
    }
}
