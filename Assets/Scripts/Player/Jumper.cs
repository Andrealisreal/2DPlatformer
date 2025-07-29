using UnityEngine;

namespace Player
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private float _force = 5f;
        
        private Rigidbody2D _rigidbody2D;
        private PlayerInput _input;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _input = GetComponent<PlayerInput>();
        }

        private void OnEnable()
        {
            _input.JumpClicked += Jump;
        }

        private void OnDisable()
        {
            _input.JumpClicked -= Jump;
        }

        private void Jump()
        {
            _rigidbody2D.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        }
    }
}
