using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChooseWhereToPut : MonoBehaviour
{
    [SerializeField]
    private GameObject selectingPanel;

    [SerializeField]
    private GameObject sizePanel;

    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private Tile fence;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vector.z = 0;
            tilemap.SetTile(tilemap.WorldToCell(vector), fence);

            selectingPanel.SetActive(false);
            sizePanel.SetActive(true);
        }
    }
}
