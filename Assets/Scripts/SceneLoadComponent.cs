using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadComponent : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;
    
    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
