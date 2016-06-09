using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Web.Domain.Interfaces
{
    public interface IApiClient
    {
        string Get(string apiMethod);
    }
}
