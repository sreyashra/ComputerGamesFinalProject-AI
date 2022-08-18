using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Core;

namespace  AI.UtilityTheory
{
    public class AIBrain : MonoBehaviour
    {
        public Action BestAction { get; set; }
        private AIController _aiController;
        
        // Start is called before the first frame update
        void Start()
        {
            _aiController = GetComponent<AIController>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        //Loop through all available action and give the highest scoring action
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
        }

        //Loop through all the consideration of action, score the considerations and average the consideration scores ==> overall action score
        public float ScoreAction(Action action)
        {
            float score = 1f;
            for (int i = 0; i < action.considerations.Length; i++)
            {
                float considerationScore = action.considerations[i].ScoreConsideration();
                score *= considerationScore;

                if (score ==0)
                {
                    action.Score = 0;
                    return action.Score;
                }
            }
            
            //Averaging of overall score
            float originalScore = score;
            float modFactor = 1 - (1 / action.considerations.Length);
            float makeupValue = (1 - originalScore) * modFactor;
            action.Score = originalScore + (makeupValue * originalScore);

            return action.Score;
        }
    }
}
