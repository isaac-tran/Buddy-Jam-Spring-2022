using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleItem : Interactable
{
    [SerializeField] private Vector3 prevPosBeforePutInMagicCircle;
    public Vector3 PrevPosBeforePutInMagicCircle
    {
        get { return prevPosBeforePutInMagicCircle; }
    }
    [SerializeField] private bool isInsideTheCircle = false;
    public bool IsInsideTheCircle
    {
        get { return isInsideTheCircle; }
        set { isInsideTheCircle = value; }
    }
    private MagicCircle magicCircle;

    private void Awake()
    {
        magicCircle = GameObject.Find("Magic Circle").GetComponent<MagicCircle>();
    }

    public override void Interact()
    {
        //  If inside circle, put in. Else, remove
        if (!isInsideTheCircle)
        {
            prevPosBeforePutInMagicCircle = transform.position;
            magicCircle.PlaceObjectIntoCircle(this);
            
        }
        else
        {
            magicCircle.RemoveObjectFromCircle(this);
            
        }
    }
}
