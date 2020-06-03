using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.LevelSystem;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DTWorlds.Behaviours.Environment
{
    public class FightPitBehaviour : MonoBehaviour
    {        
        public Tilemap FloorMap;
        public Tilemap WallMap;
        public GameObject TestItem;

        // Start is called before the first frame update
        void Start()
        {
            // Instantiate(TestItem, TileMap.GetCellCenterWorld(new Vector3Int(0, 0, 0)), Quaternion.identity);
            // Instantiate(TestItem, TileMap.GetCellCenterWorld(new Vector3Int(1, 0, 0)), Quaternion.identity);
            // Instantiate(TestItem, TileMap.GetCellCenterWorld(new Vector3Int(1, 1, 0)), Quaternion.identity);
            // Instantiate(TestItem, TileMap.GetCellCenterWorld(new Vector3Int(0, 1, 0)), Quaternion.identity);

            // BoundsInt bounds = TileMap.cellBounds;
            // TileBase[] allTiles = TileMap.GetTilesBlock(bounds);

            // foreach (var tile in allTiles)
            // {
            //     Instantiate(TestItem, TileMap.GetCellCenterWorld(new Vector3Int(, 1, 0)), Quaternion.identity);
            // }

            // for (int x = bounds.xMin; x < bounds.xMax; x++)
            // {
            //     for (int y = bounds.yMin; y < bounds.xMax; y++)
            //     {
            //         //Instantiate(TestItem, TileMap.GetCellCenterWorld(new Vector3Int(x, y, 0)), Quaternion.identity);
            //         //TileBase tile = allTiles[x + y * bounds.size.x];
            //         // if (tile != null)
            //         // {
            //         //     Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
            //         // }
            //         // else
            //         // {
            //         //     Debug.Log("x:" + x + " y:" + y + " tile: (null)");
            //         // }
            //     }
            // }

            // for (int i = 0; i < TileMap.size.x; i++)
            // {
            //     for (int j = 0; j < TileMap.size.y; j++)
            //     {
            //         //Debug.Log(TileMap.GetCellCenterWorld(new Vector3Int(i,j,0)));
            //         Instantiate(TestItem,TileMap.GetCellCenterWorld(new Vector3Int(i,j,0)),Quaternion.identity);
            //     }
            // }
        }

        public void Init(LevelDifficulty difficulty, List<GameObject> enemies){

        }

        // // Update is called once per frame
        // void Update()
        // {

        // }
    }
}
