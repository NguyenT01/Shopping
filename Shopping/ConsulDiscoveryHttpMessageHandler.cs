using Consul;
using System.Reflection;

namespace Shopping.API
{
    public class ConsulDiscoveryHttpMessageHandler : DelegatingHandler
    {
        private readonly IConsulClient _consulClient;
        public string ServiceName;

        public ConsulDiscoveryHttpMessageHandler(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var current = request.RequestUri;
            try
            {
                var url = await _consulClient.GetUriOnConsul(ServiceName);
                var uri = new Uri(url);
                request.RequestUri = new Uri(uri, current?.PathAndQuery);

                return await base.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                var method = MethodBase.GetCurrentMethod()?.Name;
                var className = GetType().Name;

                throw;
            }
            finally
            {
                request.RequestUri = current;
            }
        }
    }
}
