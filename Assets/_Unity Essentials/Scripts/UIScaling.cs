using UnityEngine;
using UnityEngine.UI;

public class UIScaling : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var scaler = GetComponent<CanvasScaler>();
        if (scaler != null)
        {
            scaler.enabled = (Screen.width + Screen.height) / 2 > 1000;
        }
    }
}
