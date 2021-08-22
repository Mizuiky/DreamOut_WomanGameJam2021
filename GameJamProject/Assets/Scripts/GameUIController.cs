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

    [SerializeField] Color sortedArrowHighlight;
    [SerializeField] Color wrongArrowHighlight;
    [SerializeField] Color rightArrow;
    [SerializeField] Color normalArrow;

    [HideInInspector]
    public int sortedArrow = -1;

    private bool play = false;

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
            //Debug.Log("Sort Arrow");
            
            sortArrow();

            yield return new WaitForSeconds(0.2f);

            setArrowColor(ArrowMode.ArrowState.Sorted);

            //Debug.Log("Before the delay ");

            yield return new WaitForSeconds(0.8f);

            //Debug.Log("Done the delay ");

            setArrowColor(ArrowMode.ArrowState.Normal);
        }     
    }

    public void sortArrow()
    {
        int randowNumber = Random.Range(0, 3);
        setSortedArrow(randowNumber);

        //Debug.Log("sorted Arrow:" + this.choosedArrow);
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

    public void setArrowColor(ArrowMode.ArrowState arrowState)
    {
        switch(arrowState)
        {
            case ArrowMode.ArrowState.Normal:
                arrows[sortedArrow].gameObject.GetComponent<Image>().color = normalArrow;
                break;
            case ArrowMode.ArrowState.Sorted:
                arrows[sortedArrow].gameObject.GetComponent<Image>().color = sortedArrowHighlight;
                break;
            case ArrowMode.ArrowState.RightHit:
                arrows[sortedArrow].gameObject.GetComponent<Image>().color = rightArrow;
                break;
            case ArrowMode.ArrowState.WrongHit:
                arrows[sortedArrow].gameObject.GetComponent<Image>().color = wrongArrowHighlight;
                break;
        }
    }

    public void backNormalArrowState()
    {
        foreach(GameObject arrow in arrows)
        {
            arrow.GetComponent<Image>().color = normalArrow;
        }
    }
}
