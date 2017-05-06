using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants : object {

    //ENUMS
    public enum Toppings {dough = 0, sauce = 1, cheese = 2, pepperoni = 3, bacon = 4, anchovies = 5, greenPepper = 6,
        mushroom = 7, hotPepper = 8, pineapple = 9}
    public enum Characters {meowzzarella = 0, octopie = 1, crustodile = 2, bonemando = 3}
    public enum GameState {menu = 0, starting = 1, game = 2, end = 3}

    //NUMBERS
    //settings
    public static int MIN_PLAYERS = 1;
    public static int MAX_PLAYERS = 4;

    //gameplay
    public static float PLAYER_SPAWN_OFFSET = 29f;
    public static int GAME_STARTING_TIME = 120;

    //controls
    public static float CONTROLLER_TRIGGER_DEAD_ZONE = 0.5f;

    //menu
    public static int MENU_STARTING_TIME = 5;

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

    //menu
    public const string MENU_READY_PLAYERS = "Waiting For Players To Ready...";
    public const string MENU_GAME_STARTING = "Game Starting in ";

    public static Vector2[] SPAWN_POSITION = new Vector2[]{new Vector2(-1,0), new Vector2(0,1), new Vector2(1,0), new Vector2(0,-1)};
}
