using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public float speed = 10f;
    
    private Vector3 moveVector;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue inputValue)
    {
        moveVector = inputValue.Get<Vector2>();
        moveVector = new Vector3(moveVector.x, 0f, moveVector.y).normalized;
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveVector * speed, ForceMode.Force);
    }

}
