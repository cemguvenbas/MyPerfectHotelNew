using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIPanelController : MonoBehaviour
{
    [Header("Serialized Variables")]
    [SerializeField] private List<Transform> layers = new List<Transform>();

    [Inject]
    private CoreUISignals _coreUISignals;

    private void OnEnable() 
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        _coreUISignals.onCloseAllPanels += OnCloseAllPanels;
        _coreUISignals.onClosePanel += OnClosePanel;
        _coreUISignals.onOpenPanel += OnOpenPanel;
    }

    private void OnOpenPanel(UIPanelTypes panelType, int layerValue)
    {
        _coreUISignals.onClosePanel?.Invoke(layerValue);
       Instantiate(Resources.Load<GameObject>($"Screens/{panelType}Panel"),layers[layerValue]);
    }

    private void OnClosePanel(int layerValue) 
    {
         if (layers[layerValue].transform.childCount > 0)
                for (int i = 0; i < layers[layerValue].transform.childCount; i++)
                {
                    Destroy(layers[layerValue].transform.GetChild(i).gameObject);
                }
    }

    private void OnCloseAllPanels()
    {
        foreach (var layer in layers)
            {
                for (int i = 0; i < layer.transform.childCount; i++)
                {
                    Destroy(layer.transform.GetChild(i).gameObject);
                }
            }
    }

    private void OnDisable() {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents(){
        _coreUISignals.onCloseAllPanels -= OnCloseAllPanels;
        _coreUISignals.onClosePanel -= OnClosePanel;
        _coreUISignals.onOpenPanel -= OnOpenPanel;
    }
}
