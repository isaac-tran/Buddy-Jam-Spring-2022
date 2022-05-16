using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPassageController : MonoBehaviour
{
    public float animSpeed = 0.15f;

    void Start()
    {
        //StartBookshelveAnimation(5f);
    }

    public void MoveDown()
    {
        GetComponent<Animator>().speed = 0.15f;
        GetComponent<Animator>().Play("moveDown");
    }


    /*
    public float staggerDelay = 1f;
    public List<Animator> bookshelves;

    private int index = 0;
    private bool isMovingDown = true;
    private bool isAnimating = false;
    */

    // Start is called before the first frame update

    /*
    public void MoveDown()
    {
        isMovingDown = true;
        isAnimating = true;
        StartCoroutine(StartBookshelveAnimation(5f));
    }

    IEnumerator StartBookshelveAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);
        bookshelves[index].Play("moveDown");

        index += 1;
        if(index > bookshelves.Count)
        {
            isAnimating = false;
        }
        else
        {
            StartCoroutine(StartBookshelveAnimation(staggerDelay));
        }
    }
    */



}
