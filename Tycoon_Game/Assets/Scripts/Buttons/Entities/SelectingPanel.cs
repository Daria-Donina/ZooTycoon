using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Buttons.Entities
{
    public class SelectingPanel
    {
        public SelectingPanel(Tilemap tilemap, Tile tile, GameObject previousPanel)
        {
            Tilemap = tilemap;
            Tile = tile;
            PreviousPanel = previousPanel;
            IsTile = true;
        }

        public SelectingPanel(GameObject prefab, GameObject previousPanel)
        {
            Prefab = prefab;
            PreviousPanel = previousPanel;
        }

        public Tilemap Tilemap { get; set; }
        public Tile Tile { get; set; }

        public GameObject Prefab { get; set; }

        public bool IsTile { get; set; }

        public GameObject PreviousPanel { get; set; }
    }
}
