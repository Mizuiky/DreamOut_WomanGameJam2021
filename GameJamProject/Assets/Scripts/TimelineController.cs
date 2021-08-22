using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineController : MonoBehaviour
{
    //Timeline
    [SerializeField] Transform background;
    [SerializeField] Transform playerPoint;

    //Positions
    [SerializeField] int nightmarePosition;
    [SerializeField] int nightmareVelocity;
    [SerializeField] int playerPosition;
    [SerializeField] int playerVelocity;

    [SerializeField] bool play = false;
    private float minDistance = 30;
    private float maxDistance = 1000;
    private float distance;

    void Update()
    {
        if (Time.timeScale <= 0)
        {
            return;
        }

        distance = CalculateDistance();
        float playerPointPosition = (distance / 1000);

        playerPoint.position = new Vector3((6 * playerPointPosition) -3, playerPoint.position.y, 0);
        background.position = new Vector3(background.position.x, (10 * playerPointPosition) -5, background.position.z);
    }

    public void startGame()
    {
        play = true;

        distance = 500;
        nightmarePosition = 0;
        nightmareVelocity = 1;
        playerPosition = 500;
        playerVelocity = 20;

        this.gameObject.SetActive(true);

        StartCoroutine(UpdateEnemyVelocity());
        StartCoroutine(UpdatePositions());
        StartCoroutine(ReducePlayerVelocity());
    }

    public void stopGame()
    {
        play = false;
        this.gameObject.SetActive(false);
    }

    public bool isVictory()
    {
        return distance > maxDistance;
    }

    public bool isGameOver()
    {
        return distance <= minDistance;
    }

    public void rightHit()
    {
        playerVelocity += 10;
    }

    public void wrongHit()
    {
        playerVelocity -= 10;
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
