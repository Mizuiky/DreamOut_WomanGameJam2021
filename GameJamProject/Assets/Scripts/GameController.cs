using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform startUI;

    [SerializeField] bool firstPlay;
    [SerializeField] bool isOver;

    void Start()
    {
        this.isOver = false;
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        startUI.Find("StartUIScore").gameObject.SetActive(true);

        Time.timeScale = 1;
        startUI.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        this.isOver = true;

        Time.timeScale = 0;
        startUI.gameObject.SetActive(true);
    }
}
