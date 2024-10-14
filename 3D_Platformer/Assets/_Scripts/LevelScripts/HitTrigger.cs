using AstronautPlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    public float hitForce = 10f; 

    private void OnCollisionEnter(Collision collision)
    {
        IPunchable punchable = collision.gameObject.GetComponent<IPunchable>();
        if (punchable != null)
        {
            Vector3 hitDirection = collision.transform.position - transform.position;
            punchable.OnHit(hitDirection, hitForce); 
        }
    }
}
