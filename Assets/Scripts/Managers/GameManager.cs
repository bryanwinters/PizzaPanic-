using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Game manager responsible for game loop and other managers
/// </summary>
public class GameManager : MonoBehaviour {

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

    private void Awake ()
    {
        SetupVariables();
    }

	// Use this for initialization
	private void Start ()
    {
        StartCoroutine(StartGame());
	}

    private void SetupVariables ()
    {
        DontDestroyOnLoad(this);
        _managers = this.GetComponents<IManager>().ToList();
    }

    public void Init()
    {
        foreach (IManager m in _managers)
        {
            m.Init();
        }
    }
	
    private IEnumerator StartGame ()
    {
        yield return new WaitForSeconds(2f);

        Init();
    }
}
