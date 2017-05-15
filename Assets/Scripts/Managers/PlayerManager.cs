using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Player manager controls prefabs of hands, spawning of players, number players
/// </summary>
public class PlayerManager : MonoBehaviour, IManager {

    public System.Action OnPlayersReady;
    public System.Action OnPlayerCancelled;
    public System.Action OnPlayerHowTo;
    public System.Action OnPizzaSubmitted;

    private static PlayerManager _instance;
    public static PlayerManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<PlayerManager>();

            return _instance;
        }
    }

    public Player[] PlayerPrefabs;

    private List<MenuPlayer> _menuPlayers;
    private List<Player> _activePlayers = new List<Player>();
    public int NumPlayers { get { return _activePlayers.Count; } }

    private List<int> _playersToSpawn = new List<int>();
    private int _playersReady;
    private int _pizzasReady;

    

    private void Awake ()
    {
        SetupVariables();
    }

    private void SetupVariables ()
    {
        _menuPlayers = GameObject.FindObjectsOfType<MenuPlayer>().ToList();
    }

	// Use this for initialization
	void Start () 
    {
        
	}

    private void SubscribeToEvents ()
    {
        GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;

        foreach (MenuPlayer mp in _menuPlayers)
        {
            mp.OnPlayerActive += HandlePlayerActive;
            mp.OnPlayerReady += HandlePlayerReady;
            mp.OnPlayerCancelled += HandlePlayerCancelled;
            mp.OnPlayerHowTo += HandlePlayerHowTo;
        }
    }

    private void UnsubscribeToEvents ()
    {
        GameManager.Instance.OnGameStateChanged -= HandleGameStateChanged;

        foreach (MenuPlayer mp in _menuPlayers)
        {
            mp.OnPlayerActive -= HandlePlayerActive;
            mp.OnPlayerReady -= HandlePlayerReady;
            mp.OnPlayerCancelled -= HandlePlayerCancelled;
            mp.OnPlayerHowTo -= HandlePlayerHowTo;
        }
    }

    public void Init()
    {
        SubscribeToEvents();
    }

    private void HandleGameStateChanged(Constants.GameState state)
    {
        if (state == Constants.GameState.starting)
        {
            SpawnPlayers();
        }
        else if (state == Constants.GameState.menu)
        {
            ClearPlayers();
        }
    }

    private void HandlePlayerActive (int playerNum, bool isActive)
    {
        if (GameManager.Instance.GameState == Constants.GameState.menu)
        {
            if (!_playersToSpawn.Contains(playerNum) && isActive == true)
            {
                _playersToSpawn.Add(playerNum);
            }
            else if (_playersToSpawn.Contains(playerNum) && isActive == false)
            {
                _playersToSpawn.Remove(playerNum);
            }
        }
    }

    private void HandlePlayerReady (bool isReady)
    {
        if (GameManager.Instance.GameState == Constants.GameState.menu)
        {
            int temp = (isReady == true) ? 1 : -1;
            _playersReady = Mathf.Clamp(_playersReady + temp, 0, Constants.MAX_PLAYERS); 

            if (_playersReady == _playersToSpawn.Count)
                SendReadyEvent();
        }
    }

    private void HandlePlayerCancelled ()
    {
        SendCancelEvent();
    }

    private void HandlePlayerHowTo ()
    {
        SendHowToEvent();
    }

    private void HandleOvenReady (bool isReady)
    {
        if (GameManager.Instance.GameState == Constants.GameState.game)
        {
            int temp = (isReady == true) ? 1 : -1;
            _pizzasReady = Mathf.Clamp(_pizzasReady + temp, 0, _activePlayers.Count); 

            if (_pizzasReady == _activePlayers.Count)
                SendPizzaSentEvent();
        }
    }

    private void SendReadyEvent ()
    {
        if (OnPlayersReady != null)
            OnPlayersReady();
    }

    private void SendCancelEvent ()
    {
        if (OnPlayerCancelled != null)
            OnPlayerCancelled();
    }

    private void SendHowToEvent ()
    {
        if (OnPlayerHowTo != null)
            OnPlayerHowTo();
    }

    private void SendPizzaSentEvent ()
    {
        _pizzasReady = 0;

        if (OnPizzaSubmitted != null)
            OnPizzaSubmitted();
    }

    private void SpawnPlayers ()
    {
        for (int i = 0; i < _playersToSpawn.Count; i++)
        {
            Player prefab = null;
            foreach (Player player in PlayerPrefabs)
            {
                if (player.PlayerNumber == _playersToSpawn[i])
                {
                    prefab = player;
                    break;
                }
            }

            if (prefab)
            {
                Player p = Instantiate(prefab) as Player;
                p.Init();
                p.HandController.SetToPosition(Constants.SPAWN_POSITION[p.PlayerNumber - 1]);
                p.OnOvenReady += HandleOvenReady;
                _activePlayers.Add(p);
            }
            else
                Debug.LogWarning("*- NO PREFAB FOR THAT PLAYER -*");
        }
    }

    private void ClearPlayers ()
    {
        List<Player> temp = new List<Player>(_activePlayers);

        foreach (Player p in temp)
        {
            _activePlayers.Remove(p);
            DestroyObject(p.gameObject);
        }

        _activePlayers.Clear();
    }

    private void OnDestroy ()
    {
        UnsubscribeToEvents();
    }
}
