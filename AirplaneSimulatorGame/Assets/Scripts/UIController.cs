using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    #region Objects
    [SerializeField]
    GameObject boomEffect;
    [SerializeField]
    GameObject player;
    [SerializeField]
    TextMeshProUGUI worningText;
    [SerializeField]
    TextMeshProUGUI timerText;
    [SerializeField]
    TextMeshProUGUI speedText;

    #endregion

    #region Parameters
    float timePassed;
    float targetTime;
    int second;
    int clock;
    public int cPoint;
    public int score;
    #endregion

    #region Caching
    movement _movement;
    void Start()
    {
        _movement = Object.FindObjectOfType<movement>();
        boomEffect.SetActive(false);
        worningText.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    #endregion

    void Update()
    {
        Timer();
    }


    #region Collider Control

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("terrain")) // TERRAÝN'E ÇARPARSA PATLAYACAK
        {
            StartCoroutine(destroyPlane());
        }

        if (other.CompareTag("outOfRoad"))
        {
            targetTime = 5f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("outOfRoad"))
        {
            if (targetTime > 0)
            {
                worningText.gameObject.SetActive(true);
                worningText.text = "Go Back To Road! " + second.ToString();
            }
            else if (targetTime <= 0)
            {
                StartCoroutine(destroyPlane());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("outOfRoad"))
        {
            worningText.gameObject.SetActive(false);
        }
    }

    IEnumerator destroyPlane()
    {
        Destroy(player);
        _movement.speed = 0;
        boomEffect.SetActive(true);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
        
    }

    #endregion

    #region Timer
    public void Timer()
    {
        timePassed += Time.deltaTime; // Oyunu oynadýðýmýz süre
        clock = Mathf.RoundToInt(timePassed);
        timerText.text = "Time : " + clock.ToString();

        speedText.text = "Speed : " + (Mathf.RoundToInt(_movement.speed)).ToString();

        targetTime -= Time.deltaTime; // Rotaya geri dönmemiz gereken süre
        second = Mathf.RoundToInt(targetTime);
    }

    #endregion
}
