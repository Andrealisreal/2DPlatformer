using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public event UnityAction JumpClicked;
        
        public Vector2 Movement => _inputAction.Player.Movement.ReadValue<Vector2>();
        
        private PlayerInputAction _inputAction;

        private void Awake()
        {
            _inputAction = new PlayerInputAction();

            _inputAction.Player.Jump.performed += Jump;
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
    }
}
