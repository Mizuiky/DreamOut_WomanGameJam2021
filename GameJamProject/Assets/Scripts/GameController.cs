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

    //Player
    [SerializeField] Transform player;

    //Audio
    [SerializeField] Transform audio;

    [SerializeField] InputField nameField;

    private GameUIController gameUIController;
    private AudioController audioController;
    private TimelineController timelineController;
    private PlayerController playerController;

    private void Awake()
    {
        pause = true;
        gameUIController = gameUI.GetComponent<GameUIController>();
        audioController = audio.GetComponent<AudioController>();
        timelineController = timeline.GetComponent<TimelineController>();
        playerController = player.GetComponent<PlayerController>();
    }
    void Start()
    {
        nameField.text = "Player";
        startUI.gameObject.SetActive(true);
        scoreUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        timeline.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(pause)
        {
            return;
        }

        //Win Conditions
        if(timelineController.isGameOver())
        {
            this.GameOver();
        }
        if (timelineController.isVictory())
        {
            this.GameOver();
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
            addPlayerPoints();
        }
        else
        {
            //Debug.Log("Player wrong hit");
            playWrongHit();
        }
    }

    private void addPlayerPoints()
    {
       
    }

    private void playRightHit()
    {
        gameUIController.setArrowColor(ArrowMode.ArrowState.RightHit);
        timelineController.rightHit();
        audioController.play("RightHit");
    }

    private void playWrongHit()
    {
        gameUIController.setArrowColor(ArrowMode.ArrowState.WrongHit);
        timelineController.wrongHit();
        audioController.play("WrongHit");
    }

    public void PlayGame()
    {
        startUI.gameObject.SetActive(false);
        scoreUI.gameObject.SetActive(false);

        playerController.setPlayerName(this.nameField.text);
        playerController.startGame();
        gameUIController.startGame();
        timelineController.startGame();

        audioController.play("DreamBackground");

        pause = false;
    }

    public void GameOver()
    {
        scoreUI.gameObject.SetActive(true);
        startUI.gameObject.SetActive(false);

        playerController.stopGame();
        gameUIController.stopGame();
        timelineController.stopGame();

        audioController.startToWake();
        gameUIController.backNormalArrowState();

        pause = true;
    }

    public void BackToStartScreen()
    {
        scoreUI.gameObject.SetActive(false);
        startUI.gameObject.SetActive(true);
    }
}
