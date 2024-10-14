using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTrapScript : MonoBehaviour
{
    public GameObject pillar;
    public GameObject balk;
    public float rotationSpeed = 50f;

    void Update()
    {
        if (pillar != null)
        {
            balk.transform.RotateAround(pillar.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
