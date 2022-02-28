using SQLite;

namespace Register_in_massage
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string SecName { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
