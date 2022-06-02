using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class colliderController : MonoBehaviour
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

    #endregion

    #region Parameters
    float timePassed;
    float targetTime;
    int second;
    public int cPoint;
    public int score;
    #endregion

    #region Caching
    movement _movement;
    void Start()
    {
        _movement = Object.FindObjectOfType<movement>();
        boomEffect.SetActive(false);
    }
    #endregion

    #region Update
    void Update()
    {
        Timer();
    }
    #endregion


    #region Collider Control

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("terrain")) // TERRAÝN'E ÇARPARSA PATLAYACAK
        {
            StartCoroutine(destroyPlane());
        }

        if (other.CompareTag("endPoint")) // END POÝNT
        {
            // finishPannel.SetActive(true);
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
                // audioWarning.Play();
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
            // audioWarning.Stop();
            worningText.text = "";
        }
    }

    IEnumerator destroyPlane()
    {
        Destroy(player);
        _movement.speed = 0;
        boomEffect.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }

    #endregion

    #region Timer
    public void Timer()
    {
        timePassed += Time.deltaTime; // Oyunu oynadýðýmýz süre
        timerText.text = timePassed.ToString();

        targetTime -= Time.deltaTime; // Rotaya geri dönmemiz gereken süre
        second = Mathf.RoundToInt(targetTime);
    }

    #endregion
}
