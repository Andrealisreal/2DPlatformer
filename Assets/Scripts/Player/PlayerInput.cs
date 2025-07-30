using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public event UnityAction JumpClicked;
        public event UnityAction MovementClicked;
        public event UnityAction MovementCanceled;
        
        public Vector2 Movement => _inputAction.Player.Movement.ReadValue<Vector2>();
        
        private PlayerInputAction _inputAction;

        private void Awake()
        {
            _inputAction = new PlayerInputAction();

            _inputAction.Player.Jump.performed += Jump;
            _inputAction.Player.Movement.performed += Move;
            _inputAction.Player.Movement.canceled += Stand;
        }

        private void OnEnable()
        {
            _inputAction.Enable();
        }

        private void OnDisable()
        {
            _inputAction.Disable();
        }

        private void Jump(InputAction.CallbackContext context)
        {
            JumpClicked?.Invoke();
        }
        
        private void Move(InputAction.CallbackContext context)
        {
            MovementClicked?.Invoke();
        }

        private void Stand(InputAction.CallbackContext context)
        {
            MovementCanceled?.Invoke();
        }
    }
}
