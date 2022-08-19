using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Core
{
    public class PlayerMovement : MonoBehaviour
    {
        //references to components
        private Animator _animator;
        private PlayerInputActions _input;
        private CharacterController _characterController;
        
        //Variables to store optimized getter/setter parameter ID
        private int _isPunchingHash;
        private int _isKickingHash;
        private int _isWalkingHash;
        private int _specialMove1Hash;
        private int _specialMove2Hash;
        private int _isBlockingHash;
        private int _isDodgingHash;

        [SerializeField] private float moveSpeed = 0f;
        private Vector2 _currentMovementInput;
        private Vector3 _currentMovement;
        private bool _isMovementPressed;
        private bool _isBlocking;

        private void Awake()
        {
            _input = new PlayerInputActions();
            _input.Player.Movement.started += OnMoveInput;
            _input.Player.Movement.performed += OnMoveInput;
            _input.Player.Movement.canceled += OnMoveInput;
            _input.Player.Punch.performed += Punch;
            _input.Player.Kick.performed += Kick;
            _input.Player.SpecialMove1.performed += SpecialMove1;
            _input.Player.SpecialMove2.performed += SpecialMove2;
            _input.Player.Block.started += Block;
            _input.Player.Block.performed += Block;
            _input.Player.Block.canceled += Block;
            _input.Player.Dodge.performed += Dodge;
        }

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
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
            _characterController.Move(_currentMovement * (moveSpeed * Time.deltaTime));
            HandleAnimations();
            HandleGravity();
        }

        void HandleAnimations()
        {
            _animator.SetFloat(_isWalkingHash, _currentMovementInput.x);
            _animator.SetBool(_isBlockingHash, _isBlocking);
        }

        private void HandleGravity()
        {
            if (_characterController.isGrounded)
            {
                float groundedGravity = -0.5f;
                _currentMovement.y = groundedGravity;
            }
            else
            {
                float gravity = -9.8f;
                _currentMovement.y += gravity;
            }
        }

        private void OnMoveInput(InputAction.CallbackContext ctx)
        {
            _currentMovementInput = ctx.ReadValue<Vector2>();
            _currentMovement.x = _currentMovementInput.x;
            _isMovementPressed = _currentMovementInput.x != 0;
        }

        private void Punch(InputAction.CallbackContext ctx)
        {
            Debug.Log("Punch");
            _animator.SetTrigger(_isPunchingHash);
        }

        private void Kick(InputAction.CallbackContext ctx)
        {
            Debug.Log("Kick");
            _animator.SetTrigger(_isKickingHash);
        }

        private void SpecialMove1(InputAction.CallbackContext ctx)
        {
            Debug.Log("Special Move 1");
            _animator.SetTrigger(_specialMove1Hash);
        }

        private void SpecialMove2(InputAction.CallbackContext ctx)
        {
            Debug.Log("Special Move 2");
            _animator.SetTrigger(_specialMove2Hash);
        }

        private void Block(InputAction.CallbackContext ctx)
        {
            Debug.Log("Block");
            if (ctx.canceled)
            {
                _isBlocking = false;
            }
            else
            {
                _isBlocking = true;
            }
        }

        private void Dodge(InputAction.CallbackContext ctx)
        {
            Debug.Log("Dodge");
            _animator.SetTrigger(_isDodgingHash);
        }

        #region Enable and Disable Methods

        private void OnEnable()
        {
            _input.Player.Enable();
        }

        private void OnDisable()
        {
            _input.Player.Disable();
        }

        #endregion
    }
}
