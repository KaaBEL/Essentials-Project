using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class UIScaling : MonoBehaviour
{
    void Start()
    {
        var scaler = GetComponent<CanvasScaler>();
        scaler.enabled = (Screen.width + Screen.height) / 2 > 1000;
    }
}
