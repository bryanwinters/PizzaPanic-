using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants  {

    //ENUMS
    public enum Toppings {dough = 0, sauce = 1, cheese = 2, pepperoni = 3, bacon = 4, anchovies = 5, greenPepper = 6,
        mushroom = 7, hotPepper = 8, pineapple = 9, spinach = 10}
    public enum PlayerToppings
    {
        pepperoni = 3, bacon = 4, anchovies = 5, greenPepper = 6, mushroom = 7, hotPepper = 8, pineapple = 9, spinach = 10
    }
    public enum PizzaSizes { tooSmall = 0, small, medium, large, tooLarge}
    public enum Characters {meowzzarella = 0, octopie = 1, crustodile = 2, bonemando = 3}
    public enum GameState {menu = 0, starting = 1, game = 2, end = 3, cancelStart = 4, howTo = 5}

    //NUMBERS
    //settings
    public static int MIN_PLAYERS = 1;
    public static int MAX_PLAYERS = 4;
    public static float MIN_SMALL_PIZZA = 1.7f;
    public static float MAX_SMALL_PIZZA = 1.75f;
    public static float MIN_MEDIUM_PIZZA = 1.75f;
    public static float MAX_MEDIUM_PIZZA = 1.8f;
    public static float MIN_LARGE_PIZZA = 1.8f;
    public static float MAX_LARGE_PIZZA = 1.85f;

    //gameplay
    public static float PLAYER_SPAWN_OFFSET = 5f;
    public static int GAME_STARTING_TIME = 120;
    public static Vector3 SMALL_PIZZA_SCALE = new Vector3(2.5f, 1f, 2.5f);
    public static Vector3 MEDIUM_PIZZA_SCALE = new Vector3(4f, 1f, 4f);
    public static Vector3 LARGE_PIZZA_SCALE = new Vector3(5f, 1f, 5f);

    public static int DEFAULT_CHEESE_AMOUNT = 20;
    public static int DEFAULT_SAUCE_AMOUNT = 5;
    public static int DEFAULT_TOPPING_AMOUNT = 6;

    public static int LIGHT_TOPPING_MODIFIER = 1;
    public static int REGULAR_TOPPING_MODIFIER = 2;
    public static int EXTRA_TOPPING_MODIFIER = 3;

    public static int SMALL_TOPPING_MODIFIER = 1;
    public static int MEDIUM_TOPPING_MODIFIER = 3;
    public static int LARGE_TOPPING_MODIFIER = 5;

    public static int PIZZA_FLING_MIN = 0;
    public static int PIZZA_FLING_MAX = 4;

    public static float[] SMALL_PIZZA_FLING_VALUES = new float[]{8f,11f,14f,17f,22f};
    public static float[] MEDIUM_PIZZA_FLING_VALUES = new float[]{2f,6.5f,11f,15.5f,22f};
    public static float[] LARGE_PIZZA_FLING_VALUES = new float[]{-10f,-2.5f,5f,12.5f,22f};

    //controls
    public static float CONTROLLER_TRIGGER_DEAD_ZONE = 0.5f;

    //menu
    public static int MENU_STARTING_TIME = 3;

    //layers
    public const string LAYER_PIZZA = "Pizza";
    public const string LAYER_TOPPINGS = "Toppings";
    public const string LAYER_PIZZA_TOPPINGS = "PizzaTopping";
    public const string LAYER_TOPPING_CATCHER = "ToppingCatcher";

    //STRINGS
    //input
    public const string CONTROLS_HORIZONTAL = "Horizontal";
    public const string CONTROLS_VERTICAL = "Vertical";
    public const string CONTROLS_ACTION = "Action";
    public const string CONTROLS_DASH = "Dash";
    public const string CONTROLS_DASH_RIGHT = "DashRight";
    public const string CONTROLS_DASH_LEFT = "DashLeft";
    public const string CONTROLS_CYCLE_RIGHT = "CycleRight";
    public const string CONTROLS_CYCLE_LEFT = "CycleLeft";
    public const string CONTROLS_OVEN_X = "OvenX";
    public const string CONTROLS_CANCEL = "Cancel";

    //animation
    public const string ANIMATION_PLAYER_IDLE = "Idle";
    public const string ANIMATION_PLAYER_THROW = "Throw";
    public const string ANIMATION_PLAYER_GRIP = "Grip";

    //menu
    public const string MENU_READY_PLAYERS = "Waiting For Players To Ready...";
    public const string MENU_GAME_STARTING = "Game Starting in ";
    public const string MENU_GAME_RESET = "To Reset)";

    //hud
    public const string HUD_OVEN_PREPPING_PIZZA = "Prepping";
    public const string HUD_OVEN_READY = "Ready!";

    public static Vector2[] SPAWN_POSITION = new Vector2[]{new Vector2(-1,0), new Vector2(0,1), new Vector2(1,0), new Vector2(0,-1)};
}
