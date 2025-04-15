using TMPro;
using UnityEngine;

public class UpdatePushablesCount : MonoBehaviour
{
    private TextMeshProUGUI CollectibleText; // Reference to the TextMeshProUGUI component
    private int TotalPushables = 0;
    private int LeftPushables = 0;

    private void Start()
    {
        CollectibleText = GetComponent<TextMeshProUGUI>();
        if (CollectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }

        TotalPushables = GameObject.FindGameObjectsWithTag("Pushable").Length;
        LeftPushables = TotalPushables;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pushable"))
            LeftPushables -= 1;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pushable"))
            LeftPushables += 1;
    }
}
