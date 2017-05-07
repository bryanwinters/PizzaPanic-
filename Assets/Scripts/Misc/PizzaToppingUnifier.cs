using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PizzaToppingUnifier : MonoBehaviour {

    public Constants.Toppings MyTopping;

    bool AddedAlready = false;

    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody { get { return _rigidbody; } }

	// Use this for initialization
	private void Awake () 
    {
        SetupVariables();
	}
	
    private void SetupVariables () 
    {
        _rigidbody = this.GetComponent<Rigidbody>();
	}


    void OnCollisionEnter ( Collision c)
    {
        if( c.gameObject.layer == LayerMask.NameToLayer(Constants.LAYER_PIZZA))
        {
            //become one;
            gameObject.transform.parent = c.transform.root;
            gameObject.layer = LayerMask.NameToLayer(Constants.LAYER_PIZZA_TOPPINGS);
            _rigidbody.isKinematic = true;
            _rigidbody.useGravity = false;

            if(!AddedAlready)
            {
                AddSelfToPizza();
                AddedAlready = true;
            }
            
        }
        //_BW TODO what does this do?? toppings collide with each other??
        //_ME when toppings hit the pizza it disables their physics so things arent moving around
//        else if( c.gameObject.layer == LayerMask.NameToLayer(Constants.LAYER_PIZZA_TOPPINGS))
//        {
//            //become one;
//            gameObject.transform.parent = c.transform.root;
//            gameObject.layer = LayerMask.NameToLayer(Constants.LAYER_PIZZA_TOPPINGS);
//            _rigidbody.isKinematic = true;
//            _rigidbody.useGravity = false;
//
//            if( !AddedAlready )
//            {
//                AddSelfToPizza();
//                AddedAlready = true;
//            }
//            
//        }
        else if(c.gameObject.layer == LayerMask.NameToLayer(Constants.LAYER_TOPPING_CATCHER))
        {
            gameObject.SetActive(false);
        }
    }

    void Repooled ()
    {
        gameObject.layer = LayerMask.NameToLayer(Constants.LAYER_TOPPINGS);
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        AddedAlready = false;
        Debug.Log("repooled");
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
            //gameObject.transform.localScale = new Vector3(0.12f, 0.12f, 0.06f);

            if (!AddedAlready)
            {
                AddedAlready = true;
                PizzaManager.SharedInstance.AddTopping(MyTopping);
            }
            gameObject.transform.DOScale(new Vector3(0.12f, 0.12f, 0.06f), 0.5f);
        }
        else
        {
            PizzaManager.SharedInstance.AddTopping(MyTopping);
        }
    }
}
