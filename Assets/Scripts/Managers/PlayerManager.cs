using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Player manager controls prefabs of hands, spawning of players, number players
/// </summary>
public class PlayerManager : MonoBehaviour, IManager {

    public System.Action OnPlayersReady;

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

    private List<int> _playersToSpawn = new List<int>();
    private int _playersReady;

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
        }
    }

    private void UnsubscribeToEvents ()
    {
        GameManager.Instance.OnGameStateChanged -= HandleGameStateChanged;

        foreach (MenuPlayer mp in _menuPlayers)
        {
            mp.OnPlayerActive -= HandlePlayerActive;
            mp.OnPlayerReady -= HandlePlayerReady;
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

    private void SendReadyEvent ()
    {
        if (OnPlayersReady != null)
            OnPlayersReady();
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
                _activePlayers.Add(p);
            }
            else
                Debug.LogWarning("*- NO PREFAB FOR THAT PLAYER -*");
        }
    }

    private void OnDestroy ()
    {
        UnsubscribeToEvents();
    }
}
