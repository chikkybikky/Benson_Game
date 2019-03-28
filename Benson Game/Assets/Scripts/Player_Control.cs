using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    Vector3 pos;
    public int[] startpos;
    public Animator ani;
    int direction;
    bool walking;
    bool stillwalking;
    RaycastHit2D interact;
    float speed = 2.0f;
    void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = startpos[1];
        pos.x = startpos[0];
        pos.y = startpos[1];
        transform.position = pos;
    }
    private void FixedUpdate()
    {
        if (transform.position == pos)
        {
            if (Input.GetKey(KeyCode.E))
            {
                switch (direction)
                {
                    default:
                    case 0:
                        interact = Physics2D.Raycast(transform.position, Vector2.down, 1);
                        break;
                    case 1:
                        interact = Physics2D.Raycast(transform.position, Vector2.right, 1);
                        break;
                    case 2:
                        interact = Physics2D.Raycast(transform.position, Vector2.up, 1);
                        break;
                    case 3:
                        interact = Physics2D.Raycast(transform.position, Vector2.left, 1);
                        break;
                }
                if (interact.collider != null)
                {
                    Debug.Log("Hit a " + interact.transform.tag);//this doesn't work
                }
            }
            else
            {
                float y = transform.position.y;
                GetComponent<SpriteRenderer>().sortingOrder = (int)y * -1;
                walking = false;
                if (Input.GetKey(KeyCode.A))
                {
                    interact = Physics2D.Raycast(transform.position, Vector2.left, 1);
                    if (!interact)
                    {
                        pos += Vector3.left;
                        direction = 3;
                        walking = true;
                    }
                }
                if (Input.GetKey(KeyCode.D))
                {
                    interact = Physics2D.Raycast(transform.position, Vector2.right, 1);
                    if (!interact)
                    {
                        pos += Vector3.right;
                        direction = 1;
                        walking = true;
                    }
                }
                if (Input.GetKey(KeyCode.W))
                {
                    interact = Physics2D.Raycast(transform.position, Vector2.up, 1);
                    if (!interact)
                    {
                        pos += Vector3.up;
                        direction = 2;
                        walking = true;
                    }
                }
                if (Input.GetKey(KeyCode.S))
                {
                    interact = Physics2D.Raycast(transform.position, Vector2.down, 1);
                    if (!interact)
                    {
                        pos += Vector3.down;
                        direction = 0;
                        walking = true;
                    }
                    else
                    {
                        Debug.Log(interact.transform.tag);
                    }
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        }
        ani.SetInteger("direction", direction);
        ani.SetBool("walking", walking);
    }
}