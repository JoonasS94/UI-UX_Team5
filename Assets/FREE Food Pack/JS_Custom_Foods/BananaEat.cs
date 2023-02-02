using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaEat : MonoBehaviour
{
    public bool bananaInFrontOfMounth = false;
    public bool bananaFirstPartEaten = false;
    public bool suuVapaa = true;

    public GameObject Banana;
    public GameObject BananaUp;
    public GameObject BananaDown;

    public GameObject BananaSound1;
    public GameObject BananaSound2;

    AudioSource audioData1;
    AudioSource audioData2;

    // Start is called before the first frame update
    void Start()
    {
        audioData1 = BananaSound1.GetComponent<AudioSource>();
        audioData2 = BananaSound2.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Banaani"))
        {
            if (bananaFirstPartEaten == false)
            {
                suuVapaa = false;
                // Eat food 1st part


                audioData1.Play(0);

                BananaUp.gameObject.SetActive(false);
                bananaInFrontOfMounth = true;
                bananaFirstPartEaten = true;
                StartCoroutine(EatSecondPart());
            }
            if (bananaFirstPartEaten == true && suuVapaa == true)
            {
                // Eat food 2nd part

                audioData2.Play(0);

                BananaDown.gameObject.SetActive(false);
                Banana.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Banaani"))
        {
            bananaInFrontOfMounth = false;
        }
    }

    IEnumerator EatSecondPart()
    {
        yield return new WaitForSeconds(1.25f);
        if (bananaInFrontOfMounth == true && bananaFirstPartEaten == true)
        {
            // Eat food 2nd part

            audioData2.Play(0);

            BananaDown.gameObject.SetActive(false);
            Banana.gameObject.SetActive(false);
        }
        else
        {
            suuVapaa = true;
        }
    }
}
