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
		public string Name { get; set; } = "Unnamed Character";
		public string UserID { get; set; }

        public uint Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string? Backstory { get; set; }
		[Required]
		public uint FatePoints { get; set; } = 1;

		[Required]
		public AttributeScore brawnAtt { get; set; } = 0;
		public int brawnBonus { get; set; } = 0;
		[Required]
		public AttributeScore finesseAtt { get; set; } = 0;
		public int finesseBonus { get; set; } = 0;
		[Required]
		public AttributeScore toughAtt { get; set; } = 0;
		public int toughBonus { get; set; } = 0;
		[Required]
		public AttributeScore intellectAtt { get; set; } = 0;
		public int intellectBonus { get; set; } = 0;
		[Required]
		public AttributeScore personAtt { get; set; } = 0;
		public int personBonus { get; set; } = 0;
		[Required]
		public AttributeScore acuityAtt { get; set; } = 0;
		public int acuityBonus { get; set; } = 0;

		[Required]
		public QualityObject Quality { get; set; } = new QualityObject();

        public List<SkillObject> CharacterSkills { get; set; } = new List<SkillObject>();
        public List<SkillObject> TempSkills { get; set; } = new List<SkillObject>();
    }

	public enum AttributeScore { Neutral = 0, Strong = 1, Weak = 2 }

}
