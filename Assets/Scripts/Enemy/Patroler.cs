using UnityEngine;

namespace Enemy
{
    public class Patroler : MonoBehaviour
    {
        [SerializeField] private Transform[] _waypoints;
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _reachDistance = 0.1f;
        
        private readonly Quaternion _lookRight = Quaternion.Euler(0, 0, 0);
        private readonly Quaternion _lookLeft = Quaternion.Euler(0, 180, 0);
        
        private Rigidbody2D _rigidbody2D;

        private int _currentWaypointIndex;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Move()
        {
            if (_waypoints.Length == 0)
                return;

            Vector2 targetPosition = _waypoints[_currentWaypointIndex].position;
            Vector2 direction = (targetPosition - _rigidbody2D.position).normalized;
            
            _rigidbody2D.linearVelocity = direction * _speed;
            
            if (Vector2.Distance(_rigidbody2D.position, targetPosition) <= _reachDistance)
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            
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
