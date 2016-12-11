using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using SQLite;

namespace Catalogo.Models
{
    [Table("Produto")]
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("category_id")]
        public int? CategoryId { get; set; }

        public bool IsFavorite { get; set; }

        [Ignore]
        public MvxCommand IsFavoriteChanged { get; set; }
    }
}