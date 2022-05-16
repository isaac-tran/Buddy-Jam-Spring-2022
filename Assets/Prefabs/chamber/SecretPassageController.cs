using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPassageController : MonoBehaviour
{

    void Start()
    {
        GetComponent<Animator>().speed = 0.15f;
        GetComponent<Animator>().Play("moveDown");
        //StartBookshelveAnimation(5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartBookshelveAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Animator>().Play("moveDown");
        Debug.Log("moving down?");
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
