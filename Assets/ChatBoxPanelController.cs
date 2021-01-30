using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ChatBoxPanelController : MonoBehaviour
{
    public Transform chatBox;
    private TextMeshProUGUI chatBoxText;
    public TextMeshProUGUI ChatBoxText { get { return (chatBoxText == null) ? chatBoxText = GameObject.FindGameObjectWithTag("chatBox").GetComponentInChildren<TextMeshProUGUI>() : chatBoxText; } }

    private void OnEnable()
    {
        if (!Managers.Instance) return;
        ChatManager.Instance.onStartCommunication.AddListener(onStartCommunicationListener);
    }

    private void OnDisable()
    {
        if (!Managers.Instance) return;
        ChatManager.Instance.onStartCommunication.AddListener(onStartCommunicationListener);
    }

    private void onStartCommunicationListener()
    {
        chatBox.DOMoveY(chatBox.position.y + 80f, 0.2f);
        chatBoxText.text = "Lahmacun sever misin?";
    } 
}
