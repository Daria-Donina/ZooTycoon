using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMaterialButton : MonoBehaviour
{
    [SerializeField]
    private GameObject storePanel;

    [SerializeField]
    private GameObject materialPanel;

    public void OnClick()
    {
        materialPanel.gameObject.SetActive(false);
        storePanel.gameObject.SetActive(true);
    }
}
