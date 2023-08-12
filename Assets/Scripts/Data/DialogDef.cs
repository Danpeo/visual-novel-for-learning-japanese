using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Defs/DialogDef", fileName = "DialogDef")]
    public class DialogDef : ScriptableObject
    {
        [SerializeField] private DialogData _data;
        public DialogData Data => _data;
    }
}
