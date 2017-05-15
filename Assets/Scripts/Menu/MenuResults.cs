using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MenuResults : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI _numPizzasMade;
    [SerializeField] private TextMeshProUGUI _averageQuality;
    [SerializeField] private TextMeshProUGUI _bestPizza;
    [SerializeField] private TextMeshProUGUI _worstPizza;
    [SerializeField] private TextMeshProUGUI _ranking;
    [SerializeField] private TextMeshProUGUI _pressesToReset;

    private const string _qualitySuffix = "%";
    private const string _rankingSuffixGood = "+";
    private const string _rankingSuffixBad = "-";
    private const string _resetPrefix = "(";

    private string _controlsOne;
    private string _controlsTwo;
    private string _controlsThree;
    private string _controlsFour;

    private int _restartCount = 0;
    private int _restartCountMax = 15;

    private CanvasGroup _canvasGroup;

    private void Awake ()
    {
        _canvasGroup = this.GetComponent<CanvasGroup>();

        _controlsOne = Constants.CONTROLS_OVEN_X + "1";
        _controlsTwo = Constants.CONTROLS_OVEN_X + "2";
        _controlsThree = Constants.CONTROLS_OVEN_X + "3";
        _controlsFour = Constants.CONTROLS_OVEN_X + "4";

    }

	// Use this for initialization
	void Start ()
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
        if (state == Constants.GameState.end)
        {
            //set scores
            _numPizzasMade.text = PizzaManager.SharedInstance.GetNumPizzas().ToString();
            _averageQuality.text = PizzaManager.SharedInstance.GetAverageScore().ToString() + _qualitySuffix;
            _bestPizza.text = PizzaManager.SharedInstance.GetHighScore().ToString() + _qualitySuffix;
            _worstPizza.text = PizzaManager.SharedInstance.GetLowScore().ToString() + _qualitySuffix;
            _ranking.text = PizzaManager.SharedInstance.GetRanking();

            _canvasGroup.DOFade(1f, 0.5f).SetEase(Ease.OutCirc);
        }
    }

    private void Update ()
    {
        if (GameManager.Instance.GameState == Constants.GameState.end)
        {
            if (Input.GetButtonDown(_controlsOne) || Input.GetButtonDown(_controlsTwo) || Input.GetButtonDown(_controlsThree) ||
            Input.GetButtonDown(_controlsFour))
            {
                _restartCount++;

                if (_pressesToReset != null)
                    _pressesToReset.text = _resetPrefix + (_restartCountMax - _restartCount).ToString("00");

                if (_restartCount >= _restartCountMax)
                    UnityEngine.SceneManagement.SceneManager.LoadScene("main");
            }
        }
    }
}
