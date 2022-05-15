using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    [Header("Location of the 3 objects (This circle's location plus the displacement)")]
    [SerializeField] Vector3[] itemPos = new Vector3[3];

    [Space(10)]
    [Header("The 3 objects")]
    [SerializeField] MagicCircleItem[] chosenObjects = new MagicCircleItem[3];

    public void PlaceObjectIntoCircle(MagicCircleItem obj)
    {
        //  If empty space, place into the magic circle
        for (int i = 0; i < 3; i++)
        {
            if (chosenObjects[i] == null)
            {
                chosenObjects[i] = obj;
                chosenObjects[i].transform.position = transform.position + itemPos[i];
                chosenObjects[i].IsInsideTheCircle = true;
                return;
            }
        }

        //  Else, play dialogue that says circle is full, please remove an object from it first
    }

    public void RemoveObjectFromCircle(MagicCircleItem obj)
    {
        for (int i = 0; i < 3; i++)
        {
            if (chosenObjects[i] == obj)
            {
                chosenObjects[i].transform.position = chosenObjects[i].PrevPosBeforePutInMagicCircle;
                chosenObjects[i].IsInsideTheCircle = false;
                chosenObjects[i] = null;
                return;
            }
        }
    }
}
