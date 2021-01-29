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
        DOTween.Kill(gameObject.GetInstanceID());
        transform.DOScale(Vector3.one, Duration).SetId(gameObject.GetInstanceID());
    }

    public void Close()
    {
        DOTween.Kill(gameObject.GetInstanceID());
        transform.DOScale(Vector3.zero, Duration).SetId(gameObject.GetInstanceID());
    }
}
