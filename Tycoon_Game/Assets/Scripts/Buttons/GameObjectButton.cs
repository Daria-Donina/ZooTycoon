using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Buttons.Entities;
using UnityEngine.Tilemaps;

public class GameObjectButton : MonoBehaviour
{
    [SerializeField]
    private GameObject panelToOpen;

    [SerializeField]
    private GameObject panelToClose;

    [SerializeField]
    private GameObject prefab;

    public void OnClick()
    {
        ChooseWhereToPut.Model = new SelectingPanel(prefab, panelToClose);

        panelToOpen.gameObject.SetActive(true);
        panelToClose.gameObject.SetActive(false);
    }
}
