using UnityEngine;
using TMPro;
using System; // Required for Type handling

public class UpdateCollectibleCount : MonoBehaviour
{
    private TextMeshProUGUI CollectibleText; // Reference to the TextMeshProUGUI component

    private int UnityObjectSearchingLimit = 1;

    private int TotalCollectibles = 0;

    void Start()
    {
        CollectibleText = GetComponent<TextMeshProUGUI>();
        if (CollectibleText == null)
        {
            Debug.LogError("UpdateCollectibleCount script requires a TextMeshProUGUI component on the same GameObject.");
            return;
        }

        // Check and count objects of type Collectible
        Type collectibleType = Type.GetType("Collectible");
        if (collectibleType != null)
        {
            TotalCollectibles += UnityEngine.Object.FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length;
        }

        // Optionally, check and count objects of type Collectible2D as well if needed
        Type collectible2DType = Type.GetType("Collectible2D");
        if (collectible2DType != null)
        {
            TotalCollectibles += UnityEngine.Object.FindObjectsByType(collectible2DType, FindObjectsSortMode.None).Length;
        }
        UpdateCollectibleDisplay(); // Initial update on start
    }

    void Update()
    {
        if (--UnityObjectSearchingLimit < 1)
        {
            UnityObjectSearchingLimit = 4;
            UpdateCollectibleDisplay();
        }
    }

    public void UpdateCollectibleDisplay()
    {
        int leftCollectibles = 0;

        // Check and count objects of type Collectible
        Type collectibleType = Type.GetType("Collectible");
        if (collectibleType != null)
        {
            leftCollectibles += GameObject.FindGameObjectsWithTag("Collectible").Length;
        }

        // Optionally, check and count objects of type Collectible2D as well if needed
        Type collectible2DType = Type.GetType("Collectible2D");
        if (collectible2DType != null)
        {
            leftCollectibles += UnityEngine.Object.FindObjectsByType(collectible2DType, FindObjectsSortMode.None).Length;
        }

        // Update the collectible count display
        CollectibleText.text = $"{leftCollectibles} / {TotalCollectibles}";
    }
}
