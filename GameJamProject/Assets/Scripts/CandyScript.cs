using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
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
        Destroy(this.gameObject, 10f);
        posOffset = transform.position;
    }

    void Update()
    {
        // Float up/down with a Sin()
        tempPos = transform.position;
        tempPos.y = posOffset.y;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        tempPos.x -= speed * Time.deltaTime;

        transform.position = tempPos;
    }
}
