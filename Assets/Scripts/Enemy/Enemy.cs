using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Patroler))]
    public class Enemy : MonoBehaviour
    {
        private Patroler _patroler;
        private Animator _animator;
        private EnemyAnimator _enemyAnimator;

        private void Awake()
        {
            _patroler = GetComponent<Patroler>();
            _animator = GetComponent<Animator>();

            _enemyAnimator = new EnemyAnimator(_animator);
        }

        private void Start()
        {
            _enemyAnimator.PlayRun();
        }

        private void FixedUpdate()
        {
            _patroler.Move();
        }
    }
}