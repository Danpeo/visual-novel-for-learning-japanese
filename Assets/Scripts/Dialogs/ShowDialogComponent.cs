using System;
using Data;
using UnityEngine;

namespace Dialogs
{
    public class ShowDialogComponent : MonoBehaviour
    {
        [SerializeField] private Mode _mode;
        [SerializeField] private DialogData _bound;
        [SerializeField] private DialogDef _external;

        private DialogBoxController _dialogBox;

        public void Show()
        {
            if (_dialogBox == null)
                _dialogBox = FindObjectOfType<DialogBoxController>();

            _dialogBox.ShowDialog(Data);
            _dialogBox.OnStartDialogAnimation();
        }

        public void Show(DialogDef def)
        {
            _external = def;
            Show();
        }
        
        public DialogData Data
        {
            get
            {
                return _mode switch
                {
                    Mode.Bound => _bound,
                    Mode.External => _external.Data,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }
        
        public enum Mode
        {
            Bound,
            External
        }
    }
}
