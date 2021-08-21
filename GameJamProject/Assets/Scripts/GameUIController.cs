using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject [] arrows;

    [SerializeField] Color arrowHighlight;
    [SerializeField] Color normalArrow;

    private bool play = false;

    public enum ArrowType
    {
        Up = 0,
        Left = 1,
        Right = 2
    }

    [HideInInspector]
    public int sortedArrow = -1;

    void Update()
    {
      
    }

    // Update is called once per frame

    public void startGame()
    {
        //Debug.Log("Start here");
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
            sortArrow();

            arrows[sortedArrow].gameObject.GetComponent<Image>().color = arrowHighlight;

            //Debug.Log("Before the delay ");

            yield return new WaitForSeconds(1.5f);

            //Debug.Log("Done the delay ");

            arrows[sortedArrow].gameObject.GetComponent<Image>().color = normalArrow;
        }     
    }

    public void sortArrow()
    {
        int randowNumber = Random.Range(0, 3);

        setSortedArrow(randowNumber);

        //Debug.Log("sortedArrow " + this.sortedArrow);
    }

    private void setSortedArrow(int index)
    {
        switch(index)
        {
            case 0:
                sortedArrow = (int)ArrowType.Up;
                break;
            case 1:
                sortedArrow = (int)ArrowType.Right;
                break;
            case 2:
                sortedArrow = (int)ArrowType.Left;
                break;
        }
    }  
}
