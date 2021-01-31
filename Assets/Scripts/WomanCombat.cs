using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WomanCombat : MonoBehaviour
{
    public void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character>() == null)
            return;

        CharacterManager.Instance.GetPlayer.Health--;

        if (CharacterManager.Instance.GetPlayer.Health <= 0)
            CombatManager.Instance.OnDeath.Invoke();

        Destroy(gameObject);
    }
}
