using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenButton : MonoBehaviour
{
    [SerializeField] Image choiceBar;
    RectTransform choiceBarRectTransform;
    Vector3 buttonPos;
    [SerializeField] float choiceBarMoveDuration = 0.3f;

    private void Start()
    {
        //choiceBarRectTransform = choiceBar.rectTransform;   
        buttonPos = GetComponent<RectTransform>().localPosition;
    }

    void MoveChoiceBarToButtonPosition()
    {
        StartCoroutine(AnimateMove());   
    }

    IEnumerator AnimateMove()
    {
        Vector3 previousPosition = choiceBar.rectTransform.localPosition;

        float framesToAnimate = choiceBarMoveDuration / Time.deltaTime;
        for (float i = 0; i < framesToAnimate + 1; i++)
        {
            choiceBar.rectTransform.localPosition = Vector3.Lerp(previousPosition, buttonPos, i / framesToAnimate);
            yield return null;
        }

        //choiceBar.rectTransform.localPosition = buttonPos;
        yield return null;
    }
}
