using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static bool pause = true;

    //Game UI
    [SerializeField] Transform startUI;
    [SerializeField] Transform scoreUI;
    [SerializeField] Transform gameUI;
    [SerializeField] Transform timeline;
    [SerializeField] Transform gameOverUI;

    //Characters
    [SerializeField] Transform player;
    [SerializeField] Transform monster;

    //Audio
    [SerializeField] Transform audioComponent;
    
    private GameUIController gameUIController;
    private AudioController audioController;
    private TimelineController timelineController;
    private PlayerController playerController;
    private ScoreController scoreController;
    private MonsterController monsterController;

    private int playerScore;

    private void Awake()
    {
        pause = true; 
        gameUIController = gameUI.GetComponent<GameUIController>();
        audioController = audioComponent.GetComponent<AudioController>();
        timelineController = timeline.GetComponent<TimelineController>();
        playerController = player.GetComponent<PlayerController>();
        scoreController = scoreUI.GetComponent<ScoreController>();
        monsterController = monster.GetComponent<MonsterController>();
    }

    void Start()
    {
        audioController.play("Menu");
        startUI.gameObject.SetActive(true);
        scoreUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        timeline.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);

        playerScore = 0;
    }

    private void Update()
    {
        if(pause)
        {
            return;
        }

        gameUI.Find("Score").GetComponent<Text>().text = playerScore.ToString();
        //Win Conditions
        if (timelineController.isGameOver())
        {
            this.GameOver();
        }
        if (timelineController.isVictory())
        {
            this.Victory();
        }

        //Input Buttons
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Debug.Log("clicked in the UpArrow");
            checkTheCurrentySortedArrow(0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Debug.Log("clicked in the LeftArrow");
            checkTheCurrentySortedArrow(1);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Debug.Log("clicked in the RightArrow");
            checkTheCurrentySortedArrow(2);
        }          
    }

    private void checkTheCurrentySortedArrow(int index)
    {
        if (index == gameUIController.sortedArrow)
        {
            //Debug.Log("Player right hit");
            playRightHit();
            playerScore += 10;
        }
        else
        {
            //Debug.Log("Player wrong hit");
            playWrongHit();
        }
    }

    private void playRightHit()
    {
        gameUIController.setArrowColor(ArrowMode.ArrowState.RightHit);
        timelineController.rightHit();
        audioController.play("RightHit");
    }

    private void playWrongHit()
    {
        playerController.setAnimatorParameter("hadRightHit", false);
        gameUIController.setArrowColor(ArrowMode.ArrowState.WrongHit);
        timelineController.wrongHit();
        audioController.play("WrongHit");
        changeBoatAnimation();
    }

    public void PlayGame()
    {
        playerScore = 0;
        gameUIController.backNormalArrowState();

        audioController.stop("Clock");
        audioController.play("ButtonClick");
        audioController.stop("Menu");

        startUI.gameObject.SetActive(false);
        scoreUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);

        playerController.startGame();
        monsterController.startGame();
        gameUIController.startGame();
        timelineController.startGame();

        audioController.setSoundVolume("DreamBackground", 0.1f);
        audioController.play("DreamBackground");

        pause = false;
    }

    public void Victory()
    {
        endGameVictory();
    }

    public void GameOver()
    {
        endGame();       
    }

    public void BackToStartScreen()
    {
        scoreUI.gameObject.SetActive(false);
        startUI.gameObject.SetActive(true);
    }

    public void changeBoatAnimation()
    {
        StartCoroutine(boatAnimation());
    }

    public void endGame()
    {
        StartCoroutine(gameOverDelay());
    }

    public void endGameVictory()
    {
        StartCoroutine(victoryDelay());
    }

    private IEnumerator boatAnimation()
    {
        yield return new WaitForSeconds(0.04f);
        playerController.setAnimatorParameter("hadRightHit", true);
    }

    private IEnumerator gameOverDelay()
    {
        pause = true;

        yield return new WaitForSeconds(0.9f);

        gameUIController.backNormalArrowState();

        gameUIController.stopGame();
        timelineController.stopGame();

        playerController.stopGame();
        monsterController.stopGame();

        audioController.startBadAwake();

        //Temp
        scoreController.setScoreScreen(playerScore);

        //Trocar pra tela de game over
        scoreUI.gameObject.SetActive(false);
        startUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
    }

    private IEnumerator victoryDelay()
    {
        pause = true;

        yield return new WaitForSeconds(0.9f);

        scoreController.setScoreScreen(playerScore);

        audioController.startGoodAwake();

        scoreUI.gameObject.SetActive(true);
        startUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);

        playerController.stopGame();
        monsterController.stopGame();
        gameUIController.stopGame();
        timelineController.stopGame();
    }

    public void doExitGame()
    {
        Application.Quit();
    }
}
