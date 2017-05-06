using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MainMenu : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI _readyText;

    private CanvasGroup _menu;

    // Use this for initialization
    private void Awake () 
    {
        SetupVariables();
    }

	// Use this for initialization
	private void Start ()
    {
        SubscribeToEvents();
	}

    private void SubscribeToEvents ()
    {
        GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
    }

    private void SetupVariables ()
    {
        _menu = this.GetComponent<CanvasGroup>();
        _readyText.text = Constants.MENU_READY_PLAYERS;
    }

    private void HandleGameStateChanged(Constants.GameState state)
    {
        if (state == Constants.GameState.starting)
        {
            StartCoroutine(StartMenuTimer());
        }
    }

    private IEnumerator StartMenuTimer()
    {
        int timer = Constants.MENU_STARTING_TIME;
        _readyText.text = Constants.MENU_GAME_STARTING + timer;

        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);

            timer--;
            _readyText.text = Constants.MENU_GAME_STARTING + timer;
        }

        //remove menu
        _menu.DOFade(0f, 0.5f).SetEase(Ease.OutCubic);
    }
	
}
