using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    public static GameCtrl instance;

    private List<PlayerCtrl> players;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        players = new List<PlayerCtrl>(FindObjectsOfType<PlayerCtrl>());
    }

    // Não é mais necessário verificar colisões entre os jogadores
}