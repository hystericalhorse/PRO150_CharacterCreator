namespace CharacterCreator.Models
{
    public class QualityObject
    {
        public string QualityName { get; set; } = string.Empty;
        public string QualityDescription { get; set; } = string.Empty;

        public List<SkillObject> QualitySkills { get; set; } = new List<SkillObject>();
    }
}
