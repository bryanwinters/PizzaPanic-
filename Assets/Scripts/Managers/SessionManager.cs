using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Session manager controls timing of game session, elements in environment
/// </summary>
public class SessionManager : MonoBehaviour, IManager {

    private static SessionManager _instance;
    public static SessionManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<SessionManager>();

            return _instance;
        }
    }

    [SerializeField] private CapsuleCollider _table;
    public CapsuleCollider Table { get{ return _table; } }

	// Use this for initialization
	void Start () 
    {
		
	}
	
    public void Init()
    {

    }
}
