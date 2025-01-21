namespace Portfolio.PostgresSQL.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public ICollection<Player> Players { get; set; } = [];
        public ICollection<Coach> Coaches { get; set; } = [];
    }
}
