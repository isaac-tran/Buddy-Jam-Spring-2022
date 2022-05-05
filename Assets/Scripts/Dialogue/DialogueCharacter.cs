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
    public SpriteInfo[] sprites;

    [System.Serializable]
    public struct SpriteInfo
    {
        [SerializeField]
        public string name;

        [SerializeField]
        public MonoBehaviour sprite;
    }

    private int animationCount = 0;

    public UnityEvent onAnimationsEnded;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPortrait(string name)
    {
        foreach (SpriteInfo s in sprites)
        {
            if (s.name == name)
            {
                s.sprite.enabled = true;
            }
            else
            {
                s.sprite.enabled = false;
            }
        }
        
    }

    public void Play(string anim)
    {
        animator.Play(anim);
        animationCount = 1;
    }

    public void OnAnimationEnded()
    {
        animationCount--;
        if(animationCount <= 0)
        {
            onAnimationsEnded.Invoke();
        }
    }
}
