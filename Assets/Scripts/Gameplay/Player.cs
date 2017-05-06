using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HandMovement))]
public class Player : MonoBehaviour {

    public Constants.Characters CharacterType;
    public int PlayerNumber = 1;

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
	
	// Update is called once per frame
	void Update () {
		
	}
}
