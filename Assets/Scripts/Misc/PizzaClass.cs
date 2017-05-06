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
    //
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
    


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
    }
}
