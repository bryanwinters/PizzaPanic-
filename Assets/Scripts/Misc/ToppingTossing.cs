using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingTossing : MonoBehaviour {

    public GameObject[] Sauce;
    public GameObject[] Cheese;
    public GameObject[] Pepperoni;
    public GameObject[] Bacon;
    public GameObject[] Anchovies;
    public GameObject[] GreenPepper;
    public GameObject[] Mushroom;
    public GameObject[] HotPepper;
    public GameObject[] Pineapple;

    Constants.Toppings currentTopping = Constants.Toppings.dough;

    float minForce = -13f;
    float maxForce = -7f;

	// Use this for initialization
	void Start () {
        if (Sauce.Length <= 0)
        {
            Debug.LogError("No sauce in array, order more.");
        }

        if (Pepperoni.Length <= 0)
        {
            Debug.LogError("No pepperoni in array, order more.");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.O))
        {
            //+1 topping
            currentTopping += 1;
            if( (int)currentTopping >= 10 )
            {
                currentTopping -= 10;
            }
            Debug.Log("Current: " + currentTopping.ToString());
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            //-1 topping
            currentTopping -= 1;
            if (currentTopping < 0)
            {
                currentTopping += 10;
            }
            Debug.Log("Current: " + currentTopping.ToString());
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //firetoppings
            GameObject NewTopping = ObjectPooler.SharedInstance.GetTopping(currentTopping);
            if( NewTopping != null )
            {
                //for (int x = 0; x < 3; x++)
                {
                    Vector3 spawnPos = gameObject.transform.position + Random.onUnitSphere * 0.6f;
                    NewTopping.transform.position = spawnPos;
                    //NewTopping.transform.rotation = gameObject.transform.rotation;
                    NewTopping.SetActive(true);
                    //NewTopping.GetComponent<Rigidbody>().AddForce(gameObject.transform.right * -7f, ForceMode.Impulse);
                    NewTopping.GetComponent<Rigidbody>().AddForce(gameObject.transform.right * Random.Range(minForce, maxForce), ForceMode.VelocityChange);
                }
                
            }
        }
	}
}
