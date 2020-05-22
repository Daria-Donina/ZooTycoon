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
        if (panelToOpen != null)
        {
            panelToOpen.SetActive(true);
        }
        panelToClose.gameObject.SetActive(false);
    }
}
