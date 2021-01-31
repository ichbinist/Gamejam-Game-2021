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

    private List<QAData> qAData;

    public GameObject ButtonPrefab;
    public Transform ButtonHolder;

    public int ConversationIndex;
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

    private void onStartCommunicationListener(CommunicationType type, List<QAData> qAData)
    {
        if (!(type == CommunicationType.NPC)) return;
        chatBox.DOMoveY(chatBox.position.y + 240f, 0.2f);
        ConversationIndex = 0;
        this.qAData = qAData;
        InitializeButtons(ConversationIndex);
    }

    public void InitializeButtons(int index)
    {
        ChatBoxText.text = qAData[index].Question;
        for (int i = 0; i < qAData[index].Answers.Count; i++)
        {
            GameObject temp = Instantiate(ButtonPrefab, ButtonHolder); //.GetComponentInChildren<TextMeshProUGUI>().text = qAData[index].Answers[i];
            temp.GetComponentInChildren<TextMeshProUGUI>().text = qAData[index].Answers[i];
            temp.GetComponentInChildren<ButtonController>().OnClicked.AddListener(NextConversation);
        }
    }

    public void NextConversation()
    {
        for (int i = 0; i < qAData[ConversationIndex].Answers.Count; i++)
        {
            ButtonHolder.GetChild(i).GetComponentInChildren<ButtonController>().OnClicked.RemoveListener(NextConversation);
            Destroy(ButtonHolder.GetChild(i).gameObject);
        }
        ConversationIndex++;
        if(ConversationIndex > qAData.Count-1)
        {
            chatBox.DOMoveY(chatBox.position.y - 240f, 0.2f);
            CharacterManager.Instance.GetPlayer.IsControlable = true;
        }
        else
        {
            InitializeButtons(ConversationIndex);
        }
        
    }
}