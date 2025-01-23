using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_controller : MonoBehaviour
{
    public GameObject targetPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OpenPanel()
    {
        targetPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        targetPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
