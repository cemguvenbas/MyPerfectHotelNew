using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIManager : MonoBehaviour
{
    [Inject]
    private CoreGameSignals _coreGameSignals;

    [Inject]
    private CoreUISignals _coreUISignals;

    private void OnEnable() {
        SubscribeEvents();

        OpenStartPanel();
    }

    private void SubscribeEvents(){
        _coreGameSignals.onLevelInitialize += OnLevelInitialize;
        _coreGameSignals.onLevelFailed += OnLevelFailed;
        _coreGameSignals.onLevelSuccessful += OnLevelSuccessful;
        _coreGameSignals.onReset += OnReset;
    }

    private void OpenStartPanel(){
        _coreUISignals.onOpenPanel?.Invoke(UIPanelTypes.Start,0);
        _coreUISignals.onOpenPanel?.Invoke(UIPanelTypes.Level,1);
    }

    private void OnLevelInitialize(byte levelValue){
        _coreUISignals.onOpenPanel?.Invoke(UIPanelTypes.Start,0);
        _coreUISignals.onOpenPanel?.Invoke(UIPanelTypes.Level,1);
    }

    public void OnPlay(){
        _coreGameSignals.onPlay?.Invoke();
        _coreUISignals.onClosePanel?.Invoke(0);
    }

    private void OnOpenWinPanel(){
        _coreUISignals.onOpenPanel?.Invoke(UIPanelTypes.Win,2);
    }

    private void OnOpenFailPanel(){
        _coreUISignals.onOpenPanel?.Invoke(UIPanelTypes.Fail,2);
    }

    public void OnNextLevel(){
        _coreGameSignals.onNextLevel?.Invoke();
        _coreGameSignals.onReset?.Invoke();
    }

    public void OnRestartLevel(){
        _coreGameSignals.onRestartLevel?.Invoke();
        _coreGameSignals.onReset?.Invoke();
    }

    private void OnLevelFailed(){
        OnOpenFailPanel();
    }

    private void OnLevelSuccessful(){
        OnOpenWinPanel();
    }

    private void OnReset(){
        //_coreUISignals.onCloseAllPanels?.Invoke();
    }

    private void OnDisable() {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents(){
        _coreGameSignals.onLevelInitialize -= OnLevelInitialize;
        _coreGameSignals.onLevelFailed -= OnLevelFailed;
        _coreGameSignals.onLevelSuccessful -= OnLevelSuccessful;
        _coreGameSignals.onReset -= OnReset;
    }
}
