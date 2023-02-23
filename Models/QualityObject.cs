﻿using System.Reflection.Metadata.Ecma335;

namespace CharacterCreator.Models
{
    public class QualityObject
    {

        public string QualityName { get; set; } = string.Empty;
        public string QualityDescription { get; set; } = string.Empty;
    }

    public class SkillQuality : QualityObject
    {
        public List<SkillObject> QualitySkills { get; set; } = new List<SkillObject>();
    }

    public class AttributeQuality : QualityObject
    {
        public AttributeObject StrongAttribute { get; set; } = new AttributeObject();
        public AttributeObject WeakAttribute { get; set; } = new AttributeObject();
    }

    public class LuckQuality : QualityObject
    {
        public bool NoLuck { get; set; } = false;
        public int LuckModifier { get; set; } = 0;
    }

}
