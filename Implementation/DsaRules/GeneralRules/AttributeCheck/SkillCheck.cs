using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaRules.GeneralRules.AttributeCheck
{
    public class SkillCheck
    {
        public int SkillValue { get; set; }
        public Check FirstCheck { get; set; }
        public Check SecondCheck { get; set; }
        public Check ThirdCheck { get; set; }

        public RoleResultType? CheckResultType
        {
            get
            {
                if(FirstCheck != null && SecondCheck != null && ThirdCheck != null) 
                {
                    if ((FirstCheck.CheckResultType == RoleResultType.EpicFail &&
                       SecondCheck.CheckResultType == RoleResultType.EpicFail) ||
                       (FirstCheck.CheckResultType == RoleResultType.EpicFail &&
                       ThirdCheck.CheckResultType == RoleResultType.EpicFail) ||
                       (SecondCheck.CheckResultType == RoleResultType.EpicFail &&
                       ThirdCheck.CheckResultType == RoleResultType.EpicFail))
                    {
                        return RoleResultType.EpicFail;
                    }

                    if ((FirstCheck.CheckResultType == RoleResultType.EpicSuccess &&
                      SecondCheck.CheckResultType == RoleResultType.EpicSuccess) ||
                      (FirstCheck.CheckResultType == RoleResultType.EpicSuccess &&
                      ThirdCheck.CheckResultType == RoleResultType.EpicSuccess) ||
                      (SecondCheck.CheckResultType == RoleResultType.EpicSuccess &&
                      ThirdCheck.CheckResultType == RoleResultType.EpicSuccess))
                    {
                        return RoleResultType.EpicSuccess;
                    }

                    if (FirstCheck.CheckResultType == RoleResultType.Success &&
                        SecondCheck.CheckResultType == RoleResultType.Success &&
                        ThirdCheck.CheckResultType == RoleResultType.Success)
                    {
                        return RoleResultType.Success;
                    }

                    if (FirstCheck.CheckResultType == RoleResultType.Fail ||
                       SecondCheck.CheckResultType == RoleResultType.Fail ||
                       ThirdCheck.CheckResultType == RoleResultType.Fail)
                    {
                        return RoleResultType.Fail;
                    }

                    


                }
                return null;
            }

        }
        public int? ResultValue
        {
            get
            {
                var summarizedResultValue = 0;
                if (FirstCheck.RoleHistory != null && FirstCheck.RoleHistory.Count != 0)
                {
                    summarizedResultValue += FirstCheck.ResultValue;
                }

                if (SecondCheck.RoleHistory != null && SecondCheck.RoleHistory.Count != 0)
                {
                    summarizedResultValue += SecondCheck.ResultValue;
                }

                if (ThirdCheck.RoleHistory != null && ThirdCheck.RoleHistory.Count != 0)
                {
                    summarizedResultValue += ThirdCheck.ResultValue;
                }

                if(SkillValue < summarizedResultValue)
                {
                    return SkillValue;
                }

                return summarizedResultValue;
            }

        }
    }
}
