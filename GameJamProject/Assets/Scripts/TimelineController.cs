using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineController : MonoBehaviour
{
    //Timeline
    [SerializeField] Transform line;
    [SerializeField] Transform nightmarePoint;
    [SerializeField] Transform playerPoint;
    [SerializeField] Transform flagPoint;

    //Positions
    [SerializeField] int nightmarePosition;
    [SerializeField] int nightmareVelocity;
    [SerializeField] int playerPosition;
    [SerializeField] int playerVelocity;

    [SerializeField] bool play = false;
    private float minDistance = 10;
    private float maxDistance = 1000;
    private float distance;

    void Start()
    {
        Debug.Log(nightmarePoint.transform.position.x);
        Debug.Log(flagPoint.transform.transform.position.x);
    }

    void Update()
    {
        distance = CalculateDistance();
        float playerPointPosition = (distance / 1000);
        playerPoint.position = new Vector3((6 * playerPointPosition) - 3, playerPoint.position.y, 0);

        if (distance <= minDistance)
        {
            Debug.Log("Defeat");
            stopGame();
        }
        if (distance > maxDistance)
        {
            Debug.Log("Victory");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerVelocity -= 3;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerVelocity += 3;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartGame();
        }
    }


    public void StartGame()
    {
        play = true;
        StartCoroutine(UpdateEnemyVelocity());
        StartCoroutine(UpdatePositions());
        StartCoroutine(ReducePlayerVelocity());
    }

    public void stopGame()
    {
        play = false;
    }

    IEnumerator UpdatePositions()
    {
        while (play)
        {
            yield return new WaitForSeconds(0.2f);
            nightmarePosition += nightmareVelocity;
            playerPosition += playerVelocity;
        }
    }

    IEnumerator ReducePlayerVelocity()
    {
        while (play)
        {
            yield return new WaitForSeconds(1);
            if (playerVelocity > 0)
            {
                playerVelocity--;
            }
        }
    }

    IEnumerator UpdateEnemyVelocity()
    {
        while (play)
        {
            yield return new WaitForSeconds(0.5f);
            
            if(distance >= 10)
            {
                nightmareVelocity++;
            }
        }
    }
    float CalculateDistance()
    {
        float deltaVelocity = nightmareVelocity - playerVelocity;
        float deltaPosition = playerPosition - nightmarePosition;

        if(deltaVelocity == 0)
        {
            deltaVelocity = 1;
        }

        return deltaPosition - deltaVelocity;
    }
}
