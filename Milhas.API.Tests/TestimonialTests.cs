using System.Net;

namespace Milhas.API.Tests
{
    public class TestimonialTests
    {
        private readonly HttpClient _client;

        public TestimonialTests()
        {
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri("https://localhost:5001");
        }

        [Fact]
        public async Task TestGet()
        {
            var response = await _client.GetAsync("/api/testimonial");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestGetById()
        {
            var response = await _client.GetAsync("/api/testimonial/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestGetRandomTestimonials()
        {
            var response = await _client.GetAsync("/api/testimonial/depoimentos-home");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestPost()
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent("Nome"), "Name");
            content.Add(new StringContent("Depoimento"), "Testimony");
            content.Add(new ByteArrayContent(new byte[0]), "Image", "image.jpg");

            var response = await _client.PostAsync("/api/testimonial", content);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task TestPut()
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent("Nome atualizado"), "Name");
            content.Add(new StringContent("Depoimento atualizado"), "Testimony");

            var response = await _client.PutAsync("/api/testimonial/1", content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestDelete()
        {
            var response = await _client.DeleteAsync("/api/testimonial/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}