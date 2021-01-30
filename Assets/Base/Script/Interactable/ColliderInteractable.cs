using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInteractable : InteractableBase
{
    private ScaleAnimation scaleAnimation;
    public ScaleAnimation ScaleAnimation { get { return (scaleAnimation == null) ? scaleAnimation = GetComponentInChildren<ScaleAnimation>() : scaleAnimation; } }

    public override void Escape()
    {
        base.Escape();
        ScaleAnimation.Close();
    }

    public override void Interact()
    {
        base.Interact();
        ScaleAnimation.Open();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Character>())
        {
            Interact();
        }       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Character>())
        {
            Escape();
        }
    }

    public override void Do()
    {
        base.Do();
        if (IsOneTimeInteractable)
            GetComponent<Collider2D>().enabled = false;
    }
}
