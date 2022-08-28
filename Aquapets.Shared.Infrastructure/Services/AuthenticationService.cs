using Aquapets.Shared.Abstractions.Exceptions;
using Aquapets.Shared.Api.Constants;
using Aquapets.Shared.Application.DTOs;
using Aquapets.Shared.Application.Services;
using Aquapets.Shared.Infrastructure.Exceptions;
using Aquapets.Shared.Infrastructure.Models;
using Firebase.Auth;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquapets.Shared.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService<string, FirebaseAuthLink, string, FirebaseAuthLink, string>
    {
        public async Task<FirebaseAuthLink> Login(LoginDto loginDto, string config)
        {
            FirebaseAuthProvider auth = new FirebaseAuthProvider(new FirebaseConfig(config));

            try
            {
                var fbAuthLink = await auth.SignInWithEmailAndPasswordAsync(loginDto.Email, loginDto.Password);
                return fbAuthLink;


            }
            catch (FirebaseAuthException ex)
            {
                var firebaseEx = JsonConvert.DeserializeObject<FirebaseErrorModel>(ex.ResponseData);

                if (firebaseEx.error.message == "INVALID_PASSWORD")
                {
                    throw new FirebaseLoginException("You may have entered a wrong username or password");
                }

                if (firebaseEx.error.message == "EMAIL_NOT_FOUND")
                {
                    throw new FirebaseLoginException("You may have entered a wrong username or password");
                }

                throw new UnknownErrorException();

            }
        }

        public async Task<string> Logout(HttpContext httpContext)
        {
            if (httpContext.Request.Cookies[ApiConstants.JwtAuthCookieName] == null)
            {
                throw new FirebaseLogoutException("Only valid user can log out");
            }
            try
            {
                httpContext.Response.Cookies.Append(ApiConstants.JwtAuthCookieName, "Logout", new CookieOptions { Expires = DateTime.Now.AddDays(-1d) });
                return await Task.FromResult("Logout successful");
            }
            catch (Exception)
            {
                throw new FirebaseLogoutException("Some unknown error occurred");
            }
        }

        public async Task<string> ResetPassword(string email, string config)
        {
            FirebaseAuthProvider auth = new FirebaseAuthProvider(new FirebaseConfig(config));
            try
            {
                await auth.SendPasswordResetEmailAsync(email);

                return "An email to reset your password has been sent to your registered email address";

            }
            catch (Exception)
            {
                throw new UnknownErrorException();

            }
        }

        public async Task<FirebaseAuthLink> SignUp(SignUpDto signUpDto, string config)
        {
            FirebaseAuthProvider auth = new FirebaseAuthProvider(new FirebaseConfig(config));

            try
            {

                await auth.CreateUserWithEmailAndPasswordAsync(signUpDto.Email, signUpDto.Password);

                var fbAuthLink = await auth
                                .SignInWithEmailAndPasswordAsync(signUpDto.Email, signUpDto.Password);
                return fbAuthLink;

            }
            catch (FirebaseAuthException ex)
            {
                var firebaseEx = JsonConvert.DeserializeObject<FirebaseErrorModel>(ex.ResponseData);
                if (firebaseEx.error.message == "EMAIL_EXISTS")
                {
                    throw new FirebaseLoginException("User is already registered. Try logging in...");
                }

                throw new UnknownErrorException();
            }
        }
    }
    
}
