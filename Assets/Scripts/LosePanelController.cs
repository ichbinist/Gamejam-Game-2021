using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanelController : MonoBehaviour
{
    public GameObject Graphics;
    private void OnEnable()
    {
      if(!Managers.Instance) return;
        CombatManager.Instance.OnDeath.AddListener(RevealPanel);
    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;
        CombatManager.Instance.OnDeath.RemoveListener(RevealPanel);
    }

    public void RevealPanel()
    {
        Graphics.SetActive(true);
    }

}
