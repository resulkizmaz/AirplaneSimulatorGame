using UnityEngine;
using UnityEngine.SceneManagement;

public class gameQuit : MonoBehaviour
{
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("KAPANDI");
    }
}
