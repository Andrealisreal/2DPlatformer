using UnityEngine;

namespace Player
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

    public static class AnimationParameters
    {
        public static class Movement
        {
            public static readonly int Jump = Animator.StringToHash("Jump");
            public static readonly int Run = Animator.StringToHash("Run");
        }
    }
}