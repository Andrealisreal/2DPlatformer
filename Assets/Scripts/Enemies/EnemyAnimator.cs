using UnityEngine;

namespace Enemies
{
    public class EnemyAnimator
    {
        private readonly Animator _animator;

        public EnemyAnimator(Animator animator)
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
    }
}