using IdentityServer.Models.Responses;
using PazarAtlasi.CMS.Application.Models.Dtos;
using PazarAtlasi.Core.Common.Models.Shared.Dtos;
using PazarAtlasi.Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Application.Interfaces.Infrastructure
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInDto signInInput);

        Task<Response<bool>> Register(RegisterDto registerInput);

        Task<TokenResponse> GetAccessTokenByRefreshToken();

        Task RevokeRefreshToken();
    }
}
