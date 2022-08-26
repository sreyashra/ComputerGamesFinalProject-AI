using System.Collections;
using System.Collections.Generic;
using AI.Core;
using UnityEngine;

namespace AI.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "ElbowSmash", menuName = "UtilityAI/Actions/ElbowSmash")]
    public class ElbowSmash : Action
    {
        public override void Execute(AiController aiController)
        {
            aiController.ElbowSmash();
        }
    }
}