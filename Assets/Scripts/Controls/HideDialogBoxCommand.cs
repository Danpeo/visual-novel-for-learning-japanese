using UnityEngine;

namespace Controls
{
    public class HideDialogBoxCommand : ICommand
    {
        private Animator _animator;
        private static readonly int IsOpen = Animator.StringToHash("isOpen");
        public void Execute()
        {
            _animator.SetBool(IsOpen, false);
        }
    }
}
