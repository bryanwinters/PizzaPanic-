using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PizzaOrders : MonoBehaviour {

    //enum PizzaSizes { small = 0, medium, large};
    public Constants.PizzaSizes PizzaOrderSize;
    enum ToppingAmounts { light = 0, regular, extra};

    PizzaClass CustomersPizza;
    int PizzaScore = 100;

    int minimumToppings, maximumToppings;

    int minSpecialOrder = 0;
    int maxSpecialOrder = 8;

    bool NoSauce = true;
    ToppingAmounts SauceAmount = ToppingAmounts.regular;

    bool NoCheese = true;
    ToppingAmounts CheeseAmount = ToppingAmounts.regular;

    bool NoPepperoni = true;
    ToppingAmounts PepperoniAmount = ToppingAmounts.regular;

    bool NoBacon = true;
    ToppingAmounts BaconAmount = ToppingAmounts.regular;

    bool NoAnchovies = true;
    ToppingAmounts AnchoviesAmount = ToppingAmounts.regular;

    bool NoGreenPepper = true;
    ToppingAmounts GreenPepperAmount = ToppingAmounts.regular;

    bool NoMushroom = true;
    ToppingAmounts MushroomAmount = ToppingAmounts.regular;

    bool NoHotPepper = true;
    ToppingAmounts HotPepperAmount = ToppingAmounts.regular;

    bool NoPineapple = true;
    ToppingAmounts PineappleAmount = ToppingAmounts.regular;

    bool NoSpinach = true;
    ToppingAmounts SpinachAmount = ToppingAmounts.regular;

    Constants.Toppings toppingToCheck;
    int NumberOfTopping = 0;

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
        int size = Random.Range(1, 4);
        PizzaOrderSize = (Constants.PizzaSizes)size;

        MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.dough, size);

        Debug.Log(PizzaOrderSize.ToString() + " pizza.");

        int sauceMyPizza = Random.Range(0, 10);
        if( sauceMyPizza == minSpecialOrder )
        {
            //nosauce
            Debug.Log("NO SAUCE.");
            MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.sauce, 0);
        }
        else
        {
            int sauceOrder = Random.Range(0, 10);
            NoSauce = false;
            if( sauceOrder <= minSpecialOrder )
            {
                SauceAmount = ToppingAmounts.light;
                Debug.Log("Light Sauce.");
                MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.sauce, 1);
            }
            else if( sauceOrder >= maxSpecialOrder )
            {
                SauceAmount = ToppingAmounts.extra;
                Debug.Log("Extra Sauce.");
                MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.sauce, 3);
            }
            else
            {
                SauceAmount = ToppingAmounts.regular;
                Debug.Log("Regular Sauce.");
                MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.sauce, 2);
            }
        }


        int cheeseMyPizza = Random.Range(0, 10);
        if (cheeseMyPizza == minSpecialOrder)
        {
            //nocheese
            Debug.Log("NO CHEESE!");
            MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.cheese, 0);
        }
        else
        {
            NoCheese = false;
            int cheeseOrder = Random.Range(0, 10);
            if (cheeseOrder <= minSpecialOrder)
            {
                CheeseAmount = ToppingAmounts.light;
                Debug.Log("Light Cheese.");
                MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.cheese, 1);
            }
            else if (cheeseOrder >= maxSpecialOrder)
            {
                CheeseAmount = ToppingAmounts.extra;
                Debug.Log("Extra Cheese.");
                MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.cheese, 3);
            }
            else
            {
                CheeseAmount = ToppingAmounts.regular;
                Debug.Log("Regular Cheese.");
                MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.cheese, 2);
            }
        }

        Debug.LogWarning("start toppings");
        List<Constants.PlayerToppings> RandomToppings = new List<Constants.PlayerToppings>(MenuManager.Instance.AvailableToppingsForPlayers);
        int NumberOfToppings = Random.Range(0, RandomToppings.Count);

        //shuffle list
        for (int i = 0; i < RandomToppings.Count; i++)
        {
            Constants.PlayerToppings temp = RandomToppings[i];
            int randomIndex = Random.Range(i, RandomToppings.Count);
            RandomToppings[i] = RandomToppings[randomIndex];
            RandomToppings[randomIndex] = temp;
        }

        MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.pepperoni, 0);
        MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.bacon, 0);
        MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.anchovies, 0);
        MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.pineapple, 0);
        MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.greenPepper, 0);
        MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.hotPepper, 0);
        MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.mushroom, 0);
        MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.spinach, 0);

        for (int x = 0; x <= NumberOfToppings; x++)
        {
            if( RandomToppings[x] == Constants.PlayerToppings.pepperoni )
            {
                //do pepperoni
                NoPepperoni = false;
                int specialOrder = Random.Range(0, 10);
                if( specialOrder <= minSpecialOrder)
                {
                    PepperoniAmount = ToppingAmounts.light;
                    Debug.Log("Light Pepperoni.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.pepperoni, 1);
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    PepperoniAmount = ToppingAmounts.extra;
                    Debug.Log("Extra Pepperoni.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.pepperoni, 3);
                }
                else
                {
                    Debug.Log("Pepperoni.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.pepperoni, 2);
                }
            }
            else if (RandomToppings[x] == Constants.PlayerToppings.bacon)
            {
                //do bacon
                NoBacon = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    BaconAmount = ToppingAmounts.light;
                    Debug.Log("Light Bacon.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.bacon, 1);
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    BaconAmount = ToppingAmounts.extra;
                    Debug.Log("Extra Bacon.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.bacon, 3);
                }
                else
                {
                    Debug.Log("Bacon.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.bacon, 2);
                }
            }
            else if (RandomToppings[x] == Constants.PlayerToppings.anchovies)
            {
                //do anchovies
                NoAnchovies = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    AnchoviesAmount = ToppingAmounts.light;
                    Debug.Log("Light Anchovies.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.anchovies, 1);
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    AnchoviesAmount = ToppingAmounts.extra;
                    Debug.Log("Extra Anchovies.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.anchovies, 3);
                }
                else
                {
                    Debug.Log("Anchovies.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.anchovies, 2);
                }
            }
            else if (RandomToppings[x] == Constants.PlayerToppings.greenPepper)
            {
                //do greenpepper
                NoGreenPepper = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    GreenPepperAmount = ToppingAmounts.light;
                    Debug.Log("Light GreenPepper.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.greenPepper, 1);
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    GreenPepperAmount = ToppingAmounts.extra;
                    Debug.Log("Extra GreenPepper.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.greenPepper, 3);
                }
                else
                {
                    Debug.Log("GreenPepper.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.greenPepper, 2);
                }
            }
            else if (RandomToppings[x] == Constants.PlayerToppings.mushroom)
            {
                //do mushroom
                NoMushroom = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    MushroomAmount = ToppingAmounts.light;
                    Debug.Log("Light Mushroom.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.mushroom, 1);
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    MushroomAmount = ToppingAmounts.extra;
                    Debug.Log("Extra Mushroom.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.mushroom, 3);
                }
                else
                {
                    Debug.Log("Mushroom.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.mushroom, 2);
                }
            }
            else if (RandomToppings[x] == Constants.PlayerToppings.hotPepper)
            {
                //do hotppepper
                NoHotPepper = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    HotPepperAmount = ToppingAmounts.light;
                    Debug.Log("Light HotPepper.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.hotPepper, 1);
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    HotPepperAmount = ToppingAmounts.extra;
                    Debug.Log("Extra HotPepper.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.hotPepper, 3);
                }
                else
                {
                    Debug.Log("HotPepper.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.hotPepper, 2);
                }
            }
            else if (RandomToppings[x] == Constants.PlayerToppings.pineapple)
            {
                //do pineapple
                NoPineapple = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    PineappleAmount = ToppingAmounts.light;
                    Debug.Log("Light Pineapple.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.pineapple, 1);
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    PineappleAmount = ToppingAmounts.extra;
                    Debug.Log("Extra Pineapple.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.pineapple, 3);
                }
                else
                {
                    Debug.Log("Pineapple.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.pineapple, 2);
                }
            }
            else if (RandomToppings[x] == Constants.PlayerToppings.spinach)
            {
                //do spinach
                NoSpinach = false;
                int specialOrder = Random.Range(0, 10);
                if (specialOrder <= minSpecialOrder)
                {
                    SpinachAmount = ToppingAmounts.light;
                    Debug.Log("Light Spinach.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.spinach, 1);
                }
                else if (specialOrder >= maxSpecialOrder)
                {
                    SpinachAmount = ToppingAmounts.extra;
                    Debug.Log("Extra Spinach.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.spinach, 3);
                }
                else
                {
                    Debug.Log("Spinach.");
                    MenuManager.Instance.HUD.HandleNewPizza(Constants.Toppings.spinach, 2);
                }
            }
            else
            {
                Debug.Log("missing: " + RandomToppings[x].ToString());
                Debug.LogError("oops. " + x);
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
        //PizzaScore += CustomersPizza.ReturnDoughScore(PizzaOrderSize);



        //score sauce
        //Debug.LogWarning("Score sauce");
        NumberOfTopping = CustomersPizza.ReturnSauceAmount();
        toppingToCheck = Constants.Toppings.sauce;
        ScoreTopping(toppingToCheck, NumberOfTopping, NoSauce, SauceAmount, PizzaOrderSize );
        //score cheese
        //Debug.LogWarning("Score cheese");
        NumberOfTopping = CustomersPizza.ReturnCheeseAmount();
        toppingToCheck = Constants.Toppings.cheese;
        ScoreTopping(toppingToCheck, NumberOfTopping, NoCheese, CheeseAmount, PizzaOrderSize);
        //score pepperoni
        //Debug.LogWarning("Score pepperoni");
        NumberOfTopping = CustomersPizza.ReturnPepperoniAmount();
        toppingToCheck = Constants.Toppings.pepperoni;
        ScoreTopping(toppingToCheck, NumberOfTopping, NoPepperoni, PepperoniAmount, PizzaOrderSize);
        //score bacon
        //Debug.LogWarning("Score bacon");
        NumberOfTopping = CustomersPizza.ReturnBaconAmount();
        toppingToCheck = Constants.Toppings.bacon;
        ScoreTopping(toppingToCheck, NumberOfTopping, NoBacon, BaconAmount, PizzaOrderSize);
        //score anchovies
        //Debug.LogWarning("Score anchovies");
        NumberOfTopping = CustomersPizza.ReturnAnchoviesAmount();
        toppingToCheck = Constants.Toppings.anchovies;
        ScoreTopping(toppingToCheck, NumberOfTopping, NoAnchovies, AnchoviesAmount, PizzaOrderSize);
        //score green pepper
        //Debug.LogWarning("Score greenpepper");
        NumberOfTopping = CustomersPizza.ReturnGreenPepperAmount();
        toppingToCheck = Constants.Toppings.greenPepper;
        ScoreTopping(toppingToCheck, NumberOfTopping, NoGreenPepper, GreenPepperAmount, PizzaOrderSize);
        //score mushroom
        //Debug.LogWarning("Score mushroom");
        NumberOfTopping = CustomersPizza.ReturnMushroomAmount();
        toppingToCheck = Constants.Toppings.mushroom;
        ScoreTopping(toppingToCheck, NumberOfTopping, NoMushroom, MushroomAmount, PizzaOrderSize);
        //score hot pepper
        //Debug.LogWarning("Score hotpepper");
        NumberOfTopping = CustomersPizza.ReturnHotPepperAmount();
        toppingToCheck = Constants.Toppings.hotPepper;
        ScoreTopping(toppingToCheck, NumberOfTopping, NoHotPepper, HotPepperAmount, PizzaOrderSize);
        //score pineapple
        //Debug.LogWarning("Score pineapple");
        NumberOfTopping = CustomersPizza.ReturnPineappleAmount();
        toppingToCheck = Constants.Toppings.pineapple;
        ScoreTopping(toppingToCheck, NumberOfTopping, NoPineapple, PineappleAmount, PizzaOrderSize);
        //score spinach
        //Debug.LogWarning("Score spinach");
        NumberOfTopping = CustomersPizza.ReturnSpinachAmount();
        toppingToCheck = Constants.Toppings.spinach;
        ScoreTopping(toppingToCheck, NumberOfTopping, NoSpinach, SpinachAmount, PizzaOrderSize);

        //Debug.LogError("Pizza Score: " + PizzaScore);
        return Mathf.Clamp(PizzaScore, 0, 100);
    }

    void ScoreTopping (Constants.Toppings toppingType, int numberOftoppingsOnPizza, bool isNotRequested, ToppingAmounts toppAmount, Constants.PizzaSizes pizzasize )//, Vector2 lightTopps, Vector2 regularTopps, Vector2 extraTopps)
    {
        int toppingSizeModifier = Constants.SMALL_TOPPING_MODIFIER;
        int toppingSizeModifierMax = toppingSizeModifier + 1;

        if( pizzasize == Constants.PizzaSizes.medium )
        {
            toppingSizeModifier = Constants.MEDIUM_TOPPING_MODIFIER;
            toppingSizeModifierMax = toppingSizeModifier + 1;

        }
        else if( pizzasize == Constants.PizzaSizes.large )
        {
            toppingSizeModifier = Constants.LARGE_TOPPING_MODIFIER;
            toppingSizeModifierMax = toppingSizeModifier + 1;
        }

        int toppingExtraModifier = Constants.LIGHT_TOPPING_MODIFIER;

        if (toppAmount == ToppingAmounts.regular)
        {
            toppingExtraModifier = Constants.REGULAR_TOPPING_MODIFIER;
        }
        else if (toppAmount == ToppingAmounts.extra)
        {
            toppingExtraModifier = Constants.EXTRA_TOPPING_MODIFIER;
        }



        if (toppingType == Constants.Toppings.sauce)
        {
            minimumToppings = Constants.DEFAULT_SAUCE_AMOUNT * toppingSizeModifier * toppingExtraModifier;
            maximumToppings = Constants.DEFAULT_SAUCE_AMOUNT * toppingSizeModifierMax * toppingExtraModifier;
        }
        else if(toppingType == Constants.Toppings.cheese )
        {
            minimumToppings = Constants.DEFAULT_CHEESE_AMOUNT * toppingSizeModifier * toppingExtraModifier;
            maximumToppings = Constants.DEFAULT_CHEESE_AMOUNT * toppingSizeModifierMax * toppingExtraModifier;
        }
        else
        {
            minimumToppings = Constants.DEFAULT_TOPPING_AMOUNT * toppingSizeModifier * toppingExtraModifier;
            maximumToppings = Constants.DEFAULT_TOPPING_AMOUNT * toppingSizeModifierMax * toppingExtraModifier;
        }
        Debug.Log("Topping: " + toppingType);
        Debug.Log("minimum toppings: " + minimumToppings);
        Debug.Log("maximum toppings: " + maximumToppings);


        if (!isNotRequested)//if requested
        {
            
            Debug.Log("Number on pizza of " + toppingType + " :" + numberOftoppingsOnPizza);
            if( numberOftoppingsOnPizza > minimumToppings && numberOftoppingsOnPizza < maximumToppings )
            {
                //dont deduct points
            }
            else if( numberOftoppingsOnPizza < minimumToppings )
            {
                DeductScore(10);
            }
            else if( numberOftoppingsOnPizza > maximumToppings )
            {
                DeductScore(10);
            }
        }
        else if (isNotRequested)
        {
            Debug.Log("Entered not requested");
            if (numberOftoppingsOnPizza > 0)
            {
                DeductScore(15);
                Debug.LogWarning("I SAID NO");
            }
        }
    }

    void DeductScore (int points)
    {
        PizzaScore -= Mathf.Abs( points);
    }
}
