using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class yawHoldButtonEvent : MonoBehaviour 
{
    [SerializeField]
    GameObject plane;

    public float Yaw;
    public float yawSpeed;

    float maxYaw = 10f;
    float minYaw = -10f;

    bool isHold;
    bool rightYaw = false;
    bool leftYaw = false;

    private void Update()
    {
        #region INPUT
        if (isHold && Yaw<maxYaw&&rightYaw)
        {
            Yaw += Time.deltaTime * yawSpeed;
        }
        if (isHold && Yaw>minYaw && leftYaw)
        {
            Yaw -= Time.deltaTime * yawSpeed;
        }
        #endregion

        #region MOVING
        if (Yaw > 0.1f) // Klavyede E
        {
            plane.transform.Rotate(-Vector3.down * yawSpeed * Yaw * 0.1f * Time.deltaTime);
            Debug.Log("SAÐA DÖNME");
        }

        if (Yaw < -0.1f) // Klavyede Q
        {
            plane.transform.Rotate(-Vector3.up * yawSpeed * -Yaw * 0.1f * Time.deltaTime);
            Debug.Log("SOLA DÖNME");
        }
        #endregion
    }
    #region BUTTONS
    public void HoldButton()
    {
        isHold = true;
    }
    public void ReleaseButton()
    {
        isHold = false;
        Yaw = 0;

    }
    public void yawRight()
    {
        rightYaw = true;
        leftYaw = false;
    }
    public void yawLeft()
    {
        leftYaw = true;
        rightYaw = false;
    }
    #endregion

}