using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class MenuHUD : MonoBehaviour {

    public System.Action OnTimerComplete;

    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Image _timerImage;

    private List<HUDTopping> _toppingsIcons = new List<HUDTopping>();

    private void Awake () 
    {
        SetupVariables();
    }

	// Use this for initialization
    private void SetupVariables () 
    {
        _toppingsIcons = this.GetComponentsInChildren<HUDTopping>().ToList();
	}

    private void Start () 
    {
        SubscribeToEvents();
    }

    private void SubscribeToEvents () 
    {
        GameManager.Instance.OnGameStateChanged += HandleGameStateChanged;
        //PlayerManager.Instance.OnPizzaSubmitted += HandleNewPizza;
    }

    private void HandleGameStateChanged(Constants.GameState state)
    {
        if (state == Constants.GameState.game)
        {
            StartCoroutine(StartTimer());
        }
    }

    public void HandleNewPizza (Constants.Toppings topping, int amount)
    {
        //Update hud icons
        foreach (HUDTopping t in _toppingsIcons)
        {
            if(t.ToppingType == topping)
            {
                t.SetToppingLevel(amount); //get amount here
            }
        }
    }

    private void SendTimerCompleteEvent ()
    {
        if (OnTimerComplete != null)
            OnTimerComplete();
    }

    private IEnumerator StartTimer ()
    {
        int timer = Constants.GAME_STARTING_TIME;

        string minutes = Mathf.FloorToInt(timer / 60).ToString("0");
        string seconds =  Mathf.FloorToInt(timer % 60).ToString("00");

        _timerText.text = minutes + ":" + seconds;

        float fill = (((float)timer-1f) / Constants.GAME_STARTING_TIME);
        _timerImage.DOFillAmount(fill, 1f);

        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);

            timer--;

            fill = (((float)timer-1f) / Constants.GAME_STARTING_TIME);
            _timerImage.DOFillAmount(fill, 1f);

            minutes = Mathf.FloorToInt(timer / 60).ToString("0");
            seconds =  Mathf.FloorToInt(timer % 60).ToString("00");

            _timerText.text = minutes + ":" + seconds;

            yield return null;
        }

        SendTimerCompleteEvent();
    }

}
