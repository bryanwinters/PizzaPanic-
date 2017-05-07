using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaClass : MonoBehaviour {

    Constants.Toppings Toppings;
    //int[] ToppingsCount = new int[10];
    //0 - dough size
    //1 - sauce
    //2 - cheese
    //3 - pepperoni
    //4 - bacon
    //5 - anchovies
    //6 - greenpepper
    //7 - mushroom
    //8 - hotpepper
    //9 - pineapple
    //10 - spinach
    //
    //i dont know what mel wrote

    int doughSize;
    int sauceAmount;
    int cheeseAmount;
    int pepperoniAmount;
    int baconAmount;
    int anchoviesAmount;
    int greenPepperAmount;
    int mushroomAmount;
    int hotPepperAmount;
    int pineappleAmount;
    int spinachAmount;

    float totalDistance, averageDistance;

    // Use this for initialization
    void Start ()
    {
        totalDistance = 0;
        averageDistance = 0;
        for ( int x = 0; x < PizzaManager.SharedInstance.doughMeshScript.BonePos.Length; x++ )
        {

            totalDistance += Vector3.Distance(PizzaManager.SharedInstance.doughMeshScript.BonePos[x].position, PizzaManager.SharedInstance.currentPizzaObject.transform.position);
        }
        Debug.Log("Starting Pizza total: " + totalDistance);
        averageDistance = totalDistance / PizzaManager.SharedInstance.doughMeshScript.BonePos.Length;
        Debug.Log("Starting Pizza average: " + averageDistance);


    }
	
	// Update is called once per frame
	void Update () {
        if( Input.GetKeyDown(KeyCode.K))
        {
            totalDistance = 0;
            averageDistance = 0;
            for (int x = 0; x < PizzaManager.SharedInstance.doughMeshScript.BonePos.Length; x++)
            {
                totalDistance += Vector3.Distance(PizzaManager.SharedInstance.doughMeshScript.BonePos[x].position, PizzaManager.SharedInstance.currentPizzaObject.transform.position);
            }
            Debug.Log("Current pizza total: " + totalDistance);
            averageDistance = totalDistance / PizzaManager.SharedInstance.doughMeshScript.BonePos.Length;
            Debug.Log("Current pizza average: " + averageDistance);
        }
		
	}

    public void UpdateToppings ( Constants.Toppings topping, int amount )
    {
        if (topping == Constants.Toppings.dough)
        {

        }
        else if (topping == Constants.Toppings.sauce)
        {
            sauceAmount += amount;
        }
        else if (topping == Constants.Toppings.cheese)
        {
            cheeseAmount += amount;
        }
        else if (topping == Constants.Toppings.pepperoni)
        {
            pepperoniAmount += amount;
        }
        else if (topping == Constants.Toppings.bacon)
        {
            baconAmount += amount;
        }
        else if (topping == Constants.Toppings.anchovies)
        {
            anchoviesAmount += amount;
        }
        else if (topping == Constants.Toppings.greenPepper)
        {
            greenPepperAmount += amount;
        }
        else if (topping == Constants.Toppings.mushroom)
        {
            mushroomAmount += amount;
        }
        else if (topping == Constants.Toppings.hotPepper)
        {
            hotPepperAmount += amount;
        }
        else if (topping == Constants.Toppings.pineapple)
        {
            pineappleAmount += amount;
        }
        else if (topping == Constants.Toppings.spinach)
        {
            spinachAmount += amount;
        }
    }

    public int ReturnDoughScore(Constants.PizzaSizes size)
    {
        //0,1,2,3
        Constants.PizzaSizes mysize = Constants.PizzaSizes.tooSmall;

        totalDistance = 0;
        averageDistance = 0;
        for (int x = 0; x < PizzaManager.SharedInstance.doughMeshScript.BonePos.Length; x++)
        {
            totalDistance += Vector3.Distance(PizzaManager.SharedInstance.doughMeshScript.BonePos[x].position, PizzaManager.SharedInstance.currentPizzaObject.transform.position);
        }
        Debug.Log("Current pizza total: " + totalDistance);
        averageDistance = totalDistance / PizzaManager.SharedInstance.doughMeshScript.BonePos.Length;
        Debug.Log("Current pizza average: " + averageDistance);

        if( averageDistance < Constants.MIN_SMALL_PIZZA )
        {
            mysize = Constants.PizzaSizes.tooSmall;
        }
        else if( averageDistance >= Constants.MIN_SMALL_PIZZA && averageDistance <= Constants.MAX_SMALL_PIZZA)
        {
            mysize = Constants.PizzaSizes.small;
        }
        else if( averageDistance >= Constants.MIN_MEDIUM_PIZZA && averageDistance <= Constants.MAX_SMALL_PIZZA )
        {
            mysize = Constants.PizzaSizes.medium;
        }
        else if( averageDistance >= Constants.MIN_LARGE_PIZZA && averageDistance <= Constants.MAX_LARGE_PIZZA)
        {
            mysize = Constants.PizzaSizes.large;
        }
        else if( averageDistance >= Constants.MAX_LARGE_PIZZA)
        {
            mysize = Constants.PizzaSizes.tooLarge;
        }

        if( mysize == size )
        {
            return 0;
        }
        else if( mysize > size )
        {
            return -10;
        }
        else if( mysize < size)
        {
            return -15;
        }

        Debug.LogWarning("failed check");
        return 0;
        

    }

    public int ReturnSauceAmount()
    {
        return sauceAmount;
    }
    public int ReturnCheeseAmount ()
    {
        return cheeseAmount;
    }
    public int ReturnPepperoniAmount()
    {
        return pepperoniAmount;
    }
    public int ReturnBaconAmount ()
    {
        return baconAmount;
    }
    public int ReturnAnchoviesAmount ()
    {
        return anchoviesAmount;
    }
    public int ReturnGreenPepperAmount ()
    {
        return greenPepperAmount;
    }
    public int ReturnMushroomAmount ()
    {
        return mushroomAmount;
    }
    public int ReturnHotPepperAmount ()
    {
        return hotPepperAmount;
    }
    public int ReturnPineappleAmount ()
    {
        return pineappleAmount;
    }
    public int ReturnSpinachAmount ()
    {
        return spinachAmount;
    }

    public int CalculateDoughSize()
    {
        return 1;
    }
}
