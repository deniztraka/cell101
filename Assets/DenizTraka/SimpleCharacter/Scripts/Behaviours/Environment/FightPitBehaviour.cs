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

        public Vector2 MapSize;

        public List<TileBase> FloorTiles;
        public TileBase WallTileFront;
        public TileBase WallTileFrontRight;
        public TileBase WallTileFrontLeft;
        public TileBase WallTileRight;
        public TileBase WallTileBack;
        public TileBase WallTileLeft;

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

            PlaceFloorTiles();
            PlaceWallTiles();
        }

        public void Init(LevelDifficulty difficulty, List<GameObject> enemies)
        {
            PlaceFloorTiles();
            PlaceWallTiles();
        }

        private void PlaceWallTiles()
        {
            for (int x = xMin; x < xMax; x++)
            {
                WallMap.SetTile(new Vector3Int(x, yMax, 0), WallTileFront); //top edge
                WallMap.SetTile(new Vector3Int(x, yMin - 1, 0), WallTileBack); //bottom edge
            }
            for (int y = yMin; y < yMax; y++)
            {
                WallMap.SetTile(new Vector3Int(xMax, y, 0), WallTileRight); //right edge
                WallMap.SetTile(new Vector3Int(xMin - 1, y, 0), WallTileLeft); //left edge
            }

            WallMap.SetTile(new Vector3Int(xMax, yMin-1, 0), WallTileBack); //bottom right corner
            WallMap.SetTile(new Vector3Int(xMin-1, yMin-1, 0), WallTileBack); //bottom left corner
            WallMap.SetTile(new Vector3Int(xMax, yMax, 0), WallTileFrontRight); //top right corner
            WallMap.SetTile(new Vector3Int(xMin-1, yMax, 0), WallTileFrontLeft); //topleft corner

        }

        private void PlaceFloorTiles()
        {
            for (int x = xMin; x < xMax; x++)
            {
                for (int y = yMin; y < yMax; y++)
                {
                    FloorMap.SetTile(new Vector3Int(x, y, 0), FloorTiles[0]);
                }
            }
        }
    }
}
