using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform startUI;
    public Transform gameUI;

    [SerializeField] bool firstPlay;
    [SerializeField] bool isOver;

    void Start()
    {
        this.firstPlay = true;
        this.isOver = false;
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        firstPlay = false;


        Time.timeScale = 1;
        startUI.gameObject.SetActive(false);

        gameUI.GetComponent<GameUIController>().startGame();
    }

    public void GameOver()
    {
        this.isOver = true;

        Time.timeScale = 0;
        startUI.gameObject.SetActive(true);
    }
}
