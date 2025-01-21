namespace Portfolio.PostgresSQL.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public string Position { get; set; }
        public int JerseyNumber { get; set; }
    }
}
