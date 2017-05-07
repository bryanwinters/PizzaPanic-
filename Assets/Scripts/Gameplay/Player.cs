using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HandMovement))]
public class Player : MonoBehaviour {

    public Constants.Characters CharacterType;

    [SerializeField] private int _playerNumber = 1;
    public int PlayerNumber { get { return _playerNumber; } }

    private HandMovement _handController;
    public HandMovement HandController { get { return _handController; } }

    private string _controlsCycleRight;
    private string _controlsCycleLeft;

    private Constants.Toppings _activeTopping = Constants.Toppings.dough;
    private PlayerHUD _hudRef;

    private void Awake () 
    {
        SetupVariables();
    }

    private void SetupVariables () 
    {
        _handController = this.GetComponent<HandMovement>();
        _controlsCycleRight = Constants.CONTROLS_CYCLE_RIGHT + PlayerNumber.ToString();
        _controlsCycleLeft = Constants.CONTROLS_CYCLE_LEFT + PlayerNumber.ToString();
    }

	// Use this for initialization
	private void Start () 
    {
		
	}
	
    public void Init ()
    {
        _handController.Init();

        _hudRef = MenuManager.Instance.GetHudForPlayer(CharacterType);
        if (_hudRef)
            _hudRef.Init();
    }

    // Update is called once per frame
    void Update () 
    {
        if (GameManager.Instance.GameState == Constants.GameState.game)
        {
            if (Input.GetButtonDown(_controlsCycleRight))
            {
                CycleToppings(1);
            }

            if (Input.GetButtonDown(_controlsCycleLeft))
            {
                CycleToppings(-1);
            }
        }
    }

    private void CycleToppings (int direction)
    {
        _activeTopping = _hudRef.CycleToppings(direction);
    }
}
