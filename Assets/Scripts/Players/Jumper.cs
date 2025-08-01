using UnityEngine;

namespace Players
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private float _force = 5f;
        [SerializeField] private Vector2 _size;
        [SerializeField] private Vector3 _height;

        private Rigidbody2D _rigidbody2D;

        private bool _isGround;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Jump()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + _height, _size, 0f,
                LayerMask.GetMask("Ground", "Enemy"));

            if (hit != null)
                _rigidbody2D.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + _height, _size);
        }
    }
}