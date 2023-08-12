using UnityEngine;

namespace Dialogs
{
    [RequireComponent(typeof(ShowDialogComponent))]
    public class DialogController : MonoBehaviour
    {
        private ShowDialogComponent _showDialogComponent;
        
        private void Start()
        {
            _showDialogComponent = GetComponent<ShowDialogComponent>();
            _showDialogComponent.Show();
        }
    }
}
