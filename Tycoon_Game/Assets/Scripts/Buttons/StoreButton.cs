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
        var panels = GameObject.FindGameObjectsWithTag("Panel");

        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }

        storePanel.SetActive(true);
        buttonsPanel.SetActive(false);
    }
}
