using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public static Action OnPlayerFell;
    private void OnTriggerEnter(Collider other)
    {
        OnPlayerFell?.Invoke();
        Destroy(other.gameObject);
    }
}
