using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public static ObjectPooler SharedInstance;

    void Awake()
    {
        SharedInstance = this;
    }

    /*dough = 0, sauce = 1, cheese = 2, pepperoni = 3, bacon = 4, anchovies = 5, greenPepper = 6,
        mushroom = 7, hotPepper = 8, pineapple = 9*/
    public List<PizzaToppingUnifier> PooledSauce;
    public List<PizzaToppingUnifier> PooledCheese;
    public List<PizzaToppingUnifier> PooledPepperoni;
    public List<PizzaToppingUnifier> PooledBacon;
    public List<PizzaToppingUnifier> PooledAnchovies;
    public List<PizzaToppingUnifier> PooledGreenPepper;
    public List<PizzaToppingUnifier> PooledMushroom;
    public List<PizzaToppingUnifier> PooledHotPepper;
    public List<PizzaToppingUnifier> PooledPineapple;
    //make lists of toppings to pool and do that

    public GameObject[] sauce, cheese, pepperoni, bacon, anchovies, greenpepper, mushroom, hotpepper, pineapple;
    public int amountToPool;

	// Use this for initialization
	void Start () {

        if (sauce != null)
        {
            PooledSauce = new List<PizzaToppingUnifier>();
            for (int i = 0; i < amountToPool; i++)
            {
                int objCounter = 0;
                if (sauce.Length > 1)
                {
                    objCounter = Random.Range(0, sauce.Length - 1);
                }
                else
                {
                    objCounter = 0;
                }
                GameObject obj = (GameObject)Instantiate(sauce[objCounter], gameObject.transform.position, Quaternion.Euler(-90f, 0f, 0f));
                PizzaToppingUnifier p = obj.GetComponent<PizzaToppingUnifier>();
                //obj.transform.Rotate(Vector3.right, 90f);
                p.gameObject.SetActive(false);
                PooledSauce.Add(p);
            }
        }

        if ( pepperoni != null )
        {
            int objCounter = 0;
            if (pepperoni.Length > 1)
            {
                objCounter = Random.Range(0, sauce.Length);
            }
            else
            {
                objCounter = 0;
            }
            PooledPepperoni = new List<PizzaToppingUnifier>();
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(pepperoni[objCounter]);
                PizzaToppingUnifier p = obj.GetComponent<PizzaToppingUnifier>();
                p.gameObject.SetActive(false);
                PooledPepperoni.Add(p);
            }
        }
        
		
	}
	
    public PizzaToppingUnifier GetTopping(Constants.Toppings toppingNumber)
    {

        if (toppingNumber == Constants.Toppings.sauce)
        {
            for (int i = 0; i < PooledSauce.Count; i++)
            {
                if (!PooledSauce[i].gameObject.activeInHierarchy)
                {
                    return PooledSauce[i];
                }
            }
        }
        else if (toppingNumber == Constants.Toppings.cheese)
        {
            for (int i = 0; i < PooledCheese.Count; i++)
            {
                if (!PooledCheese[i].gameObject.activeInHierarchy)
                {
                    return PooledCheese[i];
                }
            }
        }
        else if (toppingNumber == Constants.Toppings.pepperoni)
        {
            for (int i = 0; i < PooledPepperoni.Count; i++)
            {
                if (!PooledPepperoni[i].gameObject.activeInHierarchy)
                {
                    return PooledPepperoni[i];
                }
            }
        }
        else if( toppingNumber == Constants.Toppings.bacon )
        {
            for (int i = 0; i < PooledBacon.Count; i++)
            {
                if (!PooledBacon[i].gameObject.activeInHierarchy)
                {
                    return PooledBacon[i];
                }
            }
        }
        else if (toppingNumber == Constants.Toppings.anchovies)
        {
            for (int i = 0; i < PooledAnchovies.Count; i++)
            {
                if (!PooledAnchovies[i].gameObject.activeInHierarchy)
                {
                    return PooledAnchovies[i];
                }
            }
        }
        else if (toppingNumber == Constants.Toppings.greenPepper)
        {
            for (int i = 0; i < PooledGreenPepper.Count; i++)
            {
                if (!PooledGreenPepper[i].gameObject.activeInHierarchy)
                {
                    return PooledGreenPepper[i];
                }
            }
        }
        if (toppingNumber == Constants.Toppings.mushroom)
        {
            for (int i = 0; i < PooledMushroom.Count; i++)
            {
                if (!PooledMushroom[i].gameObject.activeInHierarchy)
                {
                    return PooledMushroom[i];
                }
            }
        }
        else if (toppingNumber == Constants.Toppings.hotPepper)
        {
            for (int i = 0; i < PooledHotPepper.Count; i++)
            {
                if (!PooledHotPepper[i].gameObject.activeInHierarchy)
                {
                    return PooledHotPepper[i];
                }
            }
        }
        else if (toppingNumber == Constants.Toppings.pineapple)
        {
            for (int i = 0; i < PooledPineapple.Count; i++)
            {
                if (!PooledPineapple[i].gameObject.activeInHierarchy)
                {
                    return PooledPineapple[i];
                }
            }
        }

        Debug.LogWarning("No topping returned.");
        return null;
    }
}
