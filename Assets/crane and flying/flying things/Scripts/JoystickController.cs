using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JoystickController : MonoBehaviour
{
    public GameObject ship;
    public Transform topOfJoystick;

    [SerializeField]
    private float forwardBackwardTilt = 0;

    [SerializeField]
    private float sideToSideTilt = 0;

    [SerializeField]
    float rotatespeed;

    [SerializeField]
    float turnSpeed;

    [SerializeField]
    float downAndUpSpeed;

    [SerializeField]
    float speed;


    // Update is called once per frame
    void Update()
    {
        forwardBackwardTilt = topOfJoystick.rotation.eulerAngles.x;
        if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
        {
            forwardBackwardTilt = Math.Abs(forwardBackwardTilt - 360);
            Debug.Log("Backward" + forwardBackwardTilt);
            ship.transform.Rotate(new Vector3(-1, 0, 0) * rotatespeed * Time.deltaTime);
        }
        else if (forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
        {
            Debug.Log("Forward" + forwardBackwardTilt);
            ship.transform.Rotate(new Vector3(1, 0, 0) * rotatespeed * Time.deltaTime);
        }

        sideToSideTilt = topOfJoystick.rotation.eulerAngles.z;
        if (sideToSideTilt < 355 && sideToSideTilt > 290)
        {
            sideToSideTilt = Math.Abs(sideToSideTilt - 360 * Time.deltaTime);
            Debug.Log("Right" + sideToSideTilt);
            ship.transform.Rotate(new Vector3(1, 0, -1) * rotatespeed * Time.deltaTime);
        }
        else if (sideToSideTilt > 5 && sideToSideTilt < 74)
        {
            Debug.Log("Left" + sideToSideTilt);
            ship.transform.Rotate(new Vector3(0, 0, 1) * rotatespeed * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}
