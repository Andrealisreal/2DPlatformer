using Items;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Inventory))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Jumper))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    [RequireComponent(typeof(Mover))]
    public class Player : MonoBehaviour
    {
        private Inventory _inventory;
        private PlayerAnimator _playerAnimator;
        private Animator _animator;
        private PlayerInput _input;
        private Jumper _jumper;
        private Mover _mover;

        private Vector2 _direction;

        private void Awake()
        {
            _inventory = GetComponent<Inventory>();
            _animator = GetComponent<Animator>();
            _input = GetComponent<PlayerInput>();
            _mover = GetComponent<Mover>();
            _jumper = GetComponent<Jumper>();

            _playerAnimator = new PlayerAnimator(_animator);
        }

        private void FixedUpdate()
        {
            _mover.Move(_input.Movement);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Money>(out _))
                _inventory.AddCoin();
        }

        private void OnEnable()
        {
            _input.JumpClicked += _playerAnimator.PlayJump;
            _input.JumpClicked += _jumper.Jump;
            _input.MovementClicked += _playerAnimator.PlayRun;
            _input.MovementCanceled += _playerAnimator.StopRun;
        }

        private void OnDisable()
        {
            _input.JumpClicked -= _playerAnimator.PlayJump;
            _input.JumpClicked -= _jumper.Jump;
            _input.MovementClicked -= _playerAnimator.PlayRun;
            _input.MovementCanceled -= _playerAnimator.StopRun;
        }
    }
}