using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using AI.UtilityAI;
using Unity.VisualScripting;
using Action = AI.UtilityAI.Action;

namespace AI.Core
{
    public class AiController : MonoBehaviour
    {
        private Animator _animator;
        public Stats stats { get; set; }
        public MoveController MoveController { get; set; }
        public AiBrain AiBrain { get; set; }
        public Action[] actionsAvailable;

        private Collider _rightHandCollider;
        private Collider _leftHandCollider;
        private Collider _rightElbowCollider;
        private Collider _leftElbowCollider;
        private Collider _leftFootCollider;
        private Collider _rightFootCollider;
        
        private int _isPunchingHash;
        private int _isKickingHash;
        private int _isWalkingHash;
        private int _specialMove1Hash;
        private int _specialMove2Hash;
        private int _isBlockingHash;
        private int _isDodgingHash;

        private bool _isBlocking;
        private float _damagePower;
        private bool _canAttack;
        private bool _targetInRange;

        public bool CanAttack
        {
            get { return _canAttack; }
            set { _canAttack = value; }
        }

        public bool TargetInRange
        {
            get { return _targetInRange; }
            set { _targetInRange = value; }
        }
        
        private void Start()
        {
            MoveController = GetComponent<MoveController>();
            AiBrain = GetComponent<AiBrain>();
            _animator = GetComponent<Animator>();
            stats = GetComponent<Stats>();
            
            //Set Collider components to variables
            _rightHandCollider = GameObject.FindGameObjectWithTag("E_RightHand").GetComponent<Collider>();
            _leftHandCollider = GameObject.FindGameObjectWithTag("E_LeftHand").GetComponent<Collider>();
            _rightElbowCollider = GameObject.FindGameObjectWithTag("E_RightElbow").GetComponent<Collider>();
            _leftElbowCollider = GameObject.FindGameObjectWithTag(("E_LeftElbow")).GetComponent<Collider>();
            _rightFootCollider = GameObject.FindGameObjectWithTag("E_RightFoot").GetComponent<Collider>();
            _leftFootCollider = GameObject.FindGameObjectWithTag("E_LeftFoot").GetComponent<Collider>();
            
            //Set Hash optimizers to animator parameters
            _isPunchingHash = Animator.StringToHash("Punching");
            _isKickingHash = Animator.StringToHash("Kicking");
            _isWalkingHash = Animator.StringToHash("Walking");
            _specialMove1Hash = Animator.StringToHash("SpecialMove1");
            _specialMove2Hash = Animator.StringToHash("SpecialMove2");
            _isBlockingHash = Animator.StringToHash("Blocking");
            _isDodgingHash = Animator.StringToHash("Dodging");
        }

        private void Update()
        {
            HandleAnimations();
            if (AiBrain.FinishedDeciding)
            {
                AiBrain.FinishedDeciding = false;
                AiBrain.BestAction.Execute(this);
            }
        }

        private void HandleAnimations()
        {
            _animator.SetBool(_isBlockingHash, _isBlocking);
        }

        public void Punch()
        {
            Debug.Log("Punched");
            _animator.SetTrigger(_isPunchingHash);
            _rightHandCollider.enabled = true;
        }

        public void Kick()
        {
            Debug.Log("Kicked");
            _animator.SetTrigger(_isKickingHash);
            _rightFootCollider.enabled = true;
            _leftFootCollider.enabled = true;
        }

        public void UpperCut()
        {
            Debug.Log("upper cut complete");
            _animator.SetTrigger(_specialMove1Hash);
            _rightHandCollider.enabled = true;
            _leftHandCollider.enabled = true;
        }

        public void ElbowSmash()
        {
            Debug.Log("Elbow smash complete");
            _animator.SetTrigger(_specialMove2Hash);
            _rightElbowCollider.enabled = true;
            _leftElbowCollider.enabled = true;
        }

        public void Block()
        {
            Debug.Log("Blocked");
            _isBlocking = true;
            StartCoroutine(BlockTime());
        }

        public void Dodge()
        {
            Debug.Log("Dodged");
            _animator.SetTrigger(_isDodgingHash);
        }

        public void AttackColliderDisable()
        {
            _rightHandCollider.enabled = false;
            _leftHandCollider.enabled = false;
            _rightElbowCollider.enabled = false;
            _leftElbowCollider.enabled = false;
            _rightFootCollider.enabled = false;
            _leftFootCollider.enabled = true;
        }

        public void TakeDamage(float damageAmount)
        {
            Debug.Log(stats.Health);
            switch (damageAmount, _isBlocking)
            {
                case (5, false):
                    stats.Health -= damageAmount;
                    break;
                case (5, true):
                    stats.Health = stats.Health;
                    break;
                case(10, false):
                    stats.Health -= damageAmount;
                    break;
                case(10, true):
                    stats.Health -= damageAmount * 25 / 100;
                    break;
                case (15, false):
                    stats.Health -= damageAmount;
                    break;
                case (15, true):
                    stats.Health -= damageAmount * 75 / 100;
                    break;
            }
        }

        private IEnumerator BlockTime()
        {
            yield return new WaitForSeconds(3);
            _isBlocking = false;
        }
    }
}
