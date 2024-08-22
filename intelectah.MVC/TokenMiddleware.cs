namespace intelectah.MVC
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                if (!IsValidToken(token))
                {
                    context.Response.Redirect("/Home/Index");
                    return;
                }
            }
            else
            {
                context.Response.Redirect("/Home/Index");
                return;
            }

            await _next(context);
        }

        private bool IsValidToken(string token)
        {
            // Implemente a lógica de validação de token aqui
            return true;
        }
    }
}
