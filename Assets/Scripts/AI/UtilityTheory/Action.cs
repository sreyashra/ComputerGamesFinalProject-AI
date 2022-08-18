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

        public float score
        {
            get { return _score; }
            set { this._score = Mathf.Clamp01(value); }
        }

        public Consideration[] considerations;

        public void Awake()
        {
            score = 0;
        }

        public abstract void Execute();
    }
}
