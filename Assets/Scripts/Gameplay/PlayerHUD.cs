using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour {

    public Constants.Characters CharacterType;

    [SerializeField] private Image _activeTopping;
    [SerializeField] private List<ToppingIcon> _toppingsList = new List<ToppingIcon>();
    [SerializeField] private TextMeshProUGUI _ovenReadyText;

    private CanvasGroup _canvasGroup;

    private int _currentTopping = 0;

    private bool _ovenReady = false;
    public bool OvenReady { get { return _ovenReady; } }

    private void Awake ()
    {
        SetupVariables();
    }

    private void SetupVariables ()
    {
        _canvasGroup = this.GetComponent<CanvasGroup>();
    }

    public void Init ()
    {
        //get dough,cheese,sauce + 2 random and pull from MenuManager.Instance.Topping to populate data

       
    }

    public Constants.Toppings CycleToppings (int dir)
    {
        _currentTopping += dir;

        if (_currentTopping >= _toppingsList.Count)
            _currentTopping = 0;

        if (_currentTopping < 0)
            _currentTopping = _toppingsList.Count - 1;

        _activeTopping.transform.position = _toppingsList[_currentTopping].IconImage.transform.position;
        return _toppingsList[_currentTopping].Topping;
    }

    public void EnableHud ()
    {
        _canvasGroup.alpha = 1f;
    }

    public void SetOvenState (bool ovenReady)
    {        
        _ovenReady = ovenReady;

        string temp = (_ovenReady == true) ? Constants.HUD_OVEN_READY : Constants.HUD_OVEN_PREPPING_PIZZA;
        _ovenReadyText.text = temp;
    }
}
