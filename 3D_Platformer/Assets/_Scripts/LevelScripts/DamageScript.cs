using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damageCount = 10;
    private Coroutine damageColorCoroutine;
    private bool isOnPlatform = false;

    private void OnCollisionStay(Collision collision)
    {
        isOnPlatform = true;

        if (gameObject.CompareTag("DamageBlock") && damageColorCoroutine == null)
        {
            damageColorCoroutine = StartCoroutine(CoroutineDamageColor(GetComponent<Collider>(), collision));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isOnPlatform = false;
    }

    public IEnumerator CoroutineDamageColor(Collider collider, Collision collision)
    {
        Material originalMaterial = new Material(collider.gameObject.GetComponent<Renderer>().material);

        collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(1);
        collider.gameObject.GetComponent<Renderer>().material.color = Color.red;

        if (isOnPlatform)
        {
            PlayerManager.Damage(damageCount);
        }

        yield return new WaitForSeconds(0.3f);

        Renderer renderer = collider.gameObject.GetComponent<Renderer>();
        Color originalColor = Color.green;
        float elapsedTime = 0f;

        while (elapsedTime < 5f)
        {
            float t = Mathf.PingPong(elapsedTime * 2f, 1f);
            renderer.material.color = Color.Lerp(originalColor, originalMaterial.color, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }


        renderer.material.color = originalMaterial.color;
        yield return new WaitForSeconds(0.3f);

        damageColorCoroutine = null;

        if (isOnPlatform)
        {
            damageColorCoroutine = StartCoroutine(CoroutineDamageColor(collider, collision));
        }
    }
}
