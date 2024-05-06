using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid
{
    private Dictionary<Vector3Int, TileBase> tiles = new Dictionary<Vector3Int, TileBase>();

    public bool HasTile(Vector3Int position)
    {
        Debug.Log("HasTile");
        return tiles.ContainsKey(position);
    }

    public void RemoveTile(Vector3Int position)
    {
        Debug.Log("RemoveTile1");
        if (tiles.ContainsKey(position))
        {
            Debug.Log("RemoveTile2");
            tiles.Remove(position);
        }
    }

    public void AddTile(Vector3Int position, TileBase tile)
    {
        if (!tiles.ContainsKey(position))
        {
            tiles.Add(position, tile);
        }
    }
}
