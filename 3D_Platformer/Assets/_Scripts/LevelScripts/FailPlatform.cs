using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FailPlatform : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPosition; 
    public float dropAmount = 4.5f; 
    public float liftSpeed = 1f;

    private bool isPlayerOn = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position; 
    }

    private void OnCollisionStay(Collision collision)
    {
        if (gameObject.CompareTag("PhysicBlock") && collision.gameObject.CompareTag("Player"))
        {
            isPlayerOn = true;
            if(transform.position.y > initialPosition.y -2f) 
                rb.MovePosition(transform.position - Vector3.up * dropAmount * Time.deltaTime);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (gameObject.CompareTag("PhysicBlock") && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlatformWait());
        }
    }

    private void Update()
    {
        if (!isPlayerOn)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, liftSpeed * Time.deltaTime);
        }
    }

    private IEnumerator PlatformWait()
    {
        yield return new WaitForSeconds(0.7f);
        isPlayerOn = false;
    }

 
}
