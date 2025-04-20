using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class OneWayPassage : MonoBehaviour
{
    private BoxCollider _hiddenDoor;

    private void Start()
    {
        var results = new List<BoxCollider>();
        GetComponents<BoxCollider>(results);
        foreach (var box in results)
        {
            if (!box.isTrigger)
            {
                _hiddenDoor = box;
                return;
            }
        }
        Debug.LogError("BoxCollider for one way passage was not found");
        _hiddenDoor = gameObject.AddComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _hiddenDoor.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        _hiddenDoor.enabled = true;
    }
}
