using UnityEngine;

namespace Players
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;

        private Rigidbody2D _rigidbody2D;
        private Flipper _flipper;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _flipper = new();
        }

        public void Move(Vector2 direction)
        {
            _rigidbody2D.linearVelocity = new Vector2(direction.x * _speed, _rigidbody2D.linearVelocity.y);
            _flipper.Turn(transform, direction);
        }
    }
}