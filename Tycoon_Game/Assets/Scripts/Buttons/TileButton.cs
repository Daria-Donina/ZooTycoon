using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Buttons.Entities;
using UnityEngine.Tilemaps;

public class TileButton : MonoBehaviour
{
    [SerializeField]
    private GameObject panelToOpen;

    [SerializeField]
    private GameObject panelToClose;

    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private Tile tile;

    public void OnClick()
    {
        ChooseWhereToPut.Model = new SelectingPanel(tilemap, tile, panelToClose);

        panelToOpen.gameObject.SetActive(true);
        panelToClose.gameObject.SetActive(false);
    }
}
