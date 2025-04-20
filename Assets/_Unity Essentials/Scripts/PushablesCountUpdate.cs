using TMPro;
using UnityEngine;

public class PushablesCountUpdate : MonoBehaviour
{
    private TextMeshProUGUI _collectibleText;

    private int _totalPushables = 0;
    private int _leftPushables = 0;

    private void Start()
    {
        _collectibleText = GetComponent<TextMeshProUGUI>();
        if (_collectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }

        _totalPushables = GameObject.FindGameObjectsWithTag("Pushable").Length;
        _leftPushables = _totalPushables;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pushable"))
            _leftPushables -= 1;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pushable"))
            _leftPushables += 1;
    }
}
