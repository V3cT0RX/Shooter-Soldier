using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroDetection : MonoBehaviour
{
    public System.Action<Transform> OnAggro = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerMovement>();

        if (player != null)
        {
            OnAggro(player.transform);
            Debug.Log("Aggerd");
        }
    }
}
