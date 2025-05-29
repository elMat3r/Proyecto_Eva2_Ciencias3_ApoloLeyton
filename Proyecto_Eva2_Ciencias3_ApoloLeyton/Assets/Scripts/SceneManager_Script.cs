using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_Script : MonoBehaviour
{
    public void Empezar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
    public void Victory()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Victory");
    }
    public void VolverMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
    public void Lose()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lose");
    }
}
