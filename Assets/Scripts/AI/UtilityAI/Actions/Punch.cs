using System.Collections;
using System.Collections.Generic;
using AI.Core;
using AI.UtilityAI;
using UnityEngine;

namespace AI.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Punch", menuName = "UtilityAI/Actions/Punch")]
    public class Punch : Action
    {
        public override void Execute(AiController aiController)
        {
            aiController.Punch();
        }
    }
}
