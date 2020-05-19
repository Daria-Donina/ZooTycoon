using Assets.Scripts.Buttons.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PutObject : MonoBehaviour
{
    [SerializeField]
    private GameObject selectingPanel;

    public static SelectingPanel Model { get; set; }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Model.IsTile)
            {
                var vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                vector.z = 0;
                Model.Tilemap.SetTile(Model.Tilemap.WorldToCell(vector), Model.Tile);
            }
            else
            {
                var vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                vector.z = 0;
                Instantiate(Model.Prefab, vector, transform.rotation);
            }
            

            selectingPanel.SetActive(false);
            Model.PreviousPanel.SetActive(true);
        }
    }
}
