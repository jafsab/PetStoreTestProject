namespace PetStoreTestProject
{
    using Moq;
    using NUnit.Framework;
    using RestSharp;
    using System.Net;
    using Models.Classes;
    using Models.Helpers;

    public class PetStoreAPITests
    {
        private RestClient _client;
        private PetStoreApiWrapper _client2;
        private string _baseUrl = "https://petstore.swagger.io/v2";

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(_baseUrl);
            _client2 = new PetStoreApiWrapper(null);
        }

        /// <summary>
        /// AddNewPet PositiveTest
        /// 
        /// </summary>
        [Test]
        public void AddNewPet_PositiveTest()
        {
            string jsonData = @"
            {
                ""id"": 0,
                ""category"": {
                    ""id"": 0,
                    ""name"": ""string""
                },
                ""name"": ""my lovely doggie"",
                ""photoUrls"": [""string""],
                ""tags"": [
                    {
                        ""id"": 0,
                        ""name"": ""string""
                    }
                ],
                ""status"": ""available""
            }";

            // Arrange: Prepare the request
            var request = new RestRequest("/pet", Method.Post);
            request.AddJsonBody(jsonData);

            // Execute the request
            var response = _client.Execute(request);

            // Assert: Verify the response code OK
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task GetPetByIdTest()
        {
            // Arrange
            long petId = 10;

            // Act

            var pet = await _client2.GetPetByIdAsync(petId);

            // Assert
            Assert.IsNotNull(pet);
            Assert.AreEqual(petId, pet.Id);
        }

        [Test]
        public async Task GetPetInfo_ValidPetId_ReturnsPetInfo()
        {
            // Arrange
            var mockRestClient = new Mock<ICustomRestClient>();
            var wrapper = new PetStoreApiWrapper(mockRestClient.Object);

            // Configure the mock to return a successful response
            var successfulResponse = new RestResponse
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = "{'Id': 10, 'name': 'Buddy'}"
            };
            mockRestClient.Setup(client => client.ExecuteAsync(It.IsAny<ICustomRestClient>()))
                .ReturnsAsync(successfulResponse);

            // Act
            var petInfo = await wrapper.GetPetByIdAsync(10);

            // Assert
            Assert.AreEqual(10, petInfo.Id);
        }

        [Test]
        public void CreatePet_WhenCalled_ShouldMakePostRequest()
        {
            // Arrange
            var mockRestClient = new Mock<ICustomRestClient>();
            var wrapper = new PetStoreApiWrapper(mockRestClient.Object);

            var pet = new Pet
            {
                Id = 0,
                Name = "Mq Dogie"
            };
            //var expectedRequest = It.Is<RestClient>(r => r.Method == Method.Post);

            // Act
            wrapper.CreatePet(pet);

            // Assert
            //mockRestClient.Verify(c => c.Execute(It.Is<ICustomRestClient>(r => r.Method == Method.Post)), Times.Once);
            //mockRestClient.Verify(c => c.ExecuteAsync(expectedRequest, CancellationToken.None), Times.Once);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up resources if needed
            _client.Dispose();
        }
    }
}