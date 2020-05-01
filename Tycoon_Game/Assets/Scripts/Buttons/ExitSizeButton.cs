using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSizeButton : MonoBehaviour
{
    [SerializeField]
    private GameObject materialPanel;

    [SerializeField]
    private GameObject sizePanel;

    public void OnClick()
    {
        sizePanel.gameObject.SetActive(false);
        materialPanel.gameObject.SetActive(true);
    }
}
