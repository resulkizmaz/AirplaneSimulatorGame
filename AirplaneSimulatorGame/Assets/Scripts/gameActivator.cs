using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameActivator : MonoBehaviour
{
    #region Caching
    Scene _scene;
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }
    #endregion

    #region Describe
    private void Update()
    {
        if (this.gameObject)
        {
            SceneManager.LoadScene(_scene.buildIndex + 1);
           
        }
    }
    #endregion
}
