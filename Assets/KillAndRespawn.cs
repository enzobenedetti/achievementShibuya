using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAndRespawn : MonoBehaviour
{
    public GameObject playerPrefabs;
    
    public static Action OnPlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        DeathZone.OnPlayerFell += delegate
        {
            OnPlayerDeath?.Invoke();
        };
        OnPlayerDeath += PlayerRespawn;
    }

    private void PlayerRespawn()
    {
        Instantiate(playerPrefabs, transform.position, Quaternion.identity);
    }
}
