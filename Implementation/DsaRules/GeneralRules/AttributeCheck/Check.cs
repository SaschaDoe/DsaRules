using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaRules.GeneralRules
{
    /// <summary>
    /// Checks are sometimes more then one role of a dice, so they have a role history
    /// </summary>
    public class Check
    {

        public RoleHistory RoleHistory { get; set; }

        public Check()
        {
            RoleHistory = new RoleHistory();
        }

        public RoleResultType CheckResultType { get; set; }
        public int ResultValue 
        {
            get
            {
                if (RoleHistory == null || RoleHistory.Count == 0)
                {
                    return 0;
                }

                return RoleHistory[0].Result;
            }
                
        }
    }
}
