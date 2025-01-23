using UnityEngine;
using TMPro;

public class ui : MonoBehaviour
{
    public TMP_Text crosshair;  // Reference to the TextMeshPro text component

    void Start()
    {
        crosshair.text = "+";
    }
}
