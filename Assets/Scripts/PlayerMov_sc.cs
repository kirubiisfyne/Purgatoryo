using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMov_sc : MonoBehaviour
{
    public float xAxis;
    public float yAxis;

    public float moveSpeed;
    public float lookSpeed;

    public CharacterController plrControl;
    public Camera camera;
    public AudioSource footStep;
    public bool canMove;

    private Vector3 moveDirection;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canMove = true;
    }
    private void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footStep.enabled = true;
        }
        else
        {
            footStep.enabled = false;
        }

        xAxis = Input.GetAxisRaw("Vertical");
        yAxis = Input.GetAxisRaw("Horizontal");

        Vector3 forward = transform.TransformDirection(Vector3.forward) * moveSpeed;
        Vector3 right = transform.TransformDirection(Vector3.right) * moveSpeed;

        moveDirection = (forward * xAxis) + (right * yAxis);
        moveDirection.y -= 90f * Time.deltaTime;

        if (canMove)
        {
            plrControl.Move(moveDirection * Time.deltaTime);
        }
        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotateCam(1, 0);
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotateCam(-1, 0);
        } else if (Input.GetKey(KeyCode.UpArrow))
        {
            rotateCam(0, -1);
        } else if (Input.GetKey(KeyCode.DownArrow))
        {
            rotateCam(0, 1);
        }
    }

    public void rotateCam(float xInput, float yInput)
    {
        xInput = Mathf.Clamp(xInput, -45, 45);
        camera.transform.localRotation *= Quaternion.Euler(yInput * lookSpeed, 0, 0);
        plrControl.transform.rotation *= Quaternion.Euler(0, xInput * lookSpeed, 0);
    }
}
