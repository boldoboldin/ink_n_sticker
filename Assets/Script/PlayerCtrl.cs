using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCtrl : MonoBehaviour
{
    private PlayerCtrls ctrls;

    [SerializeField] private Tilemap playerTilemap;
    public Tilemap[] otherPlayersTilemaps; 
    [SerializeField] private Tilemap colTilemap;
    [SerializeField] private TileBase newTile;

    public Grid playerGrid = new Grid();

    private void Awake()
    {
        ctrls = new PlayerCtrls();
    }

    private void OnEnable()
    {
        ctrls.Enable();
    }

    private void OnDisable()
    {
        ctrls.Disable();
    }

    private void Start()
    {
        if (transform.CompareTag("Player1"))
        {
            ctrls.Main.P1_Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        }
        else if (transform.CompareTag("Player2"))
        {
            ctrls.Main.P2_Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        }
        else if (transform.CompareTag("Player3"))
        {
            ctrls.Main.P3_Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        }
        else if (transform.CompareTag("Player4"))
        {
            ctrls.Main.P4_Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        }
    }

    private void Move(Vector2 direction)
    {
        if (CanMove(direction))
        {
            transform.position += (Vector3)direction;
            Vector3Int gridPos = playerTilemap.WorldToCell(transform.position);
            playerTilemap.SetTile(gridPos, newTile);

            // Remove o tile nas outras camadas dos outros jogadores na mesma posição
            for (int i = 0; i < otherPlayersTilemaps.Length; i++)
            {
                otherPlayersTilemaps[i].SetTile(gridPos, null);
            }
        }
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPos = playerTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (colTilemap.HasTile(gridPos))
        {
            return false;
        }
        return true; // Implemente sua lógica de movimento aqui
    }
}