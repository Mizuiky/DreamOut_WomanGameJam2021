using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform[] positions = new Transform[4];
    [SerializeField] int pos = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, positions[pos].position, 0.4f * Time.deltaTime);
    }

    public void startGame()
    {
        this.gameObject.SetActive(true);
    }

    public void stopGame()
    {
        transform.position = positions[0].position;
        this.gameObject.SetActive(false);
    }

    public void setMonsterPosition(int p)
    {
        this.pos = p;
    }
}
