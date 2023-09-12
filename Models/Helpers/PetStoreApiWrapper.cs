using Microsoft.AspNetCore.Mvc;
using Models.Classes;
using RestSharp;

namespace Models.Helpers
{
    public class PetStoreApiWrapper
    {
        private RestClient _client;
        private ICustomRestClient _client_mq;

        private readonly string _baseUrl = "https://petstore.swagger.io/v2";

        public PetStoreApiWrapper(ICustomRestClient restClient)
        {
            _client = new RestClient(_baseUrl);
            _client_mq = restClient;
        }

        public void CreatePet(Pet pet)
        {
            var request = new RestRequest("/pet", Method.Post);
            request.AddJsonBody(pet);
            _client.Execute(request);
        }


        public Pet GetPetById(long petId)
        {
            var request = new RestRequest($"/pet/{petId}", Method.Get);
            var response = _client.Execute<Pet>(request);
            return response.Data;
        }

        public async Task<Pet> GetPetByIdAsync(long petId)
        {
            var request = new RestRequest($"/pet/{petId}", Method.Get);
            var response = _client.Execute<Pet>(request);
            return response.Data;
        }

        public void SetRestClient(ICustomRestClient restClient)
        {
            _client = (RestClient)restClient;
        }

    }
}