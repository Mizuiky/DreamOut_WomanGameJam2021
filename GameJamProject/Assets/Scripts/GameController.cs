using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform startUI;
    public Transform scoreUI;
    public Transform gameUI;

    [SerializeField] InputField nameField;
    [SerializeField] string playerName;

    private GameUIController gameUIController;
    private int inputIndex = -1;

    private bool checkingButtonPressed = false;
    private void Awake()
    {
        Time.timeScale = 0;
        gameUIController = gameUI.GetComponent<GameUIController>();
    }
    void Start()
    {
        startUI.gameObject.SetActive(true);
        scoreUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(false);
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

            checkingButtonPressed = false;
        }
        else
        {
            Debug.Log("Player wrong hit");
            playWrongHit();

            checkingButtonPressed = false;
        }
    }

    private void addPlayerPoints()
    {

    }

    private void playRightHit()
    {

    }

    private void playWrongHit()
    {

    }

    public void PlayGame()
    {
        this.playerName = this.nameField.text;
        startUI.gameObject.SetActive(false);
        scoreUI.gameObject.SetActive(false);

        gameUIController.startGame();
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        scoreUI.gameObject.SetActive(true);
        startUI.gameObject.SetActive(false);

        gameUIController.stopGame();
        Time.timeScale = 0;
    }

    public void BackToStartScreen()
    {
        scoreUI.gameObject.SetActive(false);
        startUI.gameObject.SetActive(true);
    }

}
