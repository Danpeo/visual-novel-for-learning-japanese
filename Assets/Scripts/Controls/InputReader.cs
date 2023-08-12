using Dialogs;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Controls
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private DialogBoxController _dialogBox;
        //[SerializeField] private MainMenuButton _mainMenuButton;
        
        private bool _isDialogShown = true;
        
        public void OnToggleDialogBox(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            if (_isDialogShown)
            {
                _dialogBox.HideDialogBox();
                //_mainMenuButton.Hide();
                _isDialogShown = false;
            }
            else
            {
                _dialogBox.ShowDialogBox();
                //_mainMenuButton.Show();
                _isDialogShown = true;
            }
        }

        public void OnGoToMainMenu(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            SceneManager.LoadScene("MainMenu");
        }
    }
}
