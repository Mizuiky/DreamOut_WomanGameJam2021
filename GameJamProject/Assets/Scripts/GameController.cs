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

    private void Awake()
    {
        Time.timeScale = 0;
    }
    void Start()
    {
        scoreUI.gameObject.SetActive(false);
        startUI.gameObject.SetActive(true);
    }

    public void PlayGame()
    {
        playerName = nameField.text;
        startUI.gameObject.SetActive(false);
        scoreUI.gameObject.SetActive(false);
        gameUI.GetComponent<GameUIController>().startGame();
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        scoreUI.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void BackToStartScreen()
    {
        scoreUI.gameObject.SetActive(false);
        startUI.gameObject.SetActive(true);
    }
}
