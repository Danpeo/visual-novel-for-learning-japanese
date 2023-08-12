using UnityEngine;

namespace Controls
{
    public class CommandExecuter : MonoBehaviour
    {
        private ICommand _currentCommand;

        public void ExecuteCommand(ICommand command)
        {
            _currentCommand = command;
            _currentCommand.Execute();
        }
    }
}
