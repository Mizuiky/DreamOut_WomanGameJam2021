using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public enum ArrowType
    {
        Up = 0,
        Left = 1,
        Right = 2
    }

    [SerializeField] GameObject [] arrows;
    [SerializeField] Color arrowHighlight;
    [SerializeField] Color normalArrow;

    [HideInInspector]
    public int choosedArrow;

    private bool play = false;

    public void startGame()
    {
        play = true;
        this.gameObject.SetActive(true);
        StartCoroutine(startSort());
    }

    public void stopGame()
    {
        play = false;
        this.gameObject.SetActive(false);
    }

    private IEnumerator startSort()
    {   
        while(play)
        {
            Debug.Log("Sort Arrow");
            
            sortArrow();
            arrows[choosedArrow].gameObject.GetComponent<Image>().color = arrowHighlight;
            yield return new WaitForSeconds(1.5f);
            arrows[choosedArrow].gameObject.GetComponent<Image>().color = normalArrow;
        }     
    }

    public void sortArrow()
    {
        int randowNumber = Random.Range(0, 3);
        setSortedArrow(randowNumber);
        Debug.Log("sorted Arrow:" + this.choosedArrow);
    }

    private void setSortedArrow(int index)
    {
        switch(index)
        {
            case 0:
                choosedArrow = (int)ArrowType.Up;
                break;
            case 1:
                choosedArrow = (int)ArrowType.Right;
                break;
            case 2:
                choosedArrow = (int)ArrowType.Left;
                break;
        }
    }  
}
