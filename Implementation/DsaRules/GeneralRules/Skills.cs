using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaRules.GeneralRules
{
    public enum Skills
    {
        Alchemy,
    }
    public class SkillMapping
    {
        Dictionary<Skills, (Attributes, Attributes, Attributes)> SkillAttributeMapping = new()
        {
            { Skills.Alchemy, (Attributes.Courage, Attributes.Sagacity, Attributes.Dexterity) },
        };
    }
}
