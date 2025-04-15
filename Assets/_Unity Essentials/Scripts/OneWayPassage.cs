using System.Collections.Generic;
using UnityEngine;

public class OneWayPassage : MonoBehaviour
{
    private BoxCollider HiddenDoor;

    // Start is called once before the first execution of Update
    // after the MonoBehaviou is created
    void Start()
    {
        var results = new List<BoxCollider>();
        GetComponents<BoxCollider>(results);
        foreach (var box in results)
        {
            if (!box.isTrigger)
            {
                HiddenDoor = box;
                return;
            }
        }
        Debug.LogError("BoxCollider for one way passage was not found");
        HiddenDoor = gameObject.AddComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        HiddenDoor.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        HiddenDoor.enabled = true;
    }
}
