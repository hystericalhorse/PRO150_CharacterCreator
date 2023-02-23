﻿namespace CharacterCreator.Models
{
    public class AttributeObject
    {
        public enum AttributeScore
        {
            NEUTRAL, STRONG, WEAK
        }

        public string AttributeName { get; set; } = string.Empty;

        public AttributeScore Score { get; set; } = AttributeScore.NEUTRAL;
        public int AttributeBonus { get; set; } = 0;
    }
}
