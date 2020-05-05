using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Buttons.Entities;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameObjectButton : MonoBehaviour
{
    [SerializeField]
    private GameObject panelToOpen;

    [SerializeField]
    private GameObject panelToClose;

    [SerializeField]
    private GameObject prefab;

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
        ChooseWhereToPut.Model = new SelectingPanel(prefab, panelToClose);

        Zoo.Money -= int.Parse(priceLabel.text);
        panelToOpen.gameObject.SetActive(true);
        panelToClose.gameObject.SetActive(false);
    }
}
