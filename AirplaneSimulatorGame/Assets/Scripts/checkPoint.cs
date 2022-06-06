using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class checkPoint : MonoBehaviour
{
    #region Objects
    [SerializeField] 
    TextMeshProUGUI scoreText;
    [SerializeField] 
    TextMeshProUGUI checkPointText;
    [SerializeField]
    GameObject endPannel;
    #endregion

    #region Caching
    UIController uiController;
    private void Start()
    {
        uiController = Object.FindObjectOfType<UIController>();
    }
    #endregion

    #region Collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiController.cPoint += 1;
            checkPointText.text = "Check Point : " + uiController.cPoint.ToString();

            uiController.score += 10;
            scoreText.text = "Score : " + uiController.score.ToString();
            if (uiController.cPoint==5)
            {
                endPannel.SetActive(true);
            }

            Destroy(gameObject);
        }
    }
    #endregion
}
