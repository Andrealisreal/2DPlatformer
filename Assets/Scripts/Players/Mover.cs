using UnityEngine;

namespace Players
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;

        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _renderer;
        private Flipper _flipper;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
            _flipper = new(_renderer);
        }

        public void Move(Vector2 direction)
        {
            _rigidbody2D.linearVelocity = new Vector2(direction.x * _speed, _rigidbody2D.linearVelocity.y);
            _flipper.Turn(direction);
        }
    }
}