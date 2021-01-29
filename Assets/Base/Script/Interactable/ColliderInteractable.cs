using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInteractable : InteractableBase
{
    private ScaleAnimation scaleAnimation;
    public ScaleAnimation ScaleAnimation { get { return (scaleAnimation == null) ? scaleAnimation = GetComponentInChildren<ScaleAnimation>() : scaleAnimation; } }
    public override void Escape()
    {
        ScaleAnimation.Close();
    }

    public override void Interact()
    {
        ScaleAnimation.Open();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Character>() != null)
        {
            Interact();
        }       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            Interact();
        }
    }
}
