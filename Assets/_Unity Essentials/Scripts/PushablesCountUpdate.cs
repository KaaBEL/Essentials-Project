using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PushablesCountUpdate : MonoBehaviour
{
    private TextMeshProUGUI _collectibleText;

    private int _totalPushables = 0;
    private int _leftPushables = 0;

    private void Start()
    {
        throw new Exception("Not yert implemented");

        //_collectibleText = GetComponent<TextMeshProUGUI>();

        //_totalPushables = GameObject.FindGameObjectsWithTag("Pushable").Length;
        //_leftPushables = _totalPushables;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<Pushable>() == null)
        //    _leftPushables -= 1;
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.GetComponent<Pushable>() == null)
        //    _leftPushables += 1;
    }
}
