using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible2D : MonoBehaviour
{
    [SerializeField]
    private float RotationSpeed = 0.5f;
    [SerializeField]
    private GameObject OnCollectEffect;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, 0, RotationSpeed);
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
         // Check if the other object has a PlayerController2D component
        if (other.GetComponent<PlayerController2D>() != null) {
            
            // Destroy the collectible
            Destroy(gameObject);

            // Instantiate the particle effect
            Instantiate(OnCollectEffect, transform.position, transform.rotation);
        }

        
    }


}


