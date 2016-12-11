using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Catalogo.Services;
using Catalogo.ViewModels;

namespace Catalogo.Test
{
    [TestClass]
    public class TestWebService
    {
        [TestMethod]
        public async Task TestPost()
        {
            Assert.IsNotNull(await new HttpService().PostAsync<RootObject>("post", new RootObject
            {
                Id = 1,
                UserId = 2,
                Body = "corpo",
                Title = "titulo"
            }));
        }

        [TestMethod]
        public async Task TestProdutos()
        {
            var teste = await new HttpService().GetAsync<List<Produto>>("W7tdL7NU");
            Assert.IsNotNull(teste);
        }

        [TestMethod]
        public async Task TestCategorias()
        {
            var teste = await new HttpService().GetAsync<List<Categoria>>("YNR2rsWe");
            Assert.IsNotNull(teste);
        }
    }

    public class RootObject
    {
        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }
    }
}
