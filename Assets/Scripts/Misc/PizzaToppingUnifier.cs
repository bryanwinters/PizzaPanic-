using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaToppingUnifier : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter ( Collision c)
    {
        if( c.gameObject.layer == LayerMask.NameToLayer("Pizza"))
        {
            //become one;
            gameObject.transform.parent = c.transform.root;
            gameObject.layer = LayerMask.NameToLayer("PizzaTopping");
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        else if( c.gameObject.layer == LayerMask.NameToLayer("PizzaTopping"))
        {
            //become one;
            gameObject.transform.parent = c.transform.root;
            gameObject.layer = LayerMask.NameToLayer("PizzaTopping");
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
