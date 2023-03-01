using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Models
{
    public class AttributeObject
    {
		[Key]
		public int AttributeID { get; set; }

        public AttributeObject() { }
        public AttributeObject(string name, int score = 0, int bonus = 0)
        {
            this.AttributeName = name;
            this.Score = (AttributeScore) score;
            this.AttributeBonus = bonus;
        }

		public enum AttributeScore
        {
            NEUTRAL, STRONG, WEAK
        }

        public string AttributeName { get; set; } = string.Empty;

        public AttributeScore Score { get; set; } = AttributeScore.NEUTRAL;
        public int AttributeBonus { get; set; } = 0;
    }
}
