using System.Collections;
using System.Collections.Generic;
using AI.Core;
using UnityEngine;
using AI.UtilityAI;

namespace AI.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Kick", menuName = "UtilityAI/Actions/Kick")]
    public class Kick : Action
    {
        public override void Execute(AiController aiController)
        {
            aiController.Kick();
        }
    }
}