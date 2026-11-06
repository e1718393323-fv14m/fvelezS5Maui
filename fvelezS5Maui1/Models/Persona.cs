using SQLite;

namespace fvelezS5Maui1.Models
{
    [Table("persona")]
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(25), Unique]
        public string Nombre { get; set; } = string.Empty;
    }
}
