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
    #endregion

    #region Caching
    colliderController _colliderController;
    private void Start()
    {
        _colliderController = Object.FindObjectOfType<colliderController>();
    }
    #endregion

    #region Trigger Enter
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _colliderController.cPoint += 1;
            checkPointText.text = "Check Point : " + _colliderController.cPoint.ToString();

            _colliderController.score += 10;
            scoreText.text = "Score : " + _colliderController.score.ToString();
        }
    }
    #endregion

    #region Trigger Exit
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    #endregion

}
