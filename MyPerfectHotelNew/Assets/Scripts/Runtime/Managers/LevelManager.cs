using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelManager : MonoBehaviour
{
    [Header("Serialized Variables")]
    [SerializeField] private Transform levelHolder;
    [SerializeField] private byte totalLevelCount;

    [Header("Private Variables")]
    private OnLevelLoaderCommand _levelLoaderCommand;
    private OnLevelDestroyerCommand _levelDestroyerCommand;
    private short _currentLevel = 0;

    [Inject]
    private CoreGameSignals _coreGameSignals;

    private void Awake() {
        _currentLevel = GetActiveLevel();
        Init();
    }

    private void Init(){
        _levelLoaderCommand =  new OnLevelLoaderCommand(levelHolder);
        _levelDestroyerCommand = new OnLevelDestroyerCommand(levelHolder);
    }

    private byte GetActiveLevel(){
        return (byte)_currentLevel;
    }

    private void OnEnable() {
        SubscribeEvents();
    }

    private void SubscribeEvents(){
        _coreGameSignals.onLevelInitialize += _levelLoaderCommand.Execute;
        _coreGameSignals.onClearActiveLevel += _levelDestroyerCommand.Execute;
        _coreGameSignals.onGetLevelID += OnGetLevelValue;
        _coreGameSignals.onNextLevel += OnNextLevel;
        _coreGameSignals.onRestartLevel += OnRestartLevel;
    }

    private byte OnGetLevelValue(){
        return (byte)((byte)_currentLevel % totalLevelCount);
    }

    private void OnNextLevel(){
        _currentLevel++;
        _coreGameSignals.onClearActiveLevel?.Invoke();
        _coreGameSignals.onReset?.Invoke();
        _coreGameSignals.onLevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
    }

    private void OnRestartLevel(){
        _coreGameSignals.onClearActiveLevel?.Invoke();
        _coreGameSignals.onReset?.Invoke();
        _coreGameSignals.onLevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
    }

    private void OnDisable() {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents(){
        _coreGameSignals.onLevelInitialize -= _levelLoaderCommand.Execute;
        _coreGameSignals.onClearActiveLevel -= _levelDestroyerCommand.Execute;
        _coreGameSignals.onGetLevelID -= OnGetLevelValue;
        _coreGameSignals.onNextLevel -= OnNextLevel;
        _coreGameSignals.onRestartLevel -= OnRestartLevel;
    }

    private void Start() {
        _coreGameSignals.onLevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
    }
}
