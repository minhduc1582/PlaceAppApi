using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Services.Account;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Volo.Abp.Application.Services;

namespace PlaceApp.Login
{
    public class LoginTokenResultAppService : ApplicationService, ILoginTokenResultAppService
    {
        private readonly IConfiguration _configuration;
        public LoginTokenResultAppService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<LoginResultDto> LoginGetToken(UserLoginDto user)
        {
            LoginResultDto loginResultDto = new LoginResultDto();
            //HttpClient client = new HttpClient();
            //string url = $"{_configuration.GetSection("ExternalAPIs:UrlAdmin").Value}/api/account/login";
            //HttpResponseMessage response = await client.PostAsJsonAsync(
            //    url, user);
            //response.EnsureSuccessStatusCode();

            var httpClient = new HttpClient();
            var passwordTokenRequest = new PasswordTokenRequest()
            {
                Address = $"{_configuration.GetSection("ExternalAPIs:UrlAdmin").Value}/connect/token",
                // Scope = _configuration["AuthServers:Scope"],
                ClientId = $"{_configuration.GetSection("ExternalAPIs:ClientId").Value}",
                ClientSecret = $"{ _configuration.GetSection("ExternalAPIs:ClientSecret").Value }",
                Scope = $"{_configuration.GetSection("ExternalAPIs:Scope").Value}",
                UserName = user.userNameOrEmailAddress,
                Password = user.password,
                Method = HttpMethod.Post
                
                
            };
            try
            {
                var result = await httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

                if (result.IsError)
                {

                    loginResultDto.description = "InvalidUserNameOrPassword";
                    return loginResultDto;
                }

                loginResultDto.result = 1;
                loginResultDto.description = "Success";
                loginResultDto.token = result?.AccessToken;
                loginResultDto.tokenType = result?.TokenType;
                loginResultDto.expireIn = result.ExpiresIn.ToString();
                return loginResultDto;

            }
            catch (Exception e)
            {
                loginResultDto.description = "InvalidUserNameOrPassword";
                return loginResultDto;
            }
            // url = $"{_configuration.GetSection("ExternalAPIs:UrlAdmin").Value}/connect/token";
            //var client = new RestClient(url);
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddParameter("grant_type", "password");
            //request.AddParameter("username", "admin");
            //request.AddParameter("password", "1q2w3E*");
            ////request.AddParameter("client_id", "WebPublic");
            ////request.AddParameter("client_secret", "secret");
            //IRestResponse response = client.Execute(request);
            //var token = JsonConvert.DeserializeObject<GetTokenDto>(response.Content);
            //return token?.AccessToken;
        }
    }
        //public class GetTokenDto
        //{
        //    [JsonProperty("access_token")]
        //    public string AccessToken { get; set; }

        //    [JsonProperty("expires_in")]
        //    public int ExpiresIn { get; set; }

        //    [JsonProperty("token_type")]
        //    public string TokenType { get; set; }

        //    [JsonProperty("refresh_token")]
        //    public string RefreshToken { get; set; }

        //    [JsonProperty("scope")]
        //    public string Scope { get; set; }
        //}
 }
