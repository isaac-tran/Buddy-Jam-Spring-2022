using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdoorToAnaChamber : MonoBehaviour
{
    [SerializeField] private float rotateDuration = 3f;

    public IEnumerator Rotate()
    {
        Quaternion currentRotation = transform.rotation;
        float timer = 0f;
        for (timer = 0f; timer <= rotateDuration; timer += Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(currentRotation, Quaternion.Euler(0, 90, 0), timer / rotateDuration);
            yield return null;
        }

        yield return null;
    }
}
