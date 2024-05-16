using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileCounter : MonoBehaviour
{
    [SerializeField] Tilemap p1Tilemap;
    [SerializeField] Tilemap p2Tilemap;
    [SerializeField] Tilemap p3Tilemap;
    [SerializeField] Tilemap p4Tilemap;

    public Vector3Int startCell;
    public Vector3Int endCell;

    public List<PlayerScore> GetRankings()
    {
        int p1Count = CountFilledTiles(p1Tilemap);
        int p2Count = CountFilledTiles(p2Tilemap);
        int p3Count = CountFilledTiles(p3Tilemap);
        int p4Count = CountFilledTiles(p4Tilemap);

        List<PlayerScore> playerScores = new List<PlayerScore>
        {
            new PlayerScore("Player 1", p1Count),
            new PlayerScore("Player 2", p2Count),
            new PlayerScore("Player 3", p3Count),
            new PlayerScore("Player 4", p4Count)
        };

        playerScores.Sort((x, y) => y.Score.CompareTo(x.Score));
        return playerScores;
    }

    private int CountFilledTiles(Tilemap tilemap)
    {
        int count = 0;
        for (int x = startCell.x; x <= endCell.x; x++)
        {
            for (int y = startCell.y; y <= endCell.y; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, startCell.z);
                if (tilemap.HasTile(cellPosition))
                {
                    count++;
                }
            }
        }
        return count;
    }

    public class PlayerScore
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }

        public PlayerScore(string playerName, int score)
        {
            PlayerName = playerName;
            Score = score;
        }
    }
}
