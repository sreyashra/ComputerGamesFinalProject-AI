using System.Collections;
using System.Collections.Generic;
using AI.Core;
using UnityEngine;

namespace AI.UtilityAI.Considerations
{
    public class ElbowSmashRepeatConsideration : Consideration
    {
        public override float ScoreConsideration(AiController aiController)
        {
            return Score;
        }
    }
}