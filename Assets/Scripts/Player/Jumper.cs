using UnityEngine;

namespace Player
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private float _force = 5f;
        [SerializeField] private float _width = 1f;
        [SerializeField] private float _height = 2f;

        private Rigidbody2D _rigidbody2D;

        private bool _isGround;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Jump()
        {
            Collider2D hit = Physics2D.OverlapCapsule(
                transform.position,
                new Vector2(_width, _height),
                CapsuleDirection2D.Vertical,
                0f,
                LayerMask.GetMask(nameof(Ground), nameof(Enemy)));

            if (hit != null)
                _rigidbody2D.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
        }
    }
}