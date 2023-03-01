using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Models
{
    public class Character
    {
        public Character() { }

        [Key]
        public int CharacterID { get; set; }

        public string Name { get; set; } = string.Empty;

        public uint Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string? Backstory { get; set; }

        public uint FatePoints { get; set; } = 1;

        public AttributeObject brawnAtt { get; set; } = new("Brawn");
        public AttributeObject finesseAtt { get; set; } = new("Finesse");
        public AttributeObject toughAtt { get; set; } = new("Toughness");
        public AttributeObject intellectAtt { get; set; } = new("Intellect");
        public AttributeObject personAtt { get; set; } = new("Personality");
        public AttributeObject acuityAtt { get; set; } = new("Acuity");

        public QualityObject Quality { get; set; } = new QualityObject();

        public List<SkillObject> CharacterSkills { get; set; } = new List<SkillObject>();
        public List<SkillObject> TempSkills { get; set; } = new List<SkillObject>();
    }
}
