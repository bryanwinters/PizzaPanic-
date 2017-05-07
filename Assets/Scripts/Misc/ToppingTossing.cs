using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingTossing : MonoBehaviour {

    Constants.Toppings currentTopping = Constants.Toppings.dough;

    float minForce = -13f;
    float maxForce = -7f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.O))
        {
            //+1 topping
            currentTopping += 1;
            if( (int)currentTopping >= 11 )
            {
                currentTopping -= 11;
            }
            Debug.Log("Current: " + currentTopping.ToString());
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            //-1 topping
            currentTopping -= 1;
            if (currentTopping < 0)
            {
                currentTopping += 11;
            }
            Debug.Log("Current: " + currentTopping.ToString());
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            //firetoppings
            PizzaToppingUnifier NewTopping = ObjectPooler.SharedInstance.GetTopping(currentTopping);
            if( NewTopping != null )
            {
                //for (int x = 0; x < 3; x++)
                {
                    Vector3 spawnPos = gameObject.transform.position + Random.onUnitSphere * 0.6f;
                    NewTopping.transform.position = spawnPos;
                    //NewTopping.transform.rotation = gameObject.transform.rotation;
                    NewTopping.gameObject.SetActive(true);
                    //NewTopping.GetComponent<Rigidbody>().AddForce(gameObject.transform.right * -7f, ForceMode.Impulse);
                    NewTopping.Rigidbody.AddForce(gameObject.transform.right * Random.Range(minForce, maxForce), ForceMode.VelocityChange);
                }
                
            }
        }
	}
}
