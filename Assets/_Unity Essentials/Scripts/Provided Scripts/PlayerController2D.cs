using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private bool _canMoveDiagonally = true;

    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    private bool _isMovingHorizontally = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (_canMoveDiagonally)
        {
            _movement = new Vector2(horizontalInput, verticalInput);
            RotatePlayer(horizontalInput, verticalInput);
        }
        else
        {
            if (horizontalInput != 0)
            {
                _isMovingHorizontally = true;
            }
            else if (verticalInput != 0)
            {
                _isMovingHorizontally = false;
            }

            if (_isMovingHorizontally)
            {
                _movement = new Vector2(horizontalInput, 0);
                RotatePlayer(horizontalInput, 0);
            }
            else
            {
                _movement = new Vector2(0, verticalInput);
                RotatePlayer(0, verticalInput);
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity = _movement * _speed;
    }

    private void RotatePlayer(float x, float y)
    {
        if (x == 0 && y == 0) return;

        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
