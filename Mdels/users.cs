using System.ComponentModel.DataAnnotations;

namespace DapperCrudApi.Mdels
{
    public class users
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Delflag { get; set; }
        public string? Address { get; set; }
        public string? role { get; set; }

    }
}
