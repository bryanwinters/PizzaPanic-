﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaOrders : MonoBehaviour {

    //enum PizzaSizes { small = 0, medium, large};
    Constants.PizzaSizes PizzaOrderSize;
    enum ToppingAmounts { light = 0, regular, extra};

    PizzaClass CustomersPizza;
    int PizzaScore = 100;

    int minSpecialOrder = 0;
    int maxSpecialOrder = 8;

    bool NoSauce = true;
    ToppingAmounts SauceAmount = ToppingAmounts.regular;
    Vector2 LightSauce = new Vector2(15f, 40f);
    Vector2 MediumSauce = new Vector2(40f, 90f);
    Vector2 ExtraSauce = new Vector2(90f, 150f);

    bool NoCheese = true;
    ToppingAmounts CheeseAmount = ToppingAmounts.regular;
    Vector2 LightCheese = new Vector2(30f, 60f);
    Vector2 MediumCheese = new Vector2(60f, 90f);
    Vector2 ExtraCheese = new Vector2(90f, 150f);

    bool NoPepperoni = true;
    ToppingAmounts PepperoniAmount = ToppingAmounts.regular;
    Vector2 LightPepperoni = new Vector2(5f, 10f);
    Vector2 MediumPepperoni = new Vector2(10f, 20f);
    Vector2 ExtraPepperoni = new Vector2(20f, 50f);

    bool NoBacon = true;
    ToppingAmounts BaconAmount = ToppingAmounts.regular;
    Vector2 LightBacon = new Vector2(5f, 10f);
    Vector2 MediumBacon = new Vector2(10f, 15f);
    Vector2 ExtraBacon = new Vector2(15f, 20f);

    bool NoAnchovies = true;
    ToppingAmounts AnchoviesAmount = ToppingAmounts.regular;
    Vector2 LightAnchovies = new Vector2(5f, 10f);
    Vector2 MediumAnchovies = new Vector2(10f, 15f);
    Vector2 ExtraAnchovies = new Vector2(15f, 20f);

    bool NoGreenPepper = true;
    ToppingAmounts GreenPepperAmount = ToppingAmounts.regular;
    Vector2 LightGreenPepper = new Vector2(5f, 10f);
    Vector2 MediumGreenPepper = new Vector2(10f, 15f);
    Vector2 ExtraGreenPepper = new Vector2(15f, 20f);

    bool NoMushroom = true;
    ToppingAmounts MushroomAmount = ToppingAmounts.regular;
    Vector2 LightMushroom = new Vector2(5f, 10f);
    Vector2 MediumMushroom = new Vector2(10f, 15f);
    Vector2 ExtraMushroom = new Vector2(15f, 20f);

    bool NoHotPepper = true;
    ToppingAmounts HotPepperAmount = ToppingAmounts.regular;
    Vector2 LightHotPepper = new Vector2(5f, 10f);
    Vector2 MediumHotPepper = new Vector2(10f, 15f);
    Vector2 ExtraHotPepper = new Vector2(15f, 20f);

    bool NoPineapple = true;
    ToppingAmounts PineappleAmount = ToppingAmounts.regular;
    Vector2 LightPineapple = new Vector2(5f, 10f);
    Vector2 MediumPineapple = new Vector2(10f, 15f);
    Vector2 ExtraPineapple = new Vector2(15f, 20f);

    bool NoSpinach = true;
    ToppingAmounts SpinachAmount = ToppingAmounts.regular;
    Vector2 LightSpinach = new Vector2(5f, 10f);
    Vector2 MediumSpinach = new Vector2(10f, 15f);
    Vector2 ExtraSpinach = new Vector2(15f, 20f);

    int toppingToCheck;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.X))
        {
            CreateOrder();
        }
	}

    public void CreateOrder ()
    {
        Debug.Log("Order Incoming!");
        int size = Random.Range(0, 3);
        PizzaOrderSize = (Constants.PizzaSizes)size;
        Debug.Log(PizzaOrderSize.ToString() + " pizza.");

        int sauceMyPizza = Random.Range(0, 10);
        if( sauceMyPizza == minSpecialOrder )
        {
            //nosauce
            Debug.Log("NO SAUCE.");
        }
        else
        {
            int sauceOrder = Random.Range(0, 10);
            NoSauce = false;
            if( sauceOrder <= minSpecialOrder )
            {
                SauceAmount = ToppingAmounts.light;
                Debug.Log("Light Sauce.");
            }
            else if( sauceOrder >= maxSpecialOrder )
            {
                SauceAmount = ToppingAmounts.extra;
                Debug.Log("Extra Sauce.");
            }
            else
            {
                SauceAmount = ToppingAmounts.regular;
                Debug.Log("Regular Sauce.");
            }
        }


        int cheeseMyPizza = Random.Range(0, 10);
        if (cheeseMyPizza == minSpecialOrder)
        {
            //nocheese
            Debug.Log("NO CHEESE!");
        }
        else
        {
            NoCheese = false;
            int cheeseOrder = Random.Range(0, 10);
            if (cheeseOrder <= minSpecialOrder)
            {
                CheeseAmount = ToppingAmounts.light;
                Debug.Log("Light Cheese.");
            }
            else if (cheeseOrder >= maxSpecialOrder)
            {
                CheeseAmount = ToppingAmounts.extra;
                Debug.Log("Extra Cheese.");
            }
            else
            {
                CheeseAmount = ToppingAmounts.regular;
                Debug.Log("Regular Cheese.");
            }
        }

        int NumberOfToppings = Random.Range(1, 9);
        //int[] ToppingsOrder = new int[NumberOfToppings];
        List<int> RandomToppings = new List<int>();
        List<int> ToppingsList = new List<int>();

        for (int x = 0; x < 8; x++)
        {
            ToppingsList.Add(x);
        }

        //randomize the toppings here
        for (int x = 0; x < 8; x++)
        {
            int number = Random.Range(0, ToppingsList.Count);
            RandomToppings.Add(ToppingsList[number]);
            ToppingsList.RemoveAt(number);
            //Debug.LogError("Post Removal: " + ToppingsList[number]);
        }

        int ToppingsOrderCounter = 0;

        for (int x = 0; x < NumberOfToppings; x++)
        {
            if( RandomToppings[x] == 0 )
            {
                //do pepperoni
                NoPepperoni = false;
                int specialOrder = Random.Range(0, 10);
                if( specialOrder <= minSpecialOrder)
                {
                    PepperoniAmount = ToppingAmounts.light;
                    Debug.Log("Light Pepperoni.");
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    PepperoniAmount = ToppingAmounts.extra;
                    Debug.Log("Extra Pepperoni.");
                }
                else
                {
                    Debug.Log("Pepperoni.");
                }
            }
            else if (RandomToppings[x] == 1)
            {
                //do bacon
                NoBacon = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    BaconAmount = ToppingAmounts.light;
                    Debug.Log("Light Bacon.");
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    BaconAmount = ToppingAmounts.extra;
                    Debug.Log("Extra Bacon.");
                }
                else
                {
                    Debug.Log("Bacon.");
                }
            }
            else if (RandomToppings[x] == 2)
            {
                //do anchovies
                NoAnchovies = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    AnchoviesAmount = ToppingAmounts.light;
                    Debug.Log("Light Anchovies.");
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    AnchoviesAmount = ToppingAmounts.extra;
                    Debug.Log("Extra Anchovies.");
                }
                else
                {
                    Debug.Log("Anchovies.");
                }
            }
            else if (RandomToppings[x] == 3)
            {
                //do greenpepper
                NoGreenPepper = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    GreenPepperAmount = ToppingAmounts.light;
                    Debug.Log("Light GreenPepper.");
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    GreenPepperAmount = ToppingAmounts.extra;
                    Debug.Log("Extra GreenPepper.");
                }
                else
                {
                    Debug.Log("GreenPepper.");
                }
            }
            else if (RandomToppings[x] == 4)
            {
                //do mushroom
                NoMushroom = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    MushroomAmount = ToppingAmounts.light;
                    Debug.Log("Light Mushroom.");
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    MushroomAmount = ToppingAmounts.extra;
                    Debug.Log("Extra Mushroom.");
                }
                else
                {
                    Debug.Log("Mushroom.");
                }
            }
            else if (RandomToppings[x] == 5)
            {
                //do hotppepper
                NoHotPepper = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    HotPepperAmount = ToppingAmounts.light;
                    Debug.Log("Light HotPepper.");
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    HotPepperAmount = ToppingAmounts.extra;
                    Debug.Log("Extra HotPepper.");
                }
                else
                {
                    Debug.Log("HotPepper.");
                }
            }
            else if (RandomToppings[x] == 6)
            {
                //do pineapple
                NoPineapple = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    PineappleAmount = ToppingAmounts.light;
                    Debug.Log("Light Pineapple.");
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    PineappleAmount = ToppingAmounts.extra;
                    Debug.Log("Extra Pineapple.");
                }
                else
                {
                    Debug.Log("Pineapple.");
                }
            }
            else if (RandomToppings[x] == 7)
            {
                //do spinach
                NoSpinach = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    SpinachAmount = ToppingAmounts.light;
                    Debug.Log("Light Spinach.");
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    SpinachAmount = ToppingAmounts.extra;
                    Debug.Log("Extra Spinach.");
                }
                else
                {
                    Debug.Log("Spinach.");
                }
            }
            else
            {
                Debug.LogError("oops.");
            }
        }
        Debug.Log("Order ended.");
    }

    public void DeliverPizza ( PizzaClass pizza )
    {
        CustomersPizza = pizza;
    }

    public int ScorePizza ()
    {
        //score dough
        PizzaScore += CustomersPizza.ReturnDoughScore(PizzaOrderSize);



        //score sauce
        //Debug.LogWarning("Score sauce");
        toppingToCheck = CustomersPizza.ReturnSauceAmount();
        ScoreTopping(toppingToCheck, NoSauce, SauceAmount, LightSauce, MediumSauce, ExtraSauce);
        //score cheese
        //Debug.LogWarning("Score cheese");
        toppingToCheck = CustomersPizza.ReturnCheeseAmount();
        ScoreTopping(toppingToCheck, NoCheese, CheeseAmount, LightCheese, MediumCheese, ExtraCheese);
        //score pepperoni
        //Debug.LogWarning("Score pepperoni");
        toppingToCheck = CustomersPizza.ReturnPepperoniAmount();
        ScoreTopping(toppingToCheck, NoPepperoni, PepperoniAmount, LightPepperoni, MediumPepperoni, ExtraPepperoni);
        //score bacon
        //Debug.LogWarning("Score bacon");
        toppingToCheck = CustomersPizza.ReturnBaconAmount();
        ScoreTopping(toppingToCheck, NoBacon, BaconAmount, LightBacon, MediumBacon, ExtraBacon);
        //score anchovies
        //Debug.LogWarning("Score anchovies");
        toppingToCheck = CustomersPizza.ReturnAnchoviesAmount();
        ScoreTopping(toppingToCheck, NoAnchovies, AnchoviesAmount, LightAnchovies, MediumAnchovies, ExtraAnchovies);
        //score green pepper
        //Debug.LogWarning("Score greenpepper");
        toppingToCheck = CustomersPizza.ReturnGreenPepperAmount();
        ScoreTopping(toppingToCheck, NoGreenPepper, GreenPepperAmount, LightGreenPepper, MediumGreenPepper, ExtraGreenPepper);
        //score mushroom
        //Debug.LogWarning("Score mushroom");
        toppingToCheck = CustomersPizza.ReturnMushroomAmount();
        ScoreTopping(toppingToCheck, NoMushroom, MushroomAmount, LightMushroom, MediumMushroom, ExtraMushroom);
        //score hot pepper
        //Debug.LogWarning("Score hotpepper");
        toppingToCheck = CustomersPizza.ReturnHotPepperAmount();
        ScoreTopping(toppingToCheck, NoHotPepper, HotPepperAmount, LightHotPepper, MediumHotPepper, ExtraHotPepper);
        //score pineapple
        //Debug.LogWarning("Score pineapple");
        toppingToCheck = CustomersPizza.ReturnPineappleAmount();
        ScoreTopping(toppingToCheck, NoPineapple, PineappleAmount, LightPineapple, MediumPineapple, ExtraPineapple);
        //score spinach
        //Debug.LogWarning("Score spinach");
        toppingToCheck = CustomersPizza.ReturnSpinachAmount();
        ScoreTopping(toppingToCheck, NoSpinach, SpinachAmount, LightSpinach, MediumSpinach, ExtraSpinach);

        //Debug.LogError("Pizza Score: " + PizzaScore);
        return PizzaScore;
    }

    void ScoreTopping (int topp, bool isNotRequested, ToppingAmounts toppAmount, Vector2 lightTopps, Vector2 regularTopps, Vector2 extraTopps)
    {
        

        if (!isNotRequested)
        {
            
            Debug.Log("Number on pizza of current topping: " + topp);
            if (toppAmount == ToppingAmounts.light)
            {
                Debug.Log("Entered light");
                if (topp > lightTopps.x && topp < lightTopps.y)
                {
                    //dont deduct points
                    Debug.LogWarning("Score 1");
                }
                else if (topp < lightTopps.x)
                {
                    //PizzaScore -= Mathf.Abs((topp - lightTopps.x));
                    DeductScore(10);
                    Debug.LogWarning("Score 2");
                }
                else if (topp > lightTopps.y)
                {
                    //PizzaScore -= Mathf.Abs(lightTopps.y - topp) * 2;
                    DeductScore(20);
                    Debug.LogWarning("Score 3");
                }
            }
            else if (toppAmount == ToppingAmounts.regular)
            {
                Debug.Log("Entered regular");
                if (topp > regularTopps.x && topp < regularTopps.y)
                {
                    //dont deduct points
                    Debug.LogWarning("Score 4");
                }
                else if (topp < regularTopps.x)
                {
                    //PizzaScore -= Mathf.Abs((topp - regularTopps.x));
                    DeductScore(10);
                    Debug.LogWarning("Score 5");
                }
                else if (topp > regularTopps.y)
                {
                    //PizzaScore -= Mathf.Abs(regularTopps.y - topp) * 2;
                    DeductScore(20);
                    Debug.LogWarning("Score 6");
                }
            }
            else if (toppAmount == ToppingAmounts.extra)
            {
                Debug.Log("Entered extra");
                if (topp > extraTopps.x && topp < extraTopps.y)
                {
                    //dont deduct points
                    Debug.LogWarning("Score 7");
                }
                else if (topp < extraTopps.x)
                {
                    //PizzaScore -= Mathf.Abs((topp - extraTopps.x));
                    DeductScore(5);
                    Debug.LogWarning("Score 8");
                }
                else if (topp > extraTopps.y)
                {
                    //PizzaScore -= Mathf.Abs(extraTopps.y - topp) * 2;
                    DeductScore(10);
                    Debug.LogWarning("Score 9");
                }
            }
        }
        else if (isNotRequested)
        {
            Debug.Log("Entered not requested");
            if (topp > 0)
            {
                DeductScore(20);
                Debug.LogWarning("I SAID NO");
            }
        }
    }

    void DeductScore (int points)
    {
        PizzaScore -= points;
    }
}
