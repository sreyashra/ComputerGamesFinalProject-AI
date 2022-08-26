using System.Collections;
using System.Collections.Generic;
using AI.Core;
using UnityEngine;

namespace AI.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Dodge", menuName = "UtilityAI/Actions/Dodge")]
    public class Dodge : Action
    {
        public override void Execute(AiController aiController)
        {
            aiController.Dodge();
        }
    }
}
