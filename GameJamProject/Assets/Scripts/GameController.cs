using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Game UI
    [SerializeField] Transform startUI;
    [SerializeField] Transform scoreUI;
    [SerializeField] Transform gameUI;

    //Audio
    [SerializeField] Transform audio;

    [SerializeField] InputField nameField;

    //Player
    [SerializeField] Transform player;
    private GameUIController gameUIController;
    private AudioController audioController;


    private void Awake()
    {
        Time.timeScale = 0;
        gameUIController = gameUI.GetComponent<GameUIController>();
        audioController = audio.GetComponent<AudioController>();
    }
    void Start()
    {
        nameField.text = "Player";
        startUI.gameObject.SetActive(true);
        scoreUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Time.timeScale <= 0)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("clicked in the UpArrow");
            checkTheCurrentySortedArrow(0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("clicked in the LeftArrow");
            checkTheCurrentySortedArrow(1);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("clicked in the RightArrow");
            checkTheCurrentySortedArrow(2);
        }          
    }

    private void checkTheCurrentySortedArrow(int index)
    {
        if (index == gameUIController.sortedArrow)
        {
            Debug.Log("Player right hit");
            playRightHit();
            addPlayerPoints();
        }
        else
        {
            Debug.Log("Player wrong hit");
            playWrongHit();
        }
    }

    private void addPlayerPoints()
    {
       
    }

    private void playRightHit()
    {
        gameUIController.setArrowColor(ArrowMode.ArrowState.RightHit);
        audioController.Play("RightHit");
    }

    private void playWrongHit()
    {
        gameUIController.setArrowColor(ArrowMode.ArrowState.WrongHit);
        audioController.Play("WrongHit");
    }

    public void PlayGame()
    {
        startUI.gameObject.SetActive(false);
        scoreUI.gameObject.SetActive(false);

        player.GetComponent<PlayerController>().setPlayerName(this.nameField.text);
        player.GetComponent<PlayerController>().startGame();
        gameUIController.startGame();
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        scoreUI.gameObject.SetActive(true);
        startUI.gameObject.SetActive(false);

        player.GetComponent<PlayerController>().stopGame();
        gameUIController.stopGame();
        Time.timeScale = 0;
    }

    public void BackToStartScreen()
    {
        scoreUI.gameObject.SetActive(false);
        startUI.gameObject.SetActive(true);
    }
}
