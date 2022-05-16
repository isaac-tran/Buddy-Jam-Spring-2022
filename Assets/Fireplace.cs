using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    [SerializeField] private float rotateDuration = 3f;

    public IEnumerator Rotate()
    {
        float timer = 0f;
        for (timer = 0f; timer <= rotateDuration; timer += Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 45, 90), timer / rotateDuration);
            yield return null;
        }

        yield return null;
    }
}
