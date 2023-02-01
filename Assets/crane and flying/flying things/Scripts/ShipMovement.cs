using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShipMovement : MonoBehaviour
{
    public GameObject ship2;
    public Transform topOfJoystick;

    [SerializeField]
    float turnSpeed;

    [SerializeField]
    float speed;

    [SerializeField]
    private float forwardBackwardTilt = 0;

    

    // Update is called once per frame
    void Update()
    {
        forwardBackwardTilt = topOfJoystick.rotation.eulerAngles.x;
        if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
        {
            forwardBackwardTilt = Math.Abs(forwardBackwardTilt - 360);
            Debug.Log("Backward" + forwardBackwardTilt);
            ship2.transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }
        else if (forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
        {
            Debug.Log("Forward" + forwardBackwardTilt);
            ship2.transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
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
