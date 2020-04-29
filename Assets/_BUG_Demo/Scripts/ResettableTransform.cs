using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResettableTransform : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void ResetTransform()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
