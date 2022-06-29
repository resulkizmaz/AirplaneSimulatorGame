using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class yawHoldButtonEvent : MonoBehaviour 
{
    #region Parameters
    [SerializeField]
    GameObject plane;

    public float Yaw;
    public float yawSpeed;

    float maxYaw = 10f;
    float minYaw = -10f;

    bool isHold;
    bool rightYaw = false;
    bool leftYaw = false;
    bool Decrease;
    bool Increase;
    #endregion

    #region Caching
    movement _movement;
    private void Start()
    {
        _movement = GetComponent<movement>();
    }
    #endregion

    private void Update()
    {
        #region Input
        if (isHold && Yaw<maxYaw&&rightYaw)
        {
            Yaw += Time.deltaTime * yawSpeed;
        }
        if (isHold && Yaw>minYaw && leftYaw)
        {
            Yaw -= Time.deltaTime * yawSpeed;
        }

        if (isHold && _movement.speed < _movement.maxSpeed && Increase)
        {
            _movement.speed += Time.deltaTime*10;
        }
        if (isHold && _movement.speed > _movement.minSpeed && Decrease)
        {
            _movement.speed -= Time.deltaTime*10;
        }
        #endregion

        #region Moving
        if (Yaw > 0.1f) // Klavyede E
        {
            plane.transform.Rotate(-Vector3.down * yawSpeed * Yaw * 0.1f * Time.deltaTime);
            //Debug.Log("SAÐA DÖNME");
        }

        if (Yaw < -0.1f) // Klavyede Q
        {
            plane.transform.Rotate(-Vector3.up * yawSpeed * -Yaw * 0.1f * Time.deltaTime);
            //Debug.Log("SOLA DÖNME");
        }
        #endregion
    }
    #region ButtonControl
    public void HoldButton()
    {
        isHold = true;
    }
    public void ReleaseButton()
    {
        isHold = false;
        Yaw = 0;
        //_movement.speed = 125f;

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
    public void speedIncrease()
    {
        Increase = true;
        Decrease = false;
    }
    public void speedDecrease()
    {
        Decrease = true;
        Increase = false;
    }
    #endregion

}