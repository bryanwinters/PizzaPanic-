using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaManager : MonoBehaviour, IManager {

    public static PizzaManager SharedInstance;

    void Awake()
    {
        SharedInstance = this;
    }


    List<PizzaOrders> OrderList;
    public GameObject dough;
    List<PizzaClass> PizzaList = new List<PizzaClass>();
    List<GameObject> PizzaObjects = new List<GameObject>();
    GameObject currentPizzaObject;
    PizzaClass currentPizza;

    public void Init()
    {

    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Q))
        {
            NewPizza();
        }
        
    }

    public void NewPizza ( )
    {
        if( currentPizzaObject != null ) //not first run
        {
            //store old pizza
            PizzaList.Add(currentPizza);
            PizzaObjects.Add(currentPizzaObject);
            currentPizzaObject.transform.position = new Vector3(0, 0, 20f);
        }
        else //first run
        {
        }

        currentPizzaObject = (GameObject)Instantiate(dough, Vector3.zero, Quaternion.identity);
        currentPizzaObject.gameObject.AddComponent<PizzaOrders>();
        currentPizzaObject.gameObject.GetComponent<PizzaOrders>().CreateOrder();
        currentPizzaObject.gameObject.AddComponent<PizzaClass>();
        currentPizza = currentPizzaObject.GetComponent<PizzaClass>();
        currentPizzaObject.gameObject.GetComponent<PizzaOrders>().DeliverPizza(currentPizza);

    }

    public void AddTopping(Constants.Toppings topping)
    {
        currentPizza.UpdateToppings(topping, 1);
    }

    public void AddTopping (Constants.Toppings topping, int amount)
    {
        currentPizza.UpdateToppings(topping, amount);
    }
}
