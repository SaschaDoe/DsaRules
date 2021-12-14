using DsaRules.GeneralRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaRules
{
    public class GameMaster
    {
        private readonly Dice _twentySited;
        private readonly Dice _sixSited;

        public GameMaster(Dice twentySited, Dice sixSited)
        {
            this._twentySited = twentySited;
            this._sixSited = sixSited;
        }


        public RoleResult RoleFor(Character character, Attribute attribute, int modificator = 0)
        {
            
            var roleResult = AttributeCheckRule.Check(attribute, character, _twentySited.Role(), modificator); 

            return roleResult;
        }
    }
}
