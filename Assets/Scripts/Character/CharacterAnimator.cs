using UnityEngine;

namespace Assets.Scripts.Character
{
    public class CharacterAnimator
    {
        private readonly Animator _animator;

        public CharacterAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void Animate(float horizontalDirection, float verticalDirection)
        {
            _animator.SetBool("WalkDown", verticalDirection == -1);

            _animator.SetBool("WalkUp", verticalDirection == 1);

            _animator.SetBool("WalkSide", horizontalDirection != 0);
        }
    }
}
