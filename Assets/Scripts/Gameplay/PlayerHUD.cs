using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

    public Constants.Characters CharacterType;

    [SerializeField] private Image _activeTopping;
    [SerializeField] private List<ToppingIcon> _toppingsList = new List<ToppingIcon>();

    private int _currentTopping = 0;

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
}
