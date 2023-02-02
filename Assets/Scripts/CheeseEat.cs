using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseEat : MonoBehaviour
{
    public bool cheeseInFrontOfMouth = false;
    public bool cheeseFirstPartEaten = false;
    public bool suuVapaa = true;

    public GameObject Cheese;
    public GameObject CheeseFront;
    public GameObject CheeseBack;

    public GameObject CheeseSound1;
    public GameObject CheeseSound2;

    AudioSource audioData1;
    AudioSource audioData2;

    // Start is called before the first frame update
    void Start()
    {
        audioData1 = CheeseSound1.GetComponent<AudioSource>();
        audioData2 = CheeseSound2.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Juusto"))
        {
            if (cheeseFirstPartEaten == false)
            {
                suuVapaa = false;
                // Eat food 1st part


                audioData1.Play(0);

                CheeseFront.gameObject.SetActive(false);
                cheeseInFrontOfMouth = true;
                cheeseFirstPartEaten = true;
                StartCoroutine(EatSecondPart());
            }
            if (cheeseFirstPartEaten == true && suuVapaa == true)
            {
                // Eat food 2nd part

                audioData2.Play(0);

                CheeseBack.gameObject.SetActive(false);
                Cheese.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Juusto"))
        {
            cheeseInFrontOfMouth = false;
        }
    }

    IEnumerator EatSecondPart()
    {
        yield return new WaitForSeconds(1.25f);
        if (cheeseInFrontOfMouth == true && cheeseFirstPartEaten == true)
        {
            // Eat food 2nd part

            audioData2.Play(0);

            CheeseBack.gameObject.SetActive(false);
            Cheese.gameObject.SetActive(false);
        }
        else
        {
            suuVapaa = true;
        }
    }
}
