using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Core
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Animator _animator;

        private float _walkSpeed = 0f;
        public float WalkSpeed
        {
            get { return _walkSpeed;}
            //set { value = this; } 
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }
    }
}
