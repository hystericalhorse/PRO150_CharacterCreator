using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Models
{

    public class QualityObject
    {
        [Key]
        public int QualityID { get; set; }

        public string QualityName { get; set; } = string.Empty;
        public string QualityDescription { get; set; } = string.Empty;
    }

    public class SkillQuality : QualityObject
    {
        public List<SkillObject> QualitySkills { get; set; } = new List<SkillObject>();
    }

    // Qualities which modify attributes will have their own behavior defined within controllers and views.

    // Qualities which modify variables like Fate will have their own behavior defined within controllers and views.

}
