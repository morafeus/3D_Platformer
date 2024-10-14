using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.CompareTag("Finish") && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("win");
            PlayerManager.PlayerWin();
        }
    }
}
