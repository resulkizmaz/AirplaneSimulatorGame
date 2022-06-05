using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class timelineController : MonoBehaviour
{
    #region Objects
    public PlayableDirector playableDirector;
    public GameObject engineEffect;
    #endregion

    #region Control
    private void Start()
    {
        engineEffect.SetActive(false);
        Time.timeScale = 1f; 
    }
    public void play()
    {
        playableDirector.Play();
        engineEffect.SetActive(true);
    }
    #endregion
}
