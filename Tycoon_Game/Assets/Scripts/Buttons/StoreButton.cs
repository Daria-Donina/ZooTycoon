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
        var selectingPanel = GameObject.FindGameObjectsWithTag("SelectingPanel");

        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }

        foreach (var panel in selectingPanel)
        {
            panel.SetActive(false);
        }

        storePanel.gameObject.SetActive(true);
    }
}
