using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PlayerHUD : MonoBehaviour {

    public Constants.Characters CharacterType;

    [SerializeField] private Image _activeTopping;
    [SerializeField] private List<ToppingIcon> _toppingsList = new List<ToppingIcon>();
    [SerializeField] private TextMeshProUGUI _ovenReadyText;

    private CanvasGroup _canvasGroup;

    private int _currentTopping = 0;
    private int _minTopping = 0;
    private int _maxTopping = 4;

    private bool _ovenReady = false;
    public bool OvenReady { get { return _ovenReady; } }

    private void Awake ()
    {
        SetupVariables();
    }

    private void SetupVariables ()
    {
        _canvasGroup = this.GetComponent<CanvasGroup>();

        #if DOUGH_PULLING_BROKEN
        _minTopping = 1;

        //TODO disable dough
        #endif
    }

    public void Init ()
    {
        //get dough,cheese,sauce + 2 random and pull from MenuManager.Instance.Topping to populate data
        List<ToppingIcon> temp = new List<ToppingIcon>(_toppingsList);
        for (int i = 3; i < temp.Count; i++)
        {
            ToppingIcon t = MenuManager.Instance.GetUnusedTopping();
            _toppingsList[i].IconSprite = t.IconSprite;
            _toppingsList[i].Topping = t.Topping;
            _toppingsList[i].IconImage.sprite = t.IconSprite;
        }  

        #if DOUGH_PULLING_BROKEN
        float shift = 20f; //{80,60,20}
        float shiftMod = 5f;

        //hide dough and remove from topping cycle
        foreach(ToppingIcon t in temp)
        {
            if(t.Topping == Constants.Toppings.dough)
            {
                t.IconImage.gameObject.SetActive(false);
                _toppingsList.Remove(t);
            }                
        }

        //reposition icons
        for (int i = 0; i < _toppingsList.Count; i++)
        {
            float startVal = _toppingsList[i].IconImage.rectTransform.position.x;
            float mod = Mathf.Max((shift - (shiftMod*i)), 0f);
            _toppingsList[i].IconImage.rectTransform.DOMoveX(startVal - mod, 0f);
        } 
        #endif
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

    public Constants.Toppings SetTopping (Constants.Toppings topping)
    {
        //assign that topping
        foreach (ToppingIcon t in _toppingsList)
        {
            if (t.Topping == topping)
            {
                _activeTopping.transform.position = t.IconImage.transform.position;
                return t.Topping;
            }
        }

        //else assign first topping
        _activeTopping.transform.position = _toppingsList[0].IconImage.transform.position;
        return _toppingsList[0].Topping;
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

    private void RemoveDoughTopping ()
    {
        #if DOUGH_PULLING_BROKEN

        #endif
    }
}
