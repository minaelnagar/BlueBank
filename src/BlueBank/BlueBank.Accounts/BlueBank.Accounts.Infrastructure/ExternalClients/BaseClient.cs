using RestSharp;
using System.Threading.Tasks;

namespace BlueBank.Accounts.Infrastructure.ExternalClients
{
    public class BaseClient
    {
        private RestClient _restClient;

        public BaseClient(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        protected async Task<IRestResponse<T>> PostAsync<T>(object body, string resource)
        {
            RestRequest r = new RestRequest(Method.POST);
            r.AddJsonBody(body);
            r.Resource = resource;

            return await _restClient.ExecutePostAsync<T>(r);
        }

        protected async Task<IRestResponse<T>> GetAsync<T>(object body, string resource)
        {
            RestRequest r = new RestRequest(Method.GET);

            if (body != null)
            {
                r.AddObject(body);
            }
            r.Resource = resource;

            return await _restClient.ExecuteGetAsync<T>(r);
        }
    }
}
