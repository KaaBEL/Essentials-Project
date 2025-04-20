using UnityEngine;

public class PlayerCamera2D : MonoBehaviour
{
    private Transform _transform;

    private void Start()
    {
        PlayerController2D player = FindAnyObjectByType<PlayerController2D>();
        _transform = player.gameObject.transform;
    }

    private void LateUpdate()
    {
        Vector3 position = _transform.transform.position;
        gameObject.transform.position = new(position.x, position.y, position.z);
    }
}
