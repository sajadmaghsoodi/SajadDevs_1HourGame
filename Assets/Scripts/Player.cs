using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool Active = true;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _verticalMovementSpeed;



    private void Update()
    {
        if (Active)
        {
            transform.position += new Vector3(0, 0, _movementSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                _rigidBody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.A))
            {
                _rigidBody.velocity -= new Vector3(_verticalMovementSpeed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _rigidBody.velocity += new Vector3(_verticalMovementSpeed * Time.deltaTime, 0, 0);
            }
            else
            {
                _rigidBody.velocity = Vector3.Lerp(_rigidBody.velocity, new Vector3(0, _rigidBody.velocity.y, _rigidBody.velocity.z), 0.05f);
            }
        }

    }



    public bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, 1f, _whatIsGround))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * hit.distance, Color.yellow);
            return true;
        }
        return false;

    }
}
