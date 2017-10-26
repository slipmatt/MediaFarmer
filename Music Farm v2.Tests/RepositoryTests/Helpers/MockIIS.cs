using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MediaFarmer.Tests.RepositoryTests.Helpers
{
    public static class MockIIS
    {
        public static void MockIISHost()
        {
            var HttpRequest = new HttpRequest("", "http://localhost/", "");
            HttpRequest.AddServerVariable("REMOTE_HOST", "acer\\aspire");
            var httpResponce = new HttpResponse(new StringWriter());
            var httpContext = new HttpContext(HttpRequest, httpResponce);
            HttpContext.Current = httpContext;
        }
    }
}
