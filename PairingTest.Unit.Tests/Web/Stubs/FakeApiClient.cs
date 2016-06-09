using PairingTest.Web.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Unit.Tests.Web.Stubs
{
    public class FakeApiClient : IApiClient
    {
        public FakeApiClient(string response)
        {
            this.Response = response;
        }

        public string Response { get; set; }

        public string Get(string apiMethod)
        {
            return Response;
        }
    }
}
