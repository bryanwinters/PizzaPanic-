using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ToppingIcon
{
    public Constants.Toppings Topping;
    public Image IconImage;
    public Sprite IconSprite;
}

public class MenuManager : MonoBehaviour, IManager {

    public List<ToppingIcon> Toppings = new List<ToppingIcon>();
    public List<Constants.PlayerToppings> AvailableToppingsForPlayers = new List<Constants.PlayerToppings>();
    public MenuHUD HUD;

    private static MenuManager _instance;
    public static MenuManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<MenuManager>();

            return _instance;
        }
    }
        
    private List<PlayerHUD> _playerHudElements = new List<PlayerHUD>();
    private List<ToppingIcon> _playersToppingPool = new List<ToppingIcon>();

    private void Awake ()
    {
        SetupVariables();
    }

    private void SetupVariables ()
    {
        _playerHudElements = GameObject.FindObjectsOfType<PlayerHUD>().ToList();
        _playersToppingPool = new List<ToppingIcon>(Toppings);
    }

    // Use this for initialization
    void Start () 
    {

    }

    private void SubscribeToEvents ()
    {
        GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
    }

    private void UnsubscribeToEvents ()
    {
        GameManager.Instance.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(Constants.GameState state)
    {
        if (state == Constants.GameState.end)
        {

        }
        else if (state == Constants.GameState.cancelStart)
        {
            _playersToppingPool = new List<ToppingIcon>(Toppings);
        }
    }

    public void Init()
    {
        SubscribeToEvents();
        RemoveCommonToppings();
    }

    public ToppingIcon GetUnusedTopping ()
    {
        int ran = Random.Range(0, _playersToppingPool.Count);

        ToppingIcon t = _playersToppingPool[ran];
        _playersToppingPool.Remove(t);

        int temp = (int)t.Topping;
        AvailableToppingsForPlayers.Add((Constants.PlayerToppings)temp);

        return t;
    }

    private void RemoveCommonToppings ()
    {
        List<ToppingIcon> temp = new List<ToppingIcon>(_playersToppingPool);
        foreach (ToppingIcon icon in temp)
        {
            if (icon.Topping == Constants.Toppings.dough || icon.Topping == Constants.Toppings.cheese ||
                icon.Topping == Constants.Toppings.sauce)
            {
                _playersToppingPool.Remove(icon);
            }
        }
    }

    public PlayerHUD GetHudForPlayer(Constants.Characters player)
    {
        foreach (PlayerHUD p in _playerHudElements)
        {
            if (p.CharacterType == player)
            {
                p.EnableHud();
                return p;
            }
        }

        return null;
    }	
}
