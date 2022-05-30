using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameStarter : MonoBehaviour
{
    Scene _scene;
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene(); //caching.
    }
   
    public void gameStart()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }
}
