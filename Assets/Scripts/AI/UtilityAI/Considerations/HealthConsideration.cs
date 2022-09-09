using System.Collections;
using System.Collections.Generic;
using AI.Core;
using AI.UtilityAI;
using UnityEngine;

namespace AI.UtilityAI.Considerations
{
    [CreateAssetMenu(fileName = "HealthConsideration", menuName = "UtilityAI/Considerations/HealthConsideration")]
    public class HealthConsideration : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(AiController aiController)
        {
            Score = responseCurve.Evaluate(Mathf.Clamp01(aiController.stats.Health / 100f));
            return Score;
        }
    }
}