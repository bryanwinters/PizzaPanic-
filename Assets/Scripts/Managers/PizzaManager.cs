using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaManager : MonoBehaviour, IManager {

    public static PizzaManager SharedInstance;

    void Awake()
    {
        SharedInstance = this;
    }

    public Transform DoughSpawnPoint;

    List<PizzaOrders> OrderList;
    public GameObject dough;
    List<PizzaClass> PizzaList = new List<PizzaClass>();
    List<GameObject> PizzaObjects = new List<GameObject>();
    public GameObject currentPizzaObject;
    PizzaClass currentPizza;
    PizzaOrders theOrder;
    public PizzaOrders TheOrder { get { return theOrder; } }
    public MeshFix doughMeshScript;

    List<int> TotalPizzaScores = new List<int>(); //receives all of the pizza scores for averaging and finding highest/lowest

    public void Init()
    {

    }


	// Use this for initialization
	void Start () 
    {
        SubscribeToEvents();
	}

    private void SubscribeToEvents ()
    {
        GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
        PlayerManager.Instance.OnPizzaSubmitted += NewPizza;
    }

    private void UnsubscribeToEvents ()
    {
        GameManager.Instance.OnGameStateChanged -= HandleGameStateChanged;
        PlayerManager.Instance.OnPizzaSubmitted -= NewPizza;
    }

    private void HandleGameStateChanged(Constants.GameState state)
    {
        if (state == Constants.GameState.game)
        {
            NewPizza();
        }
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
        currentPizzaObject = (GameObject)Instantiate(dough, DoughSpawnPoint.position, Quaternion.identity);
//        currentPizzaObject.transform.localScale = new Vector3(2.5f, 1f, 2.5f);
        doughMeshScript = currentPizzaObject.GetComponentInChildren<MeshFix>();
        theOrder = currentPizzaObject.gameObject.AddComponent<PizzaOrders>();
        theOrder.CreateOrder();
        if(theOrder.PizzaOrderSize == Constants.PizzaSizes.small)
        {
            currentPizzaObject.transform.localScale = Constants.SMALL_PIZZA_SCALE;
        }
        else if (theOrder.PizzaOrderSize == Constants.PizzaSizes.medium)
        {
            currentPizzaObject.transform.localScale = Constants.MEDIUM_PIZZA_SCALE;
        }
        else if (theOrder.PizzaOrderSize == Constants.PizzaSizes.large)
        {
            currentPizzaObject.transform.localScale = Constants.LARGE_PIZZA_SCALE;
        }
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

    public int GetAverageScore ()
    {
        int total = 0;

        foreach(int score in TotalPizzaScores)
        {
            total += score;
        }

        if (total == 0)
            return total;
            
        return Mathf.RoundToInt((float)total/(float)TotalPizzaScores.Count);
    }

    public int GetHighScore()
    {
        return Mathf.Max(TotalPizzaScores.ToArray());
    }

    public int GetLowScore()
    {
        return Mathf.Min(TotalPizzaScores.ToArray());
    }

    public int GetNumPizzas ()
    {
        return TotalPizzaScores.Count;
    }

    public string GetRanking ()
    {
        int avg = GetAverageScore();

        if (avg >= 100)
            return "S";
        else if (avg < 100 && avg >= 95)
            return "A+";
        else if (avg < 95 && avg >= 85)
            return "A";
        else if (avg < 85 && avg >= 80)
            return "A-";
        else if (avg < 80 && avg >= 76)
            return "B+";
        else if (avg < 76 && avg >= 74)
            return "B";
        else if (avg < 74 && avg >= 70)
            return "B-";
        else if (avg < 70 && avg >= 66)
            return "C+";
        else if (avg < 66 && avg >= 64)
            return "C";
        else if (avg < 64 && avg >= 60)
            return "C-";
        else if (avg < 60 && avg >= 56)
            return "D+";
        else if (avg < 56 && avg >= 54)
            return "D";
        else if (avg < 54 && avg >= 50)
            return "D-";
        else 
            return "F";
    }
}
