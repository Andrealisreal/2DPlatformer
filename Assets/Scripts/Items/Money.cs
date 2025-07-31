using UnityEngine;
using UnityEngine.Events;

namespace Items
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Money : MonoBehaviour
    {
        public event UnityAction CoinPicked;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Player.Player>(out _))
                Destroy(gameObject);
        }

        private void OnDestroy()
        {
            CoinPicked?.Invoke();
        }
    }
}
