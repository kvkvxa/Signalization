using UnityEngine;

public class PlayerMovement
{
    private CharacterController _characterController;
    private float _speed = 10f;

    private readonly string _axisX = "Horizontal";
    private readonly string _axisY = "Vertical";

    public PlayerMovement(CharacterController characterController)
    {
        if (characterController == null)
        {
            Debug.LogError("Character controller not assigned");
        }

        _characterController = characterController;
    }

    public void Move()
    {
        Vector3 playerInput = new (Input.GetAxis(_axisY), 0f , Input.GetAxis(_axisX));

        _characterController.SimpleMove(playerInput * _speed);
    }
}