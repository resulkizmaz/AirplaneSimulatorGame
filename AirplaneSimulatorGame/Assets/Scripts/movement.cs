using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Joystick joystick;

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

    bool isMoving = true;

    #endregion

    private void Update()
    {
        #region Moving

        if (isMoving)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        Pitch = joystick.Vertical;
        Roll = joystick.Horizontal;


        if (Pitch > 0.1f) // Klavyede W
        {
            transform.Rotate(Vector3.right * pitchSpeed * Pitch * Time.deltaTime);
            Debug.Log("DÜÞÜÞ");
        }
        if (Pitch < -0.1f) // Klavyede S
        {
            transform.Rotate(Vector3.left * pitchSpeed * -Pitch * Time.deltaTime);
            Debug.Log("KALKIÞ");
        }


        if (Roll < -0.1f)// Klavyede A
        {
            transform.Rotate(Vector3.forward * rollSpeed * -Roll * Time.deltaTime);
            Debug.Log("SOLA YATMA");
        }
        if (Roll > 0.1f) // Klavyede D
        {
            transform.Rotate(Vector3.back * rollSpeed * Roll * Time.deltaTime);
            Debug.Log("SAÐA YATMA");
        }
        #endregion

    }
}
