using UnityEngine;

namespace Player
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        
        private Rigidbody2D _rigidbody2D;
        
        private readonly Quaternion _lookRight = Quaternion.Euler(0, 0, 0);
        private readonly Quaternion _lookLeft = Quaternion.Euler(0, 180, 0);

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 direction)
        {
            _rigidbody2D.linearVelocity = new Vector2(direction.x * _speed, _rigidbody2D.linearVelocity.y);
            Turn(direction);
        }

        private void Turn(Vector2 direction)
        {
            if (direction.x > 0)
                transform.rotation = _lookRight;
            else if (direction.x < 0)
                transform.rotation = _lookLeft;
        }
    }
}
