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
        mushroom = 7, hotPepper = 8, pineapple = 9, spinach = 10*/
    List<PizzaToppingUnifier> PooledSauce = new List<PizzaToppingUnifier>();
    List<PizzaToppingUnifier> PooledCheese = new List<PizzaToppingUnifier>();
    List<PizzaToppingUnifier> PooledPepperoni = new List<PizzaToppingUnifier>();
    List<PizzaToppingUnifier> PooledBacon = new List<PizzaToppingUnifier>();
    List<PizzaToppingUnifier> PooledAnchovies = new List<PizzaToppingUnifier>();
    List<PizzaToppingUnifier> PooledGreenPepper = new List<PizzaToppingUnifier>();
    List<PizzaToppingUnifier> PooledMushroom = new List<PizzaToppingUnifier>();
    List<PizzaToppingUnifier> PooledHotPepper = new List<PizzaToppingUnifier>();
    List<PizzaToppingUnifier> PooledPineapple = new List<PizzaToppingUnifier>();
    List<PizzaToppingUnifier> PooledSpinach = new List<PizzaToppingUnifier>();
    //make lists of toppings to pool and do that

    public GameObject[] sauce, cheese, pepperoni, bacon, anchovies, greenpepper, mushroom, hotpepper, pineapple, spinach;
    public int amountToPool;

	// Use this for initialization
	void Start () {

        if (sauce != null)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                int objCounter = 0;
                if (sauce.Length > 1)
                {
                    objCounter = Random.Range(0, sauce.Length);
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

        if (cheese != null)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                int objCounter = 0;
                if (cheese.Length > 1)
                {
                    objCounter = Random.Range(0, cheese.Length);
                }
                else
                {
                    objCounter = 0;
                }
                GameObject obj = (GameObject)Instantiate(cheese[objCounter], gameObject.transform.position, Quaternion.Euler(-90f, 0f, 0f));
                PizzaToppingUnifier p = obj.GetComponent<PizzaToppingUnifier>();
                //obj.transform.Rotate(Vector3.right, 90f);
                p.gameObject.SetActive(false);
                PooledCheese.Add(p);
            }
        }

        if ( pepperoni != null )
        {
            int objCounter = 0;
            if (pepperoni.Length > 1)
            {
                objCounter = Random.Range(0, pepperoni.Length);
            }
            else
            {
                objCounter = 0;
            }
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(pepperoni[objCounter]);
                PizzaToppingUnifier p = obj.GetComponent<PizzaToppingUnifier>();
                p.gameObject.SetActive(false);
                PooledPepperoni.Add(p);
            }
        }

        if (bacon != null)
        {
            int objCounter = 0;
            if (bacon.Length > 1)
            {
                objCounter = Random.Range(0, bacon.Length);
            }
            else
            {
                objCounter = 0;
            }
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(bacon[objCounter]);
                PizzaToppingUnifier p = obj.GetComponent<PizzaToppingUnifier>();
                p.gameObject.SetActive(false);
                PooledBacon.Add(p);
            }
        }

        if (anchovies != null)
        {
            int objCounter = 0;
            if (anchovies.Length > 1)
            {
                objCounter = Random.Range(0, anchovies.Length);
            }
            else
            {
                objCounter = 0;
            }
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(anchovies[objCounter]);
                PizzaToppingUnifier p = obj.GetComponent<PizzaToppingUnifier>();
                p.gameObject.SetActive(false);
                PooledAnchovies.Add(p);
            }
        }

        if (greenpepper != null)
        {
            int objCounter = 0;
            if (greenpepper.Length > 1)
            {
                objCounter = Random.Range(0, greenpepper.Length);
            }
            else
            {
                objCounter = 0;
            }
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(greenpepper[objCounter]);
                PizzaToppingUnifier p = obj.GetComponent<PizzaToppingUnifier>();
                p.gameObject.SetActive(false);
                PooledGreenPepper.Add(p);
            }
        }

        if (mushroom != null)
        {
            int objCounter = 0;
            if (mushroom.Length > 1)
            {
                objCounter = Random.Range(0, mushroom.Length);
            }
            else
            {
                objCounter = 0;
            }
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(mushroom[objCounter]);
                PizzaToppingUnifier p = obj.GetComponent<PizzaToppingUnifier>();
                p.gameObject.SetActive(false);
                PooledMushroom.Add(p);
            }
        }

        if (hotpepper != null)
        {
            int objCounter = 0;
            if (hotpepper.Length > 1)
            {
                objCounter = Random.Range(0, hotpepper.Length);
            }
            else
            {
                objCounter = 0;
            }
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(hotpepper[objCounter]);
                PizzaToppingUnifier p = obj.GetComponent<PizzaToppingUnifier>();
                p.gameObject.SetActive(false);
                PooledHotPepper.Add(p);
            }
        }

        if (pineapple != null)
        {
            int objCounter = 0;
            if (pineapple.Length > 1)
            {
                objCounter = Random.Range(0, pineapple.Length);
            }
            else
            {
                objCounter = 0;
            }
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(pineapple[objCounter]);
                PizzaToppingUnifier p = obj.GetComponent<PizzaToppingUnifier>();
                p.gameObject.SetActive(false);
                PooledPineapple.Add(p);
            }
        }

        if (spinach != null)
        {
            int objCounter = 0;
            if (spinach.Length > 1)
            {
                objCounter = Random.Range(0, spinach.Length);
            }
            else
            {
                objCounter = 0;
            }
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(spinach[objCounter]);
                PizzaToppingUnifier p = obj.GetComponent<PizzaToppingUnifier>();
                p.gameObject.SetActive(false);
                PooledSpinach.Add(p);
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
        else if (toppingNumber == Constants.Toppings.spinach)
        {
            for (int i = 0; i < PooledSpinach.Count; i++)
            {
                if (!PooledSpinach[i].gameObject.activeInHierarchy)
                {
                    return PooledSpinach[i];
                }
            }
        }

        Debug.LogWarning("No topping returned.");
        return null;
    }
}
