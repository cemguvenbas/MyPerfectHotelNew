using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Serialized Variables")]
    [SerializeField] private Transform levelHolder;
    [SerializeField] private byte totalLevelCount;

    [Header("Private Variables")]
    private OnLevelLoaderCommand _levelLoaderCommand;
    private OnLevelDestroyerCommand _levelDestroyerCommand;
    private short _currentLevel;

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

    }

    private void OnDisable() {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents(){
        
    }
}
