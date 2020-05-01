using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreButton : MonoBehaviour
{
    [SerializeField]
    private GameObject storePanel;

    [SerializeField]
    private GameObject buttonsPanel;

    public void OnClick()
    {
        buttonsPanel.gameObject.SetActive(false);
        storePanel.gameObject.SetActive(true);
    }
}
