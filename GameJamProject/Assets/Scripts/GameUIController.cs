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
    public int choosedArrow;

    void Update()
    {
      
    }

    // Update is called once per frame

    public void startGame()
    {
        Debug.Log("Start here");
        play = true;

        StartCoroutine(startSort());
    }

    private IEnumerator startSort()
    {   
        while(play)
        {
            sortArrow();

            arrows[choosedArrow].gameObject.GetComponent<Image>().color = arrowHighlight;

            Debug.Log("Before the delay ");

            yield return new WaitForSeconds(1.5f);

            Debug.Log("Done the delay ");

            arrows[choosedArrow].gameObject.GetComponent<Image>().color = normalArrow;
        }     
    }

    public void sortArrow()
    {
        int randowNumber = Random.Range(0, 3);

        setSortedArrow(randowNumber);

        Debug.Log("sortedArrow " + this.choosedArrow);
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
