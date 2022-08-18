using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.UtilityTheory
{
    public abstract class Consideration : ScriptableObject
    {
        public string considerationName;
        private float _score;

        public float Score
        {
            get { return _score; }
            set { this._score = Mathf.Clamp01(value); }
        }

        public void Awake()
        {
            Score = 0;
        }

        public abstract float ScoreConsideration();
    }
}
