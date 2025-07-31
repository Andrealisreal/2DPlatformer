using UnityEngine;
using UnityEngine.Events;

namespace Items
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Money : MonoBehaviour
    {
        public event UnityAction Collected;

        private CircleCollider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<CircleCollider2D>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent<Player.Player>(out _))
            {
                Collected?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}