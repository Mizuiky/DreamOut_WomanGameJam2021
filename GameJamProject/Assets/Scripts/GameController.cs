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
    [SerializeField] InputField nameField;

    //Player
    [SerializeField] Transform player;

    private void Awake()
    {
        Time.timeScale = 0;
    }
    void Start()
    {
        nameField.text = "Player";
        startUI.gameObject.SetActive(true);
        scoreUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        player.GetComponent<PlayerController>().setPlayerName(this.nameField.text);
        startUI.gameObject.SetActive(false);
        scoreUI.gameObject.SetActive(false);

        gameUI.GetComponent<GameUIController>().startGame();
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        scoreUI.gameObject.SetActive(true);
        startUI.gameObject.SetActive(false);

        gameUI.GetComponent<GameUIController>().stopGame();
        Time.timeScale = 0;
    }

    public void BackToStartScreen()
    {
        scoreUI.gameObject.SetActive(false);
        startUI.gameObject.SetActive(true);
    }
}
