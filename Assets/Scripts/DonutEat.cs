using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutEat : MonoBehaviour
{
    public bool donutInFrontOfMouth = false;
    public bool donutFirstPartEaten = false;
    public bool suuVapaa = true;

    public GameObject Donut;
    public GameObject DonutLeft;
    public GameObject DonutRight;

    public GameObject DonutSound1;
    public GameObject DonutSound2;

    AudioSource audioData1;
    AudioSource audioData2;

    // Start is called before the first frame update
    void Start()
    {
        audioData1 = DonutSound1.GetComponent<AudioSource>();
        audioData2 = DonutSound2.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Donitsi"))
        {
            if (donutFirstPartEaten == false)
            {
                suuVapaa = false;
                // Eat food 1st part


                audioData1.Play(0);

                DonutLeft.gameObject.SetActive(false);
                donutInFrontOfMouth = true;
                donutFirstPartEaten = true;
                StartCoroutine(EatSecondPart());
            }
            if (donutFirstPartEaten == true && suuVapaa == true)
            {
                // Eat food 2nd part

                audioData2.Play(0);

                DonutRight.gameObject.SetActive(false);
                Donut.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Donitsi"))
        {
            donutInFrontOfMouth = false;
        }
    }

    IEnumerator EatSecondPart()
    {
        yield return new WaitForSeconds(1.25f);
        if (donutInFrontOfMouth == true && donutFirstPartEaten == true)
        {
            // Eat food 2nd part

            audioData2.Play(0);

            DonutRight.gameObject.SetActive(false);
            Donut.gameObject.SetActive(false);
        }
        else
        {
            suuVapaa = true;
        }
    }
}
