using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueCharacter : MonoBehaviour
{
    public string characterDisplayName;
    public string characterKey;
    public Color textColor;
    public Color headerColor;
    public Animator animator;
    public string defaultImage = "default";

    [Space(10)]
    [Header("Debug Mode")]
    [SerializeField] private Image portraitCurrent;
    [SerializeField] private Image portraitNew;
    [SerializeField] private static float animationSpeed = 0.1f;
    [SerializeField] private bool isAnimating = false;
    [SerializeField] private bool isSkipping = false;
    [SerializeField] public bool isFadedOut = true;


    [SerializeField] private List<Image> _images = new List<Image>();

    private int animationCount = 0;

    public UnityEvent onAnimationsEnded;

    // Start is called before the first frame update
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            var img = child.GetComponent<Image>();
            if (img)
            {
                _images.Add(img);
                if (img.name == defaultImage)
                {
                    portraitCurrent = img;
                    portraitNew = img;
                }
                else
                {
                    img.enabled = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator DisableOldPortrait(float delay)
    {
        yield return new WaitForSeconds(delay);
        if(isAnimating)
        {
            Debug.Log("is animating " + portraitCurrent.name + " " + portraitNew.name);
            portraitCurrent.enabled = false;
            portraitCurrent = portraitNew;
            isAnimating = false;
        }
    }

    public void setPortrait(string name)
    {
        if (name != portraitCurrent.name)
        {
            foreach (Image img in _images)
            {
                if (img.name == name)
                {
                    //TODO: Change to a shader solution for crossfading, which should be more reliable when 

                    if(isAnimating)
                    {
                        portraitCurrent.enabled = false;
                        portraitCurrent = portraitNew;
                        isAnimating = false;
                    }
                    else
                    {
                        isAnimating = true;
                    }

                    portraitCurrent.CrossFadeAlpha(0f, isSkipping ? 0f : animationSpeed, false);
                    StartCoroutine(DisableOldPortrait(isSkipping ? 0f : animationSpeed));
                    img.enabled = true;
                    portraitNew = img;
                    portraitNew.CrossFadeAlpha(1f, isSkipping ? 0f : animationSpeed, false);
                    
                }
                else
                {
                    //img.enabled = false;
                }
            }
        }
    }

    public void Play(string anim, bool isSkipping = false)
    {
        this.isSkipping = isSkipping;
        if (isSkipping)
        {
            animator.Play(anim, -1, 1f);
        }
        else
        {
            animator.Play(anim);
        }
        animationCount = 1;
    }

    public void OnAnimationEnded()
    {
        animationCount--;
        if(animationCount <= 0)
        {
            onAnimationsEnded.Invoke();
            animationCount = 0;
            isSkipping = false;
        }
    }
}
