using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    [RequireComponent(typeof(Character))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputActionReference moveInput;
        [SerializeField] private InputActionReference jumpInput;
        [SerializeField] private float airborneSpeedMultiplier = .5f;
        //TODO: This booleans are not flexible enough. If we want to have a third jump or other things, it will become a hazzle.
        private bool _isJumping;
        private bool _isDoubleJumping;
        private Character _character;
        private Coroutine _jumpCoroutine;
        IState _currentState;
        public float GetairborneSpeedMultiplier()
        {
            return airborneSpeedMultiplier;
        }

        private void Awake()
        { _character = GetComponent<Character>();
            _currentState = new GroundState(_character, this);
          
          
        }
        public void ChangeState(IState state)
        {
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        private void OnEnable()
        {
            if (moveInput?.action != null)
            {
                moveInput.action.started += HandleMoveInput;
                moveInput.action.performed += HandleMoveInput;
                moveInput.action.canceled += HandleMoveInput;
            }
            if (jumpInput?.action != null)
                jumpInput.action.performed += HandleJumpInput;
        }
        private void OnDisable()
        {
            if (moveInput?.action != null)
            {
                moveInput.action.performed -= HandleMoveInput;
                moveInput.action.canceled -= HandleMoveInput;
            }
            if (jumpInput?.action != null)
                jumpInput.action.performed -= HandleJumpInput;
        }

        private void HandleMoveInput(InputAction.CallbackContext ctx)
        {
           _currentState.Walk(ctx.ReadValue<Vector2>());
        }

        private void HandleJumpInput(InputAction.CallbackContext ctx)
        {
            _currentState.Jump();
        }

        public void RunJumpCoroutine() 
        {
            if (_jumpCoroutine != null)
                StopCoroutine(_jumpCoroutine);
            _jumpCoroutine = StartCoroutine(_character.Jump());
        }

        private void OnCollisionEnter(Collision other)
        {
            _currentState.OnCollisionEnter(other);
        }   
    }
}
