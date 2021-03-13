using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    [SerializeField] private float forwardMoveSpeed = 7.5f;
    [SerializeField] private float backwardMoveSpeed = 3f;
    [SerializeField] private float trunSpeed = 150f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", vertical);
        transform.Rotate(Vector3.up, horizontal * trunSpeed * Time.deltaTime);

        if (vertical != 0)
        {
            float moveSpeedToUse = vertical > 0 ? forwardMoveSpeed : backwardMoveSpeed;
            characterController.SimpleMove(transform.forward * moveSpeedToUse * vertical);
        }









        // characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);

        // animator.SetFloat("Speed", movement.magnitude);
        // if (movement.magnitude > 0)
        // {

        //     Quaternion newDirection = Quaternion.LookRotation(movement);
        //     transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * trunSpeed);
        // }
    }
}
