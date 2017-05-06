using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player manager controls prefabs of hands, spawning of players, number players
/// </summary>
public class PlayerManager : MonoBehaviour, IManager {

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

    public Player PlayerPrefab;

    public int NumberOfPlayers = 4;

    private List<Player> _players = new List<Player>();

	// Use this for initialization
	void Start () 
    {
		
	}

    public void Init()
    {
        for (int i = 0; i < NumberOfPlayers; i++)
        {
            Player p = Instantiate(PlayerPrefab) as Player;
            p.HandController.SetToPosition(Constants.SPAWN_POSITION[i]);
            _players.Add(p);
        }
    }
}
