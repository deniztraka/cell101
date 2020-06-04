using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DTWorld.Core.Tiles
{

    public class FloorTile : Tile
    {

#if UNITY_EDITOR
        [MenuItem("Assets/Create/DTWorldz/Tiles/Floor")]
        public static void CreateTile()
        {
            var path = EditorUtility.SaveFilePanelInProject("Save Floor Tile", "FloorTile", "asset", "Save Floor Tile", "Assets");
            if (path == "")
            {
                return;
            }

            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<FloorTile>(), path);
        }
#endif



    }
}
