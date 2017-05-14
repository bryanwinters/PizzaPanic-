using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTopping : MonoBehaviour {

    public Constants.Toppings ToppingType;
    [SerializeField]private List<Image> _toppingAmount = new List<Image>();

    public void SetToppingLevel (int amount)
    {
        if (this.gameObject.activeSelf == true && amount == 0)
            this.gameObject.SetActive(false);

        if (this.gameObject.activeSelf == false && amount != 0)
            this.gameObject.SetActive(true);

        for (int i = 0; i < _toppingAmount.Count; i++)
        {
            if (i >= amount || amount == 0)
            {
                _toppingAmount[i].enabled = false;
            }
            else
            {
                _toppingAmount[i].enabled = true;
            }
        }
    }
}
