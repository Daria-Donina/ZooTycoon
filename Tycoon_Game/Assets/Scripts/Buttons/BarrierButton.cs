using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierButton : MonoBehaviour
{
    [SerializeField]
    private GameObject storePanel;

    [SerializeField]
    private GameObject materialPanel;

    public void OnClick()
    {
        storePanel.gameObject.SetActive(false);
        materialPanel.gameObject.SetActive(true);
    }
}
