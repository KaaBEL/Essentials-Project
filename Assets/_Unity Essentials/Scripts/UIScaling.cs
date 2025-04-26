using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class UIScaling : MonoBehaviour
{
    void Start()
    {
        const int MinResulutionFactor = 1000;

        var scaler = GetComponent<CanvasScaler>();
        scaler.enabled = (Screen.width + Screen.height) / 2 > MinResulutionFactor;
    }
}
