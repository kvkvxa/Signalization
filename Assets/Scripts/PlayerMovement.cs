using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed = 10f;

    public void Move(CharacterController characterController)
    {
        if (characterController == null)
        {
            Debug.Log("Character controller not assigned");

            return;
        }

        Vector3 playerInput = new (Input.GetAxis("Vertical"), 0f , Input.GetAxis("Horizontal"));

        characterController.SimpleMove(playerInput * _speed);
    }
}