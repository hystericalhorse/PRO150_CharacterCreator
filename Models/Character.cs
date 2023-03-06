using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Models
{
    public class Character
    {
        public Character() { }

        [Key]
        public int CharacterID { get; set; }
		[Required]
        public int PlayerID { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;

        public uint Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string? Backstory { get; set; }
		[Required]
		public uint FatePoints { get; set; } = 1;

		[Required]
		public AttributeObject brawnAtt { get; set; } = new("Brawn");
		[Required]
		public AttributeObject finesseAtt { get; set; } = new("Finesse");
		[Required]
		public AttributeObject toughAtt { get; set; } = new("Toughness");
		[Required]
		public AttributeObject intellectAtt { get; set; } = new("Intellect");
		[Required]
		public AttributeObject personAtt { get; set; } = new("Personality");
		[Required]
		public AttributeObject acuityAtt { get; set; } = new("Acuity");

		[Required]
		public QualityObject Quality { get; set; } = new QualityObject();

        public List<SkillObject> CharacterSkills { get; set; } = new List<SkillObject>();
        public List<SkillObject> TempSkills { get; set; } = new List<SkillObject>();
    }
}
