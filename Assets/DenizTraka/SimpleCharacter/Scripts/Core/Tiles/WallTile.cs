using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DTWorld.Core.Tiles
{

    public class WallTile : Tile
    {

#if UNITY_EDITOR
        [MenuItem("Assets/Create/DTWorldz/Tiles/Wall")]
        public static void CreateTile()
        {
            var path = EditorUtility.SaveFilePanelInProject("Save Wall Tile", "WallTile", "asset", "Save Wall Tile", "Assets");
            if (path == "")
            {
                return;
            }

            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<WallTile>(), path);
        }
#endif



    }
}
