using Newtonsoft.Json;
using SQLite;

namespace Catalogo.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [PrimaryKey, AutoIncrement]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}