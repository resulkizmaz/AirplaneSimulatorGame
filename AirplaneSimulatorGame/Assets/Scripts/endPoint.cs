using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class endPoint : MonoBehaviour
{
    #region Pannel Controller
    [SerializeField]
    GameObject endPannel;
    
    public TextMeshProUGUI youWinText;
    private void Start()
    {
        endPannel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            endPannel.SetActive(true);
            youWinText.text = "You Win!";
            Time.timeScale = 0f;

        }
    }
    #endregion

    #region Button Functions
    public void playAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void exit()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}
