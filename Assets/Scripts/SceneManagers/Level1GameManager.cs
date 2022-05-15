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
    [SerializeField] private int[] correctGlyphs = new int[3];
    [SerializeField] private int[] playersChosenGlyphs = new int[3];
    [SerializeField] private bool riddle1DoorOpened = false;

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

    public void ActivateGlyph(Glyph glyph)
    {
        //  First activated glyph
        if (playersChosenGlyphs[0] < 1)         
        {
            playersChosenGlyphs[0] = glyph.Number;
            return;
        }

        //  Second activated glyph
        if (playersChosenGlyphs[1] < 1)    
        {
            playersChosenGlyphs[1] = glyph.Number;
            return;
        }

        //  Third activated glyph, check, reset
        playersChosenGlyphs[2] = glyph.Number;
        for (int i = 0; i < 3; i++)
        {
            //  if wrong glyph, reset, retrun
            if (playersChosenGlyphs[i] != correctGlyphs[i])
            {
                for (int j = 0; j < 3; j++)
                {
                    playersChosenGlyphs[j] = 0;
                }
                return;
            }
        }

        //  All glyphs correct
        ActivateRiddle1Door();
    }

    void ActivateRiddle1Door()
    {
        riddle1DoorOpened = true;
    }
}
