using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaToppingUnifier : MonoBehaviour {

    public Constants.Toppings MyTopping;

    bool AddedAlready = false;

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

            if(!AddedAlready)
            {
                AddSelfToPizza();
            }
            
        }
        else if( c.gameObject.layer == LayerMask.NameToLayer("PizzaTopping"))
        {
            //become one;
            gameObject.transform.parent = c.transform.root;
            gameObject.layer = LayerMask.NameToLayer("PizzaTopping");
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

            if( !AddedAlready )
            {
                AddSelfToPizza();
            }
            
        }
        else if(c.gameObject.layer == LayerMask.NameToLayer("ToppingCatcher"))
        {
            gameObject.SetActive(false);
        }
    }

    void AddSelfToPizza()
    {
        if( MyTopping == Constants.Toppings.dough )
        {
            //do nothing
        }
        else if( MyTopping == Constants.Toppings.sauce)
        {
            Vector3 tempvec = gameObject.transform.position;
            tempvec.y = 0.14f;
            gameObject.transform.position = tempvec;
            //gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        else
        {
            PizzaManager.SharedInstance.AddTopping(MyTopping);
        }
    }
}
