using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CinematicPanel : MonoBehaviour
{
    private Character player;
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
        Sequence Sequence = DOTween.Sequence();
        player = CharacterManager.Instance.GetPlayer;
        Sequence.Append(image.DOFade(1f, 1f).OnComplete(() => { CinematicManager.Instance.OnCinematicFinished.Invoke(interactableBase); }));
        Sequence.Append(image.DOFade(0f, 1f));
        Sequence.Play();
    }
}
