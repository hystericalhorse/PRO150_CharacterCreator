using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Models
{
    public class SkillObject
    {
		[Key]
		public int SkillID { get; set; }

		public SkillObject() { }
		public SkillObject(string name, string description)
		{
			SkillName = name;
			SkillDescription = description;
		}

		public string SkillName { get; set; } = string.Empty;
		public string SkillDescription { get; set; } = string.Empty;
	}
}
