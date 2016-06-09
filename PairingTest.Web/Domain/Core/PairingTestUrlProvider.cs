using PairingTest.Web.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PairingTest.Web.Domain.Core
{
    public class PairingTestUrlProvider: IPairingTestUrlProvider
    {
        public string WebApiUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["QuestionnaireServiceUri"];
            }
        }
    }
}