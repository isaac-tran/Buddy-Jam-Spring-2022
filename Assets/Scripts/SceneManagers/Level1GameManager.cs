using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1GameManager : MonoBehaviour
{
    private static Level1GameManager _instance;
    public static Level1GameManager Instance
    {
        get { return _instance; }
    }

    [SerializeField] ScreenTransitions screenTransitions;

    //  Riddle 1
    [SerializeField] private bool key1 = false, key2 = false, key3 = false;
    public bool Key1 { get { return key1; } }
    public bool Key2 { get { return key2; } }
    public bool Key3 { get { return key3; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(screenTransitions.FadeIn(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AcquireKey1() { key1 = true; }
    public void AcquireKey2() { key2 = true; }
    public void AcquireKey3() { key3 = true; }
}
