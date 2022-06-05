using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    #region Objects
    [SerializeField]
    Joystick joystick;
    #endregion
    #region Parameters

    [Range(-1, 1)]
    public float Pitch;
    [Range(-1, 1)]
    public float Roll;

    public float speed;
    public float maxSpeed;
    public float minSpeed;
    public float rollSpeed;
    public float pitchSpeed;

    #endregion

    private void Update()
    {
        #region Input

        Pitch = joystick.Vertical;
        Roll = joystick.Horizontal;

        #endregion


        #region Moving

        transform.position += transform.forward * speed * Time.deltaTime;


        if (Pitch > 0) // Klavyede W
        {
            transform.Rotate(-Vector3.right * pitchSpeed * Pitch * Time.deltaTime);
            Debug.Log("DÜÞÜÞ");
        }
        if (Pitch < 0) // Klavyede S
        {
            transform.Rotate(-Vector3.left * pitchSpeed * -Pitch * Time.deltaTime);
            Debug.Log("KALKIÞ");
        }


        if (Roll < 0)// Klavyede A
        {
            transform.Rotate(Vector3.forward * rollSpeed * -Roll * Time.deltaTime);
            Debug.Log("SOLA YATMA");
        }
        if (Roll > 0) // Klavyede D
        {
            transform.Rotate(Vector3.back * rollSpeed * Roll * Time.deltaTime);
            Debug.Log("SAÐA YATMA");
        }

        #endregion

    }
}
