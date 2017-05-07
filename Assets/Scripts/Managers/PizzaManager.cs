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
    PizzaOrders theOrder;

    List<int> TotalPizzaScores = new List<int>(); //receives all of the pizza scores for averaging and finding highest/lowest

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
            TotalPizzaScores.Add(theOrder.ScorePizza());
            PizzaList.Add(currentPizza);
            PizzaObjects.Add(currentPizzaObject);
            currentPizzaObject.transform.position = new Vector3(0, 0, 20f);
            currentPizzaObject.SetActive(false);
        }
        else //first run
        {
        }

        //_BW TODO addcomponenet/getcomponent all expensive at runtime - especially in UPDATE
        currentPizzaObject = (GameObject)Instantiate(dough, Vector3.zero, Quaternion.identity);
        theOrder = currentPizzaObject.gameObject.AddComponent<PizzaOrders>();
        theOrder.CreateOrder();
        //_ME cleaned up this a bit
        //
        //currentPizzaObject.gameObject.GetComponent<PizzaOrders>().CreateOrder();
        //currentPizzaObject.gameObject.AddComponent<PizzaClass>();
        //currentPizza = currentPizzaObject.GetComponent<PizzaClass>();
        currentPizza = currentPizzaObject.gameObject.AddComponent<PizzaClass>();
        theOrder.DeliverPizza(currentPizza);

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
