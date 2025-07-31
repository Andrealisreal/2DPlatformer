using UnityEngine;

namespace Player
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _renderer;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void Move(Vector2 direction)
        {
            _rigidbody2D.linearVelocity = new Vector2(direction.x * _speed, _rigidbody2D.linearVelocity.y);
            Turn(direction);
        }

        private void Turn(Vector2 direction)
        {
            if (direction.x > 0)
                _renderer.flipX = false;
            else if (direction.x < 0)
                _renderer.flipX = true;
        }
    }
}
