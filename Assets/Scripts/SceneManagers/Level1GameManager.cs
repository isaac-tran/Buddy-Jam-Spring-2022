using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1GameManager : MonoBehaviour
{
    [SerializeField] ScreenTransitions screenTransitions;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(screenTransitions.FadeIn(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
