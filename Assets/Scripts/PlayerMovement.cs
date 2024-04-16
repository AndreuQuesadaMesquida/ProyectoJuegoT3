using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontalInput, forwardInput;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 10.0f;

    [SerializeField] private float jumpForce = 10.0f;

    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;

    [SerializeField] private LayerMask groundLayerMask;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        GetInput();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        Rotation();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
    }

    private void Rotation()
    {
        transform.rotation *= Quaternion.Euler(0, rotationSpeed * horizontalInput * Time.deltaTime, 0);
    }

    private void Movement()
    {
        Vector3 direction = transform.forward * (speed * forwardInput);
        _rigidbody.velocity = new Vector3(direction.x, _rigidbody.velocity.y, direction.z);
    }

}
