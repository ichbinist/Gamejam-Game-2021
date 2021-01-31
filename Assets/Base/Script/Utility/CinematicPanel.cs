using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CinematicPanel : MonoBehaviour
{
    private Sequence Sequence = DOTween.Sequence();

    public Image image;
    private void OnEnable()
    {
      if(!Managers.Instance) return;
        CinematicManager.Instance.OnCinematicStarted.AddListener(CinematicAnimation);
    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;
        CinematicManager.Instance.OnCinematicStarted.RemoveListener(CinematicAnimation);
    }

    private void CinematicAnimation(InteractableBase interactableBase)
    {
        Sequence.Append(image.DOFade(1f, 0.3f).OnStart(()=> CharacterManager.Instance.GetPlayer.IsControlable = false));
        Sequence.Append(image.DOFade(0f, 0.3f).OnComplete(() => { CharacterManager.Instance.GetPlayer.IsControlable = true; CinematicManager.Instance.OnCinematicFinished.Invoke(interactableBase); }));
    }
}
