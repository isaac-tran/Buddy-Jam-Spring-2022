using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glyph : Interactable
{
    [Range(1, 100)]
    [SerializeField] private int number;
    public int Number
    {
        get { return number; }
        set 
        {
            if (value < 1) number = 1; 
            else number = value;
        }
    }

    public override void Interact()
    {
        Level1GameManager.Instance.ActivateGlyph(this);
    }
}
