using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Patroller))]
    public class Enemy : MonoBehaviour
    {
        private Patroller _patroller;
        private Animator _animator;
        private EnemyAnimator _enemyAnimator;

        private void Awake()
        {
            _patroller = GetComponent<Patroller>();
            _animator = GetComponent<Animator>();

            _enemyAnimator = new EnemyAnimator(_animator);
        }

        private void Start()
        {
            _enemyAnimator.PlayRun();
        }

        private void FixedUpdate()
        {
            _patroller.Move();
        }
    }
}