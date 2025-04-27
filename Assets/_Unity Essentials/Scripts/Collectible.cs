using System.Collections.Generic;
using UnityEngine;
using static System.Convert;
using static System.Math;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    private float _rotationPerFrame = 0.5f;
    [SerializeField]
    private float _rotationTiltPerFrame = 0.007f;
    [SerializeField]
    private float _levitationHeight = 0f;

    // different Collectibles use different effects
    [SerializeField]
    private Object _collectedEffect;

    [SerializeField]
    private bool _invincible = false;

    private float _rotationTilt = 0f;

    private Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = gameObject.transform.position;
    }

    private void Update()
    {
        float x = ToSingle(Sin(_rotationTilt));
        float y = ToSingle(Cos(_rotationTilt));
        float z = 0;

        if (_levitationHeight == 0)
        {
            transform.Rotate(new(x, y, z), _rotationPerFrame);
        }
        else
        {
            transform.SetPositionAndRotation(new(_initialPosition.x, _initialPosition.y +
                y * _levitationHeight, _initialPosition.z), transform.rotation);
            transform.Rotate(0f, _rotationPerFrame, 0f);
        }

        _rotationTilt += _rotationTiltPerFrame;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player unused)) return;

        Instantiate(_collectedEffect, transform.position, transform.rotation);

        if (!_invincible)
        {
            Destroy(gameObject);
        }
        else
        {
            var results = new List<BoxCollider>();
            GetComponents<BoxCollider>(results);
            foreach (var box in results)
            {
                if (box.isTrigger || box.enabled)
                {
                    Destroy(box);
                }
                else
                {
                    box.enabled = true;
                }
            }
            _levitationHeight = 0;
        }
    }
}
