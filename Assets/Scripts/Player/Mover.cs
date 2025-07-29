using UnityEngine;

namespace Player
{
    public class Mover : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private PlayerInput _input;

        private Vector2 _direction;
        
        private float _speed = 3f;
        private bool _isLookRight = true;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _input = GetComponent<PlayerInput>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _direction = _input.Movement;
            _rigidbody2D.linearVelocity = new Vector2(_direction.x * _speed, _rigidbody2D.linearVelocity.y);
            Turn();
        }

        private void Turn()
        {
            if (_direction.x > 0 && _isLookRight == false || _direction.x < 0 && _isLookRight)
                Flip();
        }

        private void Flip()
        {
            _isLookRight = _isLookRight == false;
            var scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
