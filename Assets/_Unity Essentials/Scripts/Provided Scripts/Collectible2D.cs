using UnityEngine;

public class Collectible2D : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 0.5f;

    // all Collectible2Ds use the same effect
    [SerializeField]
    private Object _onCollectEffect;

    private void Update()
    {
        //_onCollectEffect = Resources.Load("/Assets/_Unity Essentials/Prefabs/" +
        //    "VFX/VFX_2D_Burst.prefab");
        transform.Rotate(0, 0, _rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController2D unused))
        {
            Destroy(gameObject);

            Instantiate(_onCollectEffect, transform.position, transform.rotation);
        }
    }
}
