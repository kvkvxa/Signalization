using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private Transform _transform;
    private CharacterController _characterController;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
        _playerMovement = new PlayerMovement(_characterController); 
    }

    private void Update()
    {
        _playerMovement.Move();
    }
}