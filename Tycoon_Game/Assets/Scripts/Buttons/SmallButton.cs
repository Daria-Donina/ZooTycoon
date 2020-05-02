using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Buttons.Classes;
using UnityEngine.Tilemaps;

public class SmallButton : MonoBehaviour
{
    [SerializeField]
    private Tilemap pen;

    [SerializeField]
    private Tile fence;

    [SerializeField]
    private GameObject bear;

    public void OnClick()
    {
        CreateTileAtPoint(bear.transform.position);
    }

    void CreateTileAtPoint(Vector3 pos)
    {
        pen.SetTile(pen.WorldToCell(pos), fence);
    }
}
