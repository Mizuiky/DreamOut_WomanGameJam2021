using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] string playerName;

    public void startGame()
    {
        this.gameObject.SetActive(true);
    }

    public void stopGame()
    {
        this.gameObject.SetActive(false);
    }

    public void setPlayerName(string name)
    {
        this.playerName = name;
    }
}
