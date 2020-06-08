using System;
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

        public Vector2 MapSize = new Vector2(12, 8);

        public List<GameObject> Traps;
        public GameObject TrapsWrapper;

        public List<TileBase> FloorTiles;
        public TileBase WallTopLeft;
        public TileBase WallTop;
        public TileBase WallTopRight;
        public TileBase WallLeft;
        public TileBase WallRight;
        public TileBase WallBottomLeft;
        public TileBase WallBottomRight;
        public TileBase WallBottom;

        private int xMax = 0;
        private int xMin = 0;
        private int yMax = 0;
        private int yMin = 0;


        // Start is called before the first frame update
        void Start()
        {

            xMax = (int)MapSize.x / 2;
            xMin = -xMax;
            yMax = (int)MapSize.y / 2;
            yMin = -yMax;

            Init();

        }

        public void Init()
        {
            // Debug.Log(String.Format("xMin:{0}, xMax:{1}", xMin, xMax));
            // Debug.Log(String.Format("yMin:{0}, yMax:{1}", yMin, yMax));

            if (WallMap != null && FloorMap != null)
            {
                PlaceFloorTiles();
                PlaceWallTiles();
                PlaceTraps(LevelDifficulty.Hell);
            }
        }

        private void PlaceTraps(LevelDifficulty difficulty)
        {
            // Instantiate(Traps[UnityEngine.Random.Range(0, Traps.Count)], FloorMap.GetCellCenterWorld(new Vector3Int(0, 0, 0)), Quaternion.identity, TrapsWrapper.transform);
            // Instantiate(Traps[UnityEngine.Random.Range(0, Traps.Count)], FloorMap.GetCellCenterWorld(new Vector3Int(1, 1, 0)), Quaternion.identity, TrapsWrapper.transform);
            // return;

            for (int x = xMin+1; x < xMax-1; x++)
            {
                for (int y = yMin+2; y < yMax-1; y++)
                {
                    if (UnityEngine.Random.Range(0,100) < (int)difficulty)
                    {
                        Instantiate(Traps[UnityEngine.Random.Range(0, Traps.Count)], FloorMap.GetCellCenterWorld(new Vector3Int(x, y, 0)), Quaternion.identity, TrapsWrapper.transform);
                    }
                }
            }
        }

        public void Init(LevelDifficulty difficulty, List<GameObject> enemies)
        {
            if (WallMap != null && FloorMap != null)
            {
                PlaceFloorTiles();
                PlaceWallTiles();
                PlaceTraps(difficulty);
            }
        }

        private void PlaceFloorTiles()
        {
            for (int x = xMin; x < xMax; x++)
            {
                for (int y = yMin; y < yMax; y++)
                {
                    FloorMap.SetTile(new Vector3Int(x, y, 0), FloorTiles[UnityEngine.Random.Range(0, FloorTiles.Count)]);
                }
            }
        }

        private void PlaceWallTiles()
        {            
            WallMap.SetTile(new Vector3Int(xMax - 1, yMax - 1, 0), WallTopRight);
            for (int x = xMin + 1; x < xMax - 1; x++)
            {
                WallMap.SetTile(new Vector3Int(x, yMax - 1, 0), WallTop);
            }
            WallMap.SetTile(new Vector3Int(xMin, yMax - 1, 0), WallTopLeft);
            for (int y = yMin + 1; y < yMax - 1; y++)
            {
                WallMap.SetTile(new Vector3Int(xMin, y, 0), WallLeft);
            }
            WallMap.SetTile(new Vector3Int(xMax - 1, yMin, 0), WallBottomLeft);
            for (int x = xMin + 1; x < xMax - 1; x++)
            {
                WallMap.SetTile(new Vector3Int(x, yMin, 0), WallBottom);
            }
            WallMap.SetTile(new Vector3Int(xMin, yMin, 0), WallBottomRight);
            for (int y = yMin + 1; y < yMax - 1; y++)
            {
                WallMap.SetTile(new Vector3Int(xMax - 1, y, 0), WallRight);
            }
        }
    }
}
