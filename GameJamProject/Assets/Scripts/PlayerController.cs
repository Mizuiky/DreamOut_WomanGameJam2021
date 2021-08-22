using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void startGame()
    {
        this.gameObject.SetActive(true);
    }

    public void stopGame()
    {
        this.gameObject.SetActive(false);
    }
}
