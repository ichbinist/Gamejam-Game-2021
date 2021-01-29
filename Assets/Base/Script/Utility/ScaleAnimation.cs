using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ScaleAnimation : MonoBehaviour
{
    [Range(0f,10f)]
    public float Duration;

    public void Open()
    {
        transform.DOScale(Vector3.one, Duration);
    }

    public void Close()
    {
        transform.DOScale(Vector3.zero, Duration);
    }
}
