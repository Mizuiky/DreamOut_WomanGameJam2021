using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] Transform[] positions = new Transform[4];
    [SerializeField] Transform[] candys = new Transform[6];

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SortCandy", 0, 2);
    }

    void SortCandy()
    {
        int p = Random.Range(0, 3);
        int c = Random.Range(0, 5);

        Transform t = candys[c];
        t.position = positions[p].position;

        Instantiate(candys[c], positions[p].position, Quaternion.identity);  
    }
}
