using UnityEngine;
using TMPro;  // Make sure to include this namespace for TextMeshPro

public class ui : MonoBehaviour
{
    public TMP_Text crosshair;  // Reference to the TextMeshPro text component

    void Start()
    {
        crosshair.text = "+";
    }
}
