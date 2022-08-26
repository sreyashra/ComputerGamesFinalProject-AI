using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Core
{
    public class Stats : MonoBehaviour
    {
        private float _health, _maxHealth = 100f;

        public float Health
        {
            get { return _health; }
            set => _health = value;
        }

        private float _damagePower = 0;

        public float DamagePower
        {
            get { return _damagePower; }
            set => _damagePower = value;
        }

        private void Start()
        {
            Debug.Log(Health);
            Health = _maxHealth;
        }
    }
}