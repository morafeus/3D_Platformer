using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneScript : MonoBehaviour
{
    public GameObject particleZone;
    public ParticleSystem windEffect;

    private float x;
    private float z;
    private float xForce;
    private float zForce;

    private void Start()
    {
        StartCoroutine(RandomWindVector());
    }

    private void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(0, Mathf.Atan2(x*xForce, z*zForce) * Mathf.Rad2Deg, 0);
        particleZone.transform.rotation = Quaternion.Slerp(particleZone.transform.rotation, targetRotation, Time.deltaTime * 10f);
        var mainModule = windEffect.main;
        if (xForce * zForce < 62)
            mainModule.simulationSpeed = 0.3f;
        else if (xForce * zForce < 66)
            mainModule.simulationSpeed = 2f;
        else
            mainModule.simulationSpeed = 5f;

        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (gameObject.CompareTag("WindZone") && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(x*xForce, 0, z*zForce), ForceMode.Acceleration);
        }
    }

    private IEnumerator RandomWindVector()
    {
        x = UnityEngine.Random.Range(-1f, 1f);
        z = UnityEngine.Random.Range(-1f, 1f);
        xForce = UnityEngine.Random.Range(7.6f, 8.3f);
        zForce = UnityEngine.Random.Range(7.6f, 8.3f);
        yield return new WaitForSeconds(2);
        yield return RandomWindVector();
    }
}
