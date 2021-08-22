using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    MeshRenderer mr;
    [SerializeField] float speed;

    // User Inputs
    float amplitude = 0.05f;
    float frequency = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        posOffset = transform.position;
    }

    void Update()
    {
        mr.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
