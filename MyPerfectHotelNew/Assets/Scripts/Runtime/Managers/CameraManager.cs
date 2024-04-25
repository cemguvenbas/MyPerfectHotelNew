using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cinemachine;
using Unity.Mathematics;

public class CameraManager : MonoBehaviour
{
    [Inject] private CameraSignals _cameraSignals;
    [Inject] private CoreGameSignals _coreGameSignals;


    [Header("Serialized Variables")]
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [Header("Private Variables")]
    private float3 _firstPosition;

    private void Start() {
        Init();
    }

    private void Init(){
        _firstPosition = transform.position;
    }

    private void OnEnable() {
        SubscribeEvents();
    }

    private void SubscribeEvents(){
        _cameraSignals.onSetCameraTarget += OnSetCameraTarget;
        _coreGameSignals.onReset += OnReset;
    }

    private void OnSetCameraTarget(){
        var player = FindObjectOfType<PlayerMovementController>().transform;
        virtualCamera.Follow = player;
    }

    private void OnReset(){
        transform.position = _firstPosition;
    }

    private void OnDisable() {
        UnSubscribeEvents();
    }

    private void UnSubscribeEvents(){
        _cameraSignals.onSetCameraTarget -= OnSetCameraTarget;
        _coreGameSignals.onReset -= OnReset;
    }
}
