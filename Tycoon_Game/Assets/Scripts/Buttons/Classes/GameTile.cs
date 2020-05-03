using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Buttons.Classes
{
    public class GameTile : Tile
    {

        [SerializeField]
        private Sprite[] gameSprites;

        [SerializeField]
        private Sprite preview;

        public int movePenalty = 0;

        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            base.GetTileData(position, tilemap, ref tileData);
        }

        public override void RefreshTile(Vector3Int position, ITilemap tilemap)
        {
            base.RefreshTile(position, tilemap);
        }
    }
}
