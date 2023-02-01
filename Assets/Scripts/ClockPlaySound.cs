using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPlaySound : MonoBehaviour
{
    AudioSource audioData;

    public GameObject LeftHand;
    public GameObject RightHand;

    public GameObject LeftHandRb;
    public GameObject RightHandRb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, LeftHand.transform.position);

        //Debug.Log("Distance = " + distance);

        if (distance <= 1.5f)
        {
            LeftHandRb.gameObject.SetActive(true);
        }
        else
        {
            LeftHandRb.gameObject.SetActive(false);
        }

        float distance2 = Vector3.Distance(this.transform.position, RightHand.transform.position);

        if (distance2 <= 1.5f)
        {
            RightHandRb.gameObject.SetActive(true);
        }
        else
        {
            RightHandRb.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("viisari"))
        {
            //Debug.Log("BLING OnTriggerEnter!");
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
        }
    }
}
