using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Game manager responsible for game loop and other managers
/// </summary>
public class GameManager : MonoBehaviour {

    public System.Action<Constants.GameState> OnGameStateChanged;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<GameManager>();

            return _instance;
        }
    }

    private List<IManager> _managers = new List<IManager>();

    private Constants.GameState _gameState;
    public Constants.GameState GameState { get { return _gameState; } }

    private void Awake ()
    {
        SetupVariables();
    }

	// Use this for initialization
	private void Start ()
    {
        _gameState = Constants.GameState.menu;

        Init();
	}

    private void SubscribeToEvents ()
    {
        PlayerManager.Instance.OnPlayersReady += HandleOnPlayersReady;
    }

    private void SetupVariables ()
    {
        //DontDestroyOnLoad(this);
        _managers = this.GetComponents<IManager>().ToList();
    }

    private void SetGameState (Constants.GameState state)
    {
        if (_gameState != state)
        {
            _gameState = state;

            if (OnGameStateChanged != null)
                OnGameStateChanged(_gameState);
        }
    }

    public void Init()
    {
        SubscribeToEvents();

        foreach (IManager m in _managers)
        {
            m.Init();
        }
    }

    private void HandleOnPlayersReady ()
    {
        StartCoroutine(StartGame());
    }
	
    private IEnumerator StartGame ()
    {
        SetGameState(Constants.GameState.starting);

        yield return new WaitForSeconds((float)Constants.MENU_STARTING_TIME);

        SetGameState(Constants.GameState.game);
    }
}
