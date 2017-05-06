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

    private void Awake () 
    {
        SetupVariables();
    }

    private void SetupVariables () 
    {
        _handController = this.GetComponent<HandMovement>();
    }

	// Use this for initialization
	private void Start () 
    {
		
	}
	
    public void Init ()
    {
        _handController.Init();
    }
}
