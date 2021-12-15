using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaRules
{
    public class RoleResult
    {
        public int Result { get;private set; }
        public RoleResultType Type { get; private set; }

        public RoleResult(int result, RoleResultType tpye)
        {
            Result = result;
            Type = tpye;
        }
    }
}
