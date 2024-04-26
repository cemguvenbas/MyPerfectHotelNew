using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cleanable : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Image gageFill;
    [SerializeField] private GameObject canvas;
    //[SerializeField] private Animator animator;

    [Header("Settings")]
    private bool isClean;

     private void Start()
    {
        MessUp();
    }

    private void Update()
    {
        CanvasFaceCamera();
    }

    private void CanvasFaceCamera()
    {
        Vector3 direction = (Camera.main.transform.position - canvas.transform.position).normalized;
        canvas.transform.forward = direction;
    }

    public void Clean(float value)
    {
        gageFill.fillAmount += value;

        if (gageFill.fillAmount >= 1)
            SetAsClean();
    }

    public void MessUp()
    {
        gageFill.fillAmount = 0;

        isClean = false;

        canvas.SetActive(true);

        //MessingAnimation();
    }

    private void SetAsClean()
    {
        isClean = true;

        canvas.SetActive(false);

        //CleaningAnimation();
    }

    public bool IsClean()
    {
        return isClean;
    }

    // private void CleaningAnimation()
    // {
    //     animator.Play("Clean");
    // }

    // private void MessingAnimation()
    // {
    //     animator.Play("MessUp");
    // }
}
