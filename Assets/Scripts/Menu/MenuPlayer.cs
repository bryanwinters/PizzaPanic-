﻿using System.Collections;
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
        SetPlayerActive(false, true);

        _controlsSelect = Constants.CONTROLS_ACTION + PlayerNumber.ToString();
        _controlsReady = Constants.CONTROLS_DASH + PlayerNumber.ToString();
    }

    private void Update()
    {
        if (GameManager.Instance.GameState == Constants.GameState.menu)
        {
            if (Input.GetButtonDown(_controlsSelect))
            {
                SetPlayerActive(!_isActive);
            }

            if ((Input.GetAxis(_controlsReady) >= Constants.CONTROLLER_TRIGGER_DEAD_ZONE || 
                Input.GetAxis(_controlsReady) <= -Constants.CONTROLLER_TRIGGER_DEAD_ZONE) && _isActive == true)
                SetPlayerReady(true);
            else
                SetPlayerReady(false);
        }
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

    private void SetPlayerActive (bool isActive, bool forceActive = false)
    {
        if(isActive != _isActive || forceActive == true)
        {
            _isActive = isActive;

            SendPlayerActiveEvent();

            float alpha = (_isActive == true) ? 1f : 0f;
            _readyImage.DOFade(alpha, 0f);
        }
    }

    private void SetPlayerReady (bool isReady)
    {
        if (isReady != _isReady)
        {
            _isReady = isReady;
            SendPlayerReadyEvent();
        }
    }

}
