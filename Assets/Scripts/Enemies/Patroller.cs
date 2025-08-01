using UnityEngine;

namespace Enemies
{
    public class Patroller : MonoBehaviour
    {
        [SerializeField] private Transform[] _waypoints;
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _reachDistance = 0.1f;

        private SpriteRenderer _renderer;
        private Rigidbody2D _rigidbody2D;
        private Flipper _flipper;

        private int _currentWaypointIndex;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
            _flipper = new(_renderer);
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

            _flipper.Turn(direction);
        }
    }
}