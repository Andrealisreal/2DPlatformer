using System;
using Players;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Money : MonoBehaviour
    {
        public event Action<Money> Collected;
        
        private CircleCollider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<CircleCollider2D>();
            _collider.isTrigger = true;
        }
        
        public void Collect()
        {
            Collected?.Invoke(this);
        }
    }
}