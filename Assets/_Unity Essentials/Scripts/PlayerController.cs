using System;
using UnityEngine;

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5.0f; // Set player's movement speed.
    [SerializeField]
    private float RotationSpeed = 120.0f; // Set player's rotation speed.

    private Rigidbody Rb; // Reference to player's Rigidbody.

    [SerializeField]
    private float JumpForce = 0.5f;
    private float JumpDelay = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        Rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButton("Jump") && JumpDelay <= 0)
        {
            Rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
            JumpDelay = 1f;
        }
    }


    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        // Move player based on vertical input.
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = moveVertical * Speed * Time.fixedDeltaTime * transform.forward;
        Rb.MovePosition(Rb.position + movement);

        // Rotate player based on horizontal input.
        float turn = Input.GetAxis("Horizontal") * RotationSpeed * Time.fixedDeltaTime;
        float pitch = Input.GetAxis("Pitch") * RotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(pitch, turn, 0f);
        Rb.MoveRotation(Rb.rotation * turnRotation);

        if (JumpDelay > 0)
            JumpDelay -= Time.fixedDeltaTime;

        if (transform.position.y < -64f)
        {
            Rb.linearVelocity = new(0, 0, 0);
            Rb.MovePosition(new(-0.809f, 516f, -4.252f));
        }
    }
}
