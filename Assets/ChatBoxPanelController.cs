using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ChatBoxPanelController : MonoBehaviour
{
    public Transform chatBox;
    private TextMeshProUGUI chatBoxText;
    public TextMeshProUGUI ChatBoxText { get { return (chatBoxText == null) ? chatBoxText = GameObject.FindGameObjectWithTag("chatBox").GetComponentInChildren<TextMeshProUGUI>() : chatBoxText; } }
    public Button select1;
    public Button select2;
    public Button select3;

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

    private void onStartCommunicationListener(CommunicationType type)
    {
        if (!(type == CommunicationType.NPC)) return;
        chatBox.DOMoveY(chatBox.position.y + 240f, 0.2f);
        ChatBoxText.text = "Lahmacun sever misin?";
        select1.GetComponentInChildren<TextMeshProUGUI>().text = "Evet, severim";
        select2.GetComponentInChildren<TextMeshProUGUI>().text = "Hayır, severim";
        select3.GetComponentInChildren<TextMeshProUGUI>().text = "Sanane, severim";
    }
}
