using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidScript : MonoBehaviour
{
    public int damageCount = 10;
    private Coroutine damageAcidCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            damageAcidCoroutine = StartCoroutine(CoroutineDamageAcid());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
       
            if (damageAcidCoroutine != null)
            {
                StopCoroutine(damageAcidCoroutine);
                damageAcidCoroutine = null;
            }
        }
    }

    private IEnumerator CoroutineDamageAcid()
    {
        while (true) 
        {
            PlayerManager.Damage(damageCount);
            yield return new WaitForSeconds(0.5f); 
        }
    }
}
