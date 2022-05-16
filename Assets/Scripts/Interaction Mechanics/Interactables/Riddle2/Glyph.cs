using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glyph : Interactable
{
    private Animator animator;
    [SerializeField] public bool isActive { get; private set; } = false;
    public Texture2D mask;

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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(mask)
            GetComponent<MeshRenderer>().material.SetTexture("_mask", mask);
    }

    public void Activate()
    {
        if(!isActive)
        {
            isActive = true;
            animator.Play("fadeIn");
        }
    }

    public void Deactivate()
    {
        if (isActive)
        {
            isActive = false;
            animator.Play("fadeOut");
        }
    }

    public override void Interact()
    {
        Activate();
        Level1GameManager.Instance.ActivateGlyph(this);
    }
}
