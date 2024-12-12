using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class IntruderDetector : MonoBehaviour
{
    [SerializeField] private Player _intruder;

    public event Action OnDetected;
    public event Action OnLost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _intruder.gameObject)
        {
            OnDetected?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _intruder.gameObject)
        {
            OnLost?.Invoke();
        }
    }
}