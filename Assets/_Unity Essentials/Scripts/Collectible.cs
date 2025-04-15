using System;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    private float RotationPerFrame = 0.5f;
    [SerializeField]
    private float RotationTiltPerFrame = 0.007f;
    [SerializeField]
    private float LevitationHeight = 0f;

    [SerializeField]
    private GameObject CollectedEffect;

    [SerializeField]
    private bool Invincible = false;

    private float RotationTilt = 0f;

    private Vector3 InitialPosition = Vector3.right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        InitialPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        var x = Convert.ToSingle(Math.Sin(RotationTilt));
        var y = Convert.ToSingle(Math.Cos(RotationTilt));
        var z = 0;

        if (LevitationHeight == 0)
        {
            transform.Rotate(new(x, y, z), RotationPerFrame);
        }
        else
        {
            transform.SetPositionAndRotation(new(InitialPosition.x, InitialPosition.y +
                y * LevitationHeight, InitialPosition.z), transform.rotation);
            transform.Rotate(0f, RotationPerFrame, 0f);
        }

        RotationTilt += RotationTiltPerFrame;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Instantiate(CollectedEffect, transform.position, transform.rotation);

        if (!Invincible)
            Destroy(gameObject);
        else
        {
            var results = new List<BoxCollider>();
            GetComponents<BoxCollider>(results);
            foreach (var box in results)
                if (box.isTrigger || box.enabled)
                    Destroy(box);
                else
                {
                    box.enabled = true;
                }
            LevitationHeight = 0;
        }
    }
}
