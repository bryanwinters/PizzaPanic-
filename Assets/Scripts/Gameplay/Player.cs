using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HandMovement))]
public class Player : MonoBehaviour {

    public System.Action<bool> OnOvenReady;

    public Constants.Characters CharacterType;

    [SerializeField] private int _playerNumber = 1;
    public int PlayerNumber { get { return _playerNumber; } }

    private HandMovement _handController;
    public HandMovement HandController { get { return _handController; } }

    private string _controlsCycleRight;
    private string _controlsCycleLeft;
    private string _controlsOven;

    private Constants.Toppings _activeTopping = Constants.Toppings.dough;
    public Constants.Toppings ActiveTopping { get { return _activeTopping; } }

    private PlayerHUD _hudRef;

    private Animator _animator;

    private void Awake () 
    {
        SetupVariables();
    }

    private void SetupVariables () 
    {
        _handController = this.GetComponent<HandMovement>();
        _controlsCycleRight = Constants.CONTROLS_CYCLE_RIGHT + PlayerNumber.ToString();
        _controlsCycleLeft = Constants.CONTROLS_CYCLE_LEFT + PlayerNumber.ToString();
        _controlsOven = Constants.CONTROLS_OVEN_X + PlayerNumber.ToString();
        _animator = this.GetComponentInChildren<Animator>();
    }

	// Use this for initialization
	private void Start () 
    {
        SubscribeToEvents();
	}

    private void SubscribeToEvents ()
    {
        PlayerManager.Instance.OnPizzaSubmitted += HandlePizzaSubmitted;
    }
	
    public void Init ()
    {
        _handController.Init();
        PlayAnimation(Constants.ANIMATION_PLAYER_IDLE);

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

            if (Input.GetButtonDown(_controlsOven))
            {
                bool temp = !_hudRef.OvenReady;
                _hudRef.SetOvenState(temp);
                SendOvenReadyEvent(temp);
            }
        }
    }

    private void SendOvenReadyEvent (bool ovenReady)
    {
        if (OnOvenReady != null)
            OnOvenReady(ovenReady);
    }

    private void HandlePizzaSubmitted()
    {
        _hudRef.SetOvenState(false);
    }

    private void CycleToppings (int direction)
    {
        _activeTopping = _hudRef.CycleToppings(direction);
    }

    public void PlayAnimation (string anim)
    {
        if (_animator)
        {
            _animator.Play(anim);
        }
    }
}
