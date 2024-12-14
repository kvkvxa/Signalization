using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class IntruderDetector : MonoBehaviour
{
    public event Action OnDetected;
    public event Action OnLost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player _))
        {
            OnDetected?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player _))
        {
            OnLost?.Invoke();
        }
    }
}