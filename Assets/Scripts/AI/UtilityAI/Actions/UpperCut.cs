using System.Collections;
using System.Collections.Generic;
using AI.Core;
using UnityEngine;

namespace AI.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "UpperCut", menuName = "UtilityAI/Actions/UpperCut")]
    public class UpperCut : Action
    {
        public override void Execute(AiController aiController)
        {
            aiController.UpperCut();
        }
    }
}