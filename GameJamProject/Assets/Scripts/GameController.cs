using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
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
        gameUI.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        this.isOver = true;

        Time.timeScale = 0;
        gameUI.gameObject.SetActive(true);
    }
}
