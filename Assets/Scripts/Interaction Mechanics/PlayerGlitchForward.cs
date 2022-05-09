using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlitchForward : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float glitchDistance = 3;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position + transform.TransformDirection(Vector3.forward * glitchDistance);
    }
}
