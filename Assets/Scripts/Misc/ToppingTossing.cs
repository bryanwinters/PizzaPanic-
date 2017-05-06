using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingTossing : MonoBehaviour {

    public GameObject[] Toppings;
    int currentTopping = 0;

	// Use this for initialization
	void Start () {
		if(Toppings.Length <= 0)
        {
            Debug.LogError("No toppings in array, order more.");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.O))
        {
            //+1 topping
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            //-1 topping
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //firetoppings
            GameObject NewTopping = ObjectPooler.SharedInstance.GetTopping(currentTopping);
            if( NewTopping != null )
            {
                NewTopping.transform.position = gameObject.transform.position;
                NewTopping.transform.rotation = gameObject.transform.rotation;
                NewTopping.SetActive(true);
                //NewTopping.GetComponent<Rigidbody>().AddForce(gameObject.transform.right * -7f, ForceMode.Impulse);
                NewTopping.GetComponent<Rigidbody>().AddForce(gameObject.transform.right * -7f, ForceMode.VelocityChange);
            }
        }
	}
}
