using Items;
using UnityEngine;

namespace Players
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Money>(out var money))
            {
                _inventory.AddCoin();
                money.Collect();
            }
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