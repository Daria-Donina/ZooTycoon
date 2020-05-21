using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseButton : MonoBehaviour
{
    [SerializeField]
    private GameObject panelToOpen;

    [SerializeField]
    private GameObject panelToClose;

    public void OnClick()
    {
        panelToOpen?.gameObject.SetActive(true);
        panelToClose.gameObject.SetActive(false);
    }
}
