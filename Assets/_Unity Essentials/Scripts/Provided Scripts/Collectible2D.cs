using UnityEngine;

public class Collectible2D : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 0.5f;
    [SerializeField]
    private GameObject _onCollectEffect;

    private void Update()
    {
        transform.Rotate(0, 0, _rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.GetComponent<PlayerController2D>() != null) {
            
            Destroy(gameObject);

            Instantiate(_onCollectEffect, transform.position, transform.rotation);
        }
    }
}
