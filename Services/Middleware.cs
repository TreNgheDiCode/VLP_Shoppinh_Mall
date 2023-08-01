using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Text;
using VLPMall.Helpers;
using VLPMall.Models;
using System;

namespace VLPMall.Services
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<MiddlewareSettings> _middleware;

        public Middleware(RequestDelegate next, IOptions<MiddlewareSettings> middleware)
        {
            _next = next;
            _middleware = middleware;
        }

        public async Task Invoke(HttpContext context, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            // Get the list of ignored routes from the configuration file.
            var ignoredRoutes = _middleware.Value.Admin;

            // Get the path of the current request.
            var request = context.Request;
            var controller = request.Path.Value.ToLower();

            // Check if the path contains any of the ignored routes.
            if (controller.Contains(ignoredRoutes))
            {
                if (!context.Request.Headers.ContainsKey("Authorization"))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Lỗi đăng nhập");
                    return;
                }
                // Basic userId:password
                var header = context.Request.Headers["Authorization"];
                var encryptedCreds = header.ToString().Substring(6);
                var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encryptedCreds));
                string[] uidpwd = creds.Split(':');
                var uid = uidpwd[0];
                var password = uidpwd[1]; 
            }


            //if (controller.Contains(ignoredRoutes))
            //{
            //    if (signInManager.IsSignedIn(context.User))
            //    {
            //        if (!context.User.IsInRole("super-admin"))
            //        {
            //            var bytes = Encoding.Unicode.GetBytes("Lỗi truy cập đã xảy ra, vui lòng kiểm tra lại quyền hạn");

            //            // If it does, return a 404 error.
            //            context.Response.StatusCode = 404;
            //            await context.Response.Body.WriteAsync(bytes);
            //            return;
            //        }
            //    } else
            //    {
            //        var bytes = Encoding.Unicode.GetBytes("Lỗi truy cập đã xảy ra, vui lòng kiểm tra lại đăng nhập");

            //        // If it does, return a 404 error.
            //        context.Response.StatusCode = 404;
            //        await context.Response.Body.WriteAsync(bytes);
            //        return;
            //    }
            //}

            await _next(context);
        }
    }
}
