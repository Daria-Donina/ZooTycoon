using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitStoreButton : MonoBehaviour
{
    [SerializeField]
    private GameObject storePanel;

    [SerializeField]
    private GameObject buttonsPanel;

    public void OnClick()
    {
        buttonsPanel.gameObject.SetActive(true);
        storePanel.gameObject.SetActive(false);
    }
}
