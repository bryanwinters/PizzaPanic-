using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour, IManager {

    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<SoundManager>();

            return _instance;
        }
    }

    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private AudioClip _gameMusic;

    private AudioSource _source;

    // Use this for initialization
    private void Awake () 
    {
        _source = this.GetComponent<AudioSource>();
    }

    public void Init()
    {
        SubscribeToEvents();
    }

    private void SubscribeToEvents ()
    {
        GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
    }

    private void UnsubscribeToEvents ()
    {
        GameManager.Instance.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(Constants.GameState state)
    {
        if (state == Constants.GameState.game)
        {
            _source.clip = _gameMusic;
            _source.Play();
        }
    }
}
