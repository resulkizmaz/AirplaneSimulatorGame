using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameActivator : MonoBehaviour
{

    Scene _scene;
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }



    private void Update()
    {
        if (this.gameObject)
        {
            SceneManager.LoadScene(_scene.buildIndex + 1);
           
        }
    }

}
