using System;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CircleCollider2D))]
    public class Money : MonoBehaviour
    {
        public event Action Collected;

        private void OnDestroy()
        {
            Collected?.Invoke();
        }
    }
}