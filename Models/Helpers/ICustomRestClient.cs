using RestSharp;

namespace Models.Helpers
{
    public interface ICustomRestClient
    {

        RestResponse<T> Execute<T>(RestRequest request) where T : new();
        Task<RestResponse> ExecuteAsync(ICustomRestClient request);
    }
}
