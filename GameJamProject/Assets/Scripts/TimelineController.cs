using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineController : MonoBehaviour
{
    [SerializeField] Transform monster;
    [SerializeField] Transform thunder;

    //Timeline
    [SerializeField] Transform background;
    [SerializeField] Transform playerPoint;
    [SerializeField] Transform audioComponent;

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
        if (GameController.pause)
        {
            return;
        }

        distance = CalculateDistance();
        float playerPointPosition = (distance / 1000);

        playerPoint.position = new Vector3((6 * playerPointPosition) -3, playerPoint.position.y, 0);
        background.position = new Vector3(background.position.x, (10 * playerPointPosition) -5, background.position.z);

        MonsterPosition(playerPointPosition*10);
    }

    public void startGame()
    {
        play = true;

        distance = 500;
        nightmarePosition = 0;
        nightmareVelocity = 1;
        playerPosition = 500;
        playerVelocity = 10;

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
        playerVelocity += 5;
    }

    public void wrongHit()
    {
        playerVelocity -= 3;
    }

    private void MonsterPosition(float position)
    {
        MonsterController mc = monster.GetComponent<MonsterController>();
        SpriteRenderer thunderSR = thunder.GetComponent<SpriteRenderer>();
        AudioController audio = audioComponent.GetComponent<AudioController>();

        Color colorTh = thunderSR.color;

        if (position > 6)
        {
            audio.play("Nightmare");
            audio.setSoundVolume("Nightmare", 0.01f);

            mc.setMonsterPosition(0);
            thunderSR.color = new Color(colorTh.r, colorTh.g, colorTh.b, 0);
        }
        else if (position < 6 && position > 5) 
        {
            audio.stop("Horse");
            audio.play("Nightmare");
            audio.setSoundVolume("DreamBackground", 0.04f);
            audio.setSoundVolume("Nightmare", 0.3f);

            mc.setMonsterPosition(1);
            thunderSR.color = new Color(colorTh.r, colorTh.g, colorTh.b, 0.03f);
        }

        else if(position < 5 && position > 4)
        {
            audio.play("Horse");
            audio.setSoundVolume("Nightmare", 0.4f);

            mc.setMonsterPosition(2);
            thunderSR.color = new Color(colorTh.r, colorTh.g, colorTh.b, 0.06f);
        }

        else if(position < 4)
        {           
            audio.setSoundVolume("Nightmare", 0.6f);
            
            mc.setMonsterPosition(3);
            thunderSR.color = new Color(colorTh.r, colorTh.g, colorTh.b, 1f);
        }
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
            yield return new WaitForSeconds(0.4f);
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
