using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Jumper))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Mover))]
    public class Player : MonoBehaviour
    {
        private Animator _animator;
        private PlayerInput _input;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _input = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            AnimRun();
        }

        private void AnimRun()
        {
            var move = _input.Movement;
            
            if (move.x > 0 || move.x < 0)
            {
                _animator.SetBool("Run", true);
                Debug.Log("Run");
            }
            else
            {
                _animator.SetBool("Run", false);
                Debug.Log("Don't run");
            }
        }
    }
}
