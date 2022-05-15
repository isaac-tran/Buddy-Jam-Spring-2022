using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glyph : Interactable
{

    private Animator animator;
    public bool isActive { get; private set; } = false;
    public Texture2D mask;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(texture)
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


    // Update is called once per frame
    void Update()
    {
        
    }
}
