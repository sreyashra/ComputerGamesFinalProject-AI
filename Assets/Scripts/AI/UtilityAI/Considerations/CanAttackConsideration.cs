using System;
using System.Collections;
using System.Collections.Generic;
using AI.Core;
using UnityEngine;

namespace AI.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "CanAttackConsideration", menuName = "UtilityAI/Considerations/CanAttackConsideration")]
    public class CanAttackConsideration : Consideration
    {
        [SerializeField]private bool invertResponse = false;
        
        public override float ScoreConsideration(AiController aiController)
        {
            if (aiController.CanAttack)
            {
                Score = Response(invertResponse, true);
            }
            else
            {
                Score = Response(invertResponse, false);
            }
            return Score;
        }

        private float Response(bool itnvertResponse, bool defaultValue)
        {
            if (invertResponse)
            {
                return Convert.ToInt32(!defaultValue);
            }

            return Convert.ToInt32(defaultValue);
        }
    }
}
