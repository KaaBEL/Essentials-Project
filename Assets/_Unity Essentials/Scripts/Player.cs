using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _rotationSpeed = 120.0f;

    private Rigidbody _rgidbody;

    [SerializeField]
    private float _jumpForce = 0.5f;

    private float _jumpDelay = 0f;

    private void Start()
    {
        _rgidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButton("Jump") && _jumpDelay <= 0)
        {
            _rgidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
            _jumpDelay = 1f;
        }
    }


    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = moveVertical * _speed * Time.fixedDeltaTime * transform.forward;
        _rgidbody.MovePosition(_rgidbody.position + movement);

        float turn = Input.GetAxis("Horizontal") * _rotationSpeed * Time.fixedDeltaTime;
        float pitch = Input.GetAxis("Pitch") * _rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(pitch, turn, 0f);
        _rgidbody.MoveRotation(_rgidbody.rotation * turnRotation);

        if (_jumpDelay > 0)
            _jumpDelay -= Time.fixedDeltaTime;

        if (transform.position.y < -64f)
        {
            float x = transform.position.x / 10;
            float z = transform.position.z / 10;

            _rgidbody.linearVelocity = new(0, 0, 0);
            _rgidbody.MovePosition(new(x, 516f, z));
        }
    }
}
