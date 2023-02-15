namespace CharacterCreator.Models
{
    public class Character
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string? Backstory { get; set; }

    }
}
