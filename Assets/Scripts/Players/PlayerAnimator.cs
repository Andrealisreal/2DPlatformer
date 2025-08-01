using UnityEngine;

namespace Players
{
    public class PlayerAnimator
    {
        private readonly Animator _animator;

        public PlayerAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void PlayRun()
        {
            _animator.SetBool(AnimationParameters.Movement.Run, true);
        }

        public void StopRun()
        {
            _animator.SetBool(AnimationParameters.Movement.Run, false);
        }

        public void PlayJump()
        {
            _animator.SetTrigger(AnimationParameters.Movement.Jump);
        }
    }
}