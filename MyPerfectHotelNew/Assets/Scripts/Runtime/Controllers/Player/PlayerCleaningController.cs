using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCleaningController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float detectionRadius;
    [SerializeField] private float cleaningSpeed;

    
    void Update()
    {
        DetectCleanables();
    }

    private void DetectCleanables(){
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider collider in detectedColliders)
            if (collider.TryGetComponent<Cleanable>(out Cleanable cleanable)){
                if (!cleanable.IsClean())
                    cleanable.Clean(cleaningSpeed * Time.deltaTime);
            }

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,detectionRadius);
    }
}
