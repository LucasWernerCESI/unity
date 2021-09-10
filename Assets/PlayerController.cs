using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController Controller;
    public float MoveSpeed;
    public float Smooth;
    public float TiltAngle;
    private float TiltY = 0;
    public float JumpHeight;
    private int CoinNumber = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Coin")
        {
            CoinNumber++;
            Destroy(other.gameObject);
        }
        Debug.Log(CoinNumber);
        
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        if (Input.GetAxis("Mouse X") != 0) Rotate();
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    public int GetCoinNumber()
    {
        return CoinNumber;
    }

    private void Move()
    {
        Vector3 Movement = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
        {
            Movement.x = -MoveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Movement.x = MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            Movement.z = MoveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Movement.z = -MoveSpeed * Time.deltaTime;
        }

        transform.position += Movement;
    }

    private void Jump()
    {
        Vector3 Movement = Vector3.zero;
        Movement.y = JumpHeight * Time.deltaTime;
        transform.position += Movement;
    }

    private void Rotate()
    {

        // Smoothly tilts a transform towards a target rotation.
        TiltY += Input.GetAxis("Mouse X") * TiltAngle;

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.Euler(0, TiltY, 0), 
            Smooth * Time.deltaTime
        );

    }
}
