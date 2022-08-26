using System.Collections;
using System.Collections.Generic;
using AI.Core;
using UnityEngine;

namespace AI.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Block", menuName = "UtilityAI/Actions/Block")]
    public class Block : Action
    {
        public override void Execute(AiController aiController)
        {
            aiController.Block();
        }
    }
}