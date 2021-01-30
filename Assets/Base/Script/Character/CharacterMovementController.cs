using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    private Character character;
    public Character Character { get { return (character == null) ? character = GetComponent<Character>() : character; } }

    private Rigidbody2D _rigidbody2D;
    public Rigidbody2D Rigidbody2D { get { return (_rigidbody2D == null) ? _rigidbody2D = GetComponent<Rigidbody2D>() : _rigidbody2D; } }
    private bool isLeftKeyPressed, isRightKeyPressed;
    private void OnEnable()
    {
      if(!Managers.Instance) return;

    }

    private void OnDisable()
    {
      if(!Managers.Instance) return;

    }

    private void Update()
    {
        if (!Character.IsControlable)
        {
            Rigidbody2D.velocity = Vector2.zero;
            return;
        }

        if (Input.GetKey("a"))
        {
            Rigidbody2D.velocity = (Vector2.left * Character.Speed);
        }
        else if (Input.GetKey("d"))
        {
            Rigidbody2D.velocity = (Vector2.right * Character.Speed);
        }
        else
        {
            Rigidbody2D.velocity = Vector2.zero;
        }

        if (Rigidbody2D.velocity.x < 0)
        {
            Character.Graphics.transform.localScale = Vector3.one + Vector3.left * 2;
        }
        else
        {
            Character.Graphics.transform.localScale = Vector3.one;
        }
    }
}
