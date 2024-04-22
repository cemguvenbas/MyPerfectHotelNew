using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIEventSubscriber : MonoBehaviour
{
    [Header("Serialized Variables")]
    [SerializeField] private UIEventSubscriptionTypes type;
    [SerializeField] private Button button;

    [Header("Private Variables")]
    private UIManager _uiManager;

    private void Awake() {
        GetReferences();
    }

    private void GetReferences(){
        _uiManager = FindObjectOfType<UIManager>();
    }

    private void OnEnable() {
        SubscribeEvents();
    }

    private void SubscribeEvents(){
        switch (type)
            {
                case UIEventSubscriptionTypes.OnPlay:
                {
                    button.onClick.AddListener(_uiManager.OnPlay);
                    break;
                }
                case UIEventSubscriptionTypes.OnNextLevel:
                {
                    button.onClick.AddListener(_uiManager.OnNextLevel);
                    break;
                }
                case UIEventSubscriptionTypes.OnRestartLevel:
                {
                    button.onClick.AddListener(_uiManager.OnRestartLevel);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
    }
    private void OnDisable() {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents(){
        switch (type)
            {
                case UIEventSubscriptionTypes.OnPlay:
                {
                    button.onClick.RemoveListener(_uiManager.OnPlay);
                    break;
                }
                case UIEventSubscriptionTypes.OnNextLevel:
                {
                    button.onClick.RemoveListener(_uiManager.OnNextLevel);
                    break;
                }
                case UIEventSubscriptionTypes.OnRestartLevel:
                {
                    button.onClick.RemoveListener(_uiManager.OnRestartLevel);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
    }
}
