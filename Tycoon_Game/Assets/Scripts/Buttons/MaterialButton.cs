using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialButton : MonoBehaviour
{
    [SerializeField]
    private GameObject sizePanel;

    [SerializeField]
    private GameObject materialPanel;

    public void OnClick()
    {
        sizePanel.gameObject.SetActive(true);
        materialPanel.gameObject.SetActive(false);
    }
}
