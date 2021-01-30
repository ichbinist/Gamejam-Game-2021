using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class InsightPanelController : MonoBehaviour
{
    public Transform insightBox;
    private TextMeshProUGUI insightText;
    public TextMeshProUGUI InsightText { get { return (insightText == null) ? insightText = GameObject.FindGameObjectWithTag("insightBox").GetComponentInChildren<TextMeshProUGUI>() : insightText; } }
    bool isAnimationStarted = false;

    private void OnEnable()
    {
        if (!Managers.Instance) return;
        ChatManager.Instance.onStartCommunication.AddListener(onStartCommunicationListener);
    }

    private void OnDisable()
    {
        if (!Managers.Instance) return;
        ChatManager.Instance.onStartCommunication.RemoveListener(onStartCommunicationListener);
    }

    private void onStartCommunicationListener(CommunicationType type, List<QAData> data)
    {
        if (!(type == CommunicationType.Insight)) return;
        int tweenID = gameObject.GetInstanceID();
        if (isAnimationStarted)
            return;
        insightBox.DOMoveY(insightBox.position.y + 50f, 0.2f).SetId(tweenID)
            .OnStart(() =>
        {
            if (!isAnimationStarted)
            {
                isAnimationStarted = true;
            }
        });
        InsightText.text = "Pil bulmalıyım";
        StartCoroutine(startCO());
    }

    IEnumerator startCO()
    {
        yield return new WaitForSeconds(2f);
        insightBox.DOMoveY(insightBox.position.y-50f, 0.2f).SetId(gameObject.GetInstanceID()).OnComplete(() =>
        {
            isAnimationStarted = false;
        });
    }
}
