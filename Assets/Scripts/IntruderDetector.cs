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
        if (other.TryGetComponent<Player>(out Player player))
        {
            if (player == _intruder)
            {
                OnDetected?.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            if (player == _intruder)
            {
                OnLost?.Invoke();
            }
        }
    }
}