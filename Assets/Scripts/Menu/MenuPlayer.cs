using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuPlayer : MonoBehaviour {

    public System.Action<bool> OnPlayerReady;
    public System.Action<int, bool> OnPlayerActive;

    public int PlayerNumber = 1;

    [SerializeField] private Image _readyImage;

    private bool _isActive = false;
    private bool _isReady = false;
    private string _controlsSelect;
    private string _controlsReady;

    private void Awake ()
    {
        SetupVariables();
    }

    private void SetupVariables ()
    {
        SetPlayerActive(false);

        _controlsSelect = Constants.CONTROLS_ACTION + PlayerNumber.ToString();
        _controlsReady = Constants.CONTROLS_DASH + PlayerNumber.ToString();
    }

    private void Update()
    {
        if (Input.GetButtonDown(_controlsSelect))
        {
            SetPlayerActive(!_isActive);
        }

        if (Input.GetAxis(_controlsReady) != 0 && _isActive == true)
            _isReady = true;
        else
            _isReady = false;
    }

    private void SendPlayerActiveEvent ()
    {
        if (OnPlayerActive != null)
            OnPlayerActive(PlayerNumber, _isActive);
    }

    private void SendPlayerReadyEvent ()
    {
        if (_isActive == true)
        {
            if (OnPlayerReady != null)
                OnPlayerReady( _isReady);
        }
    }

    private void SetPlayerActive (bool isActive)
    {
        if(isActive != _isActive)
        {
            _isActive = isActive;
            if (_isActive == false)
                SetPlayerReady(false);

            float alpha = (_isActive == true) ? 1f : 0f;
            _readyImage.DOFade(alpha, 0f);
        }
    }

    private void SetPlayerReady (bool isReady)
    {
        if (isReady != _isReady)
        {
            _isReady = isReady;
        }
    }

}
