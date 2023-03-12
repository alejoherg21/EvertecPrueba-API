using Helper;

namespace Service.Jwt
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        JwtUtils jwtUtils;

        public JwtMiddleware(RequestDelegate next, JwtParams jwt)
        {
            _next = next;
            jwtUtils = new JwtUtils(jwt);
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var path = context.Request.Path;

            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                WriteError.WriteAction(userId, path);
                // attach user to context on successful jwt validation
                context.Items["User"] = userId;
            }

            await _next(context);
        }
    }
}
