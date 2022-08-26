using System;
using System.Collections;
using System.Collections.Generic;
using AI.Core;
using UnityEngine;
using AI.Core;

namespace AI.UtilityAI
{
    public abstract class Action : ScriptableObject
    {
        public string name;
        private float _score;
        
        public float Score
        {
            get { return _score; }
            set => this._score = Mathf.Clamp01(value);
        }
        public Consideration[] considerations;

        public void Awake()
        {
            Score = 0;
        }

        public abstract void Execute(AiController aiController);
    }
}
