using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuHowTo : MonoBehaviour {

    private CanvasGroup _canvasGroup;

    private void Awake ()
    {
        _canvasGroup = this.GetComponent<CanvasGroup>();
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
        if (state == Constants.GameState.howTo)
        {
            _canvasGroup.DOFade(1f, 0.5f).SetEase(Ease.OutCirc);
        }
        else if (state == Constants.GameState.menu)
        {
            _canvasGroup.DOFade(0f, 0.5f).SetEase(Ease.OutCirc);
        }
    }
}
