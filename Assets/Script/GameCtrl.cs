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

    // N�o � mais necess�rio verificar colis�es entre os jogadores
}