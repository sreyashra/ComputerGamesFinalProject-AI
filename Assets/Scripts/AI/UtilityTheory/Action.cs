using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace  AI.UtilityTheory
{
    public abstract class Action : ScriptableObject
    {
        public string actionName;
        private float _score;

        public float Score
        {
            get { return _score; }
            set { this._score = Mathf.Clamp01(value); }
        }

        public Consideration[] considerations;

        public void Awake()
        {
            Score = 0;
        }

        public abstract void Execute();
    }
}
