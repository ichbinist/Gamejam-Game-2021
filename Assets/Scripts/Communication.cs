using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Communication : MonoBehaviour
{
    public CommunicationType communicationType;
    public List<QAData> InsightData;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Character>() != null)
        {
            ChatManager.Instance.onStartCommunication.Invoke(communicationType, InsightData);
        }
        Destroy(gameObject);
    }   
}
