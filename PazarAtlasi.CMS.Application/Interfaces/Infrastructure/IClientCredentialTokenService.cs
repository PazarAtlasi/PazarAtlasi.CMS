using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Application.Interfaces.Infrastructure
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetTokenAsync();
    }
}
