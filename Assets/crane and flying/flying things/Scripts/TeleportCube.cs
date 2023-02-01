using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportCube : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    
    public GameObject maincontroller;
    public GameObject shipcontroller;




    // Start is called before the first frame update
    void Start()
    {
        
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.01f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
            Debug.Log("You have entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.02f, 0);
            onRelease.Invoke();
            isPressed = false;
            Debug.Log("You have exited");
        }
    }

    public void ShipTeleport()
    {
        maincontroller.SetActive(false);
        shipcontroller.SetActive(true);
    }

    public void ShipBack()
    {
        shipcontroller.SetActive(false);
        maincontroller.SetActive(true);
    }
}
