using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Buttons.Entities;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{
    [SerializeField]
    private GameObject selectingPanel;

    [SerializeField]
    private GameObject panelToClose;

    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private Tile tile;

    [SerializeField]
    private Text priceLabel;

    private void Update()
    {
        if (int.Parse(priceLabel.text) > Zoo.Money)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void OnClick()
    {
        PutObject.Model = new SelectingPanel(tilemap, tile, panelToClose);

        Zoo.Money -= int.Parse(priceLabel.text);
        selectingPanel.gameObject.SetActive(true);
        panelToClose.gameObject.SetActive(false);
    }
}
