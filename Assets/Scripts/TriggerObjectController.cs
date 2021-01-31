using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectController : MonoBehaviour
{
    public GameObject Woman;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character>() == null)
            return;
        Woman.SetActive(true);
        Destroy(gameObject);
    }
}
