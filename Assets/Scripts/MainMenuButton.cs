using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MainMenuButton : MonoBehaviour
{
    private Animator _animator;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Hide()
    {
        _animator.SetBool(IsOpen, false);
        var t = Random.Range(1, 5);
    }

    public void Show()
    {
        _animator.SetBool(IsOpen, true);
    }
}