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

    private void Awake ()
    {
        SetupVariables();
    }

    private void SetupVariables ()
    {
        _playerHudElements = GameObject.FindObjectsOfType<PlayerHUD>().ToList();
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
        if (state == Constants.GameState.starting)
        {

        }
    }

    public void Init()
    {
        SubscribeToEvents();
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
