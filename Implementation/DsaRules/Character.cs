using DsaRules.GeneralRules;

namespace DsaRules
{
    public class Character
    {
        #region Attributes

        /// <summary>
        /// Is a measure of the hero’s bravery and determination. Higher values represent a greater ability to resist magical spells 
        /// and liturgical chants, and to stand tall in the face of danger. Courage is also a component of faith, 
        /// because it makes it possible to believe in that which cannot be seen, despite what others may think or say.
        /// </summary>
        public int Courage { get; private set; }

        /// <summary>
        /// Represents general knowledge, the ability to think logically and analytically, and the quality of the hero’s memory.
        /// </summary>
        public int Sagacity { get; private set; }

        

        /// <summary>
        /// Represents the hero’s hunches and level of empathy, and also shows how well the character can cope with stress and make the right decisions in such situations. 
        /// Knowing how to guide others is also a function of Intuition.
        /// </summary>
        public int Intuition { get; private set; }

        /// <summary>
        /// Includes personal magnetism, charm, and persuasiveness. You can sometimes derive a hero’s physical attractiveness 
        /// from Charisma, but it is not a specific indicator of good or bad looks. Someone who is not noted for physical appearance can still 
        /// be thought very attractive, and there are real beauties that seem to have no charisma at all.
        /// </summary>
        public int Charisma { get; private set; }

        /// <summary>
        /// Measures the nimbleness of a hero’s fingers and overall hand-eye coordination. This attribute reflects how well 
        /// the character can use lock picks, practice crafts, or shoot a bow.
        /// </summary>
        public int Dexterity { get; private set; }

        /// <summary>
        /// Measures the hero’s bodily finesse, reflexes, reaction speed, and flexibility.
        /// </summary>
        public int Agility  { get; private set; }

        /// <summary>
        /// Represents a hero’s stamina. Higher values grant more life points and greater resistance to poisons and diseases.
        /// </summary>
        public int Constitution { get; private set; }

        /// <summary>
        /// Represents raw muscle power and how well a character can use muscles to good effect.
        /// </summary>
        public int Strength { get; private set; }

        public int GetAttributeValue(Attributes attribute)
        {
            var attributeValue = 0;
            if (attribute == Attributes.Courage)
            {
                attributeValue = Courage;
            }

            if (attribute == Attributes.Charisma)
            {
                attributeValue = Charisma;
            }

            if(attribute == Attributes.Dexterity)
            {
                attributeValue = Dexterity;
            }

            if(attribute == Attributes.Agility)
            {
                attributeValue = Agility;
            }

            if(attribute == Attributes.Constitution)
            {
                attributeValue = Constitution;
            }

            if(attribute == Attributes.Strength)
            {
                attributeValue = Strength;
            }

            if(attribute == Attributes.Sagacity)
            {
               attributeValue = Sagacity;
            }

            if(attribute == Attributes.Intuition)
            {
                attributeValue = Intuition;
            }

            return attributeValue;
        }


        public Character WithCourage(int courageValue)
        {
            this.Courage = courageValue;
            return this;
        }

        public Character WithSagacity(int sagacityValue)
        {
            this.Sagacity = sagacityValue;
            return this;
        }

        public Character WithIntuition(int intuitionValue)
        {
            this.Intuition = intuitionValue;
            return this;
        }

        public Character WithCharisma(int charismaValue)
        {
            this.Charisma = charismaValue;
            return this;
        }

        public Character WithDexterity(int dexterityValue)
        {
            this.Dexterity = dexterityValue;
            return this;
        }

        public Character WithAgility(int agilityValue)
        {
            this.Agility = agilityValue;
            return this;
        }

        public Character WithConstitution(int constitutionValue)
        {
            this.Constitution = constitutionValue;
            return this;
        }

        public Character WithStrength(int strengthValue)
        {
            this.Strength = strengthValue;
            return this;
        }

        #endregion

        
    }
}