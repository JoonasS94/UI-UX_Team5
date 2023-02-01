using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementButton : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    bool movef = false;
    bool moveb = false;
    bool turnr = false;
    bool turnl = false;

    public GameObject ship2;
    [SerializeField]
    float speed;
    [SerializeField]
    float rotatespeed;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!isPressed)
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
        if(other == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.02f, 0);
            onRelease.Invoke();
            isPressed = false;
            Debug.Log("You have exited");
        }
    }

    public void MoveForward(bool _movef)
    {
        movef = _movef;
    }

    public void MoveBackward(bool _moveb)
    {
        moveb = _moveb;
    }

    public void TurnLeft(bool _turnl)
    {
        turnl = _turnl;
    }

    public void TurnRight(bool _turnr)
    {
        turnr = _turnr;
    }

    private void Update()
    {
        if (movef == true)
        {
            ship2.transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }

        if (moveb == true)
        {
            ship2.transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }

        if (turnr == true)
        {
            ship2.transform.Rotate(new Vector3(0, -1, 0) * rotatespeed * Time.deltaTime);
        }

        if (turnl == true)
        {
            ship2.transform.Rotate(new Vector3(0, 1, 0) * rotatespeed * Time.deltaTime);
        }
    }
}
