using System;
using System.Collections;
using System.Collections.Generic;
using AI.Core;
using UnityEngine;

namespace AI.UtilityAI
{
    public class AiBrain : MonoBehaviour
    {
        private AiController _aiController;
        public Action BestAction { get; set; }
        public bool FinishedDeciding { get; set; }

        private void Start()
        {
            _aiController = GetComponent<AiController>();
        }

        private void Update()
        {
            if (BestAction is null)
            {
                DecideBestAction(_aiController.actionsAvailable);
            }
        }

        public void DecideBestAction(Action[] actionsAvailable)
        {
            float score = 0f;
            int nextBestActionIndex = 0;
            for (int i = 0; i < actionsAvailable.Length; i++)
            {
                if (ScoreAction(actionsAvailable[i]) > score)
                {
                    nextBestActionIndex = i;
                    score = actionsAvailable[i].Score;
                }
            }

            BestAction = actionsAvailable[nextBestActionIndex];
            FinishedDeciding = true;
        }

        public float ScoreAction(Action action)
        {
            float score = 1f;
            for (int i = 0; i < action.considerations.Length; i++)
            {
                float considerationScore = action.considerations[i].ScoreConsideration(_aiController);
                score *= considerationScore;

                if (score == 0)
                {
                    action.Score = 0;
                    return action.Score;
                }
            }
            
            //Average overall score
            float originalScore = score;
            float modificationFactor = 1 - (1 / action.considerations.Length);
            float makeUpValue = (1 - originalScore) * modificationFactor;
            action.Score = originalScore + (makeUpValue * originalScore);

            return action.Score;
        }
    }
}
