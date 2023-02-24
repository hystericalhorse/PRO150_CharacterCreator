namespace CharacterCreator.Models
{
    public class Character
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public uint Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string? Backstory { get; set; }

        public uint FatePoints { get; set; } = 1;

        public QualityObject Quality { get; set; } = new QualityObject();

        public List<SkillObject> CharacterSkills { get; set; } = new List<SkillObject>();
        public List<SkillObject> TempSkills { get; set; } = new List<SkillObject>();
    }
}
