using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Button button;
    public Button Button { get { return (button == null) ? button = GetComponent<Button>() : button; } }

    public UnityEvent OnClicked = new UnityEvent();

    private void OnEnable()
    {
      if(!Managers.Instance) return;
        Button.onClick.AddListener(OnClicked.Invoke);
    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;
        Button.onClick.RemoveListener(OnClicked.Invoke);
    }
}
