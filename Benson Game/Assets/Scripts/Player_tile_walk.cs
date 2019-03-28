using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_tile_walk : MonoBehaviour
{
    public float speed = 1;
    public LayerMask blockinglayer;
    public Animator ani;
    
    private Rigidbody2D rb2d;

    Vector3 pos;
    int direction;
    bool walking = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pos = transform.position;
    }
    void Update()
    {
        if(transform.position == pos){
            walking = false;
            ani.SetBool("walking", walking);
            if (Input.GetKey(KeyCode.E))
            {
                check(direction);
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction = 3;
                ani.SetInteger("direction", direction);
                if (check(direction))
                {
                    pos.x -= 1;
                    walking = true;
                }
            }
            if (Input.GetKey(KeyCode.W))
            {
                direction = 2;
                ani.SetInteger("direction", direction);
                if (check(direction))
                {
                    pos.y += 1;
                    walking = true;
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction = 1;
                ani.SetInteger("direction", direction);
                if (check(direction))
                {
                    pos.x += 1;
                    walking = true;
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction = 0;
                ani.SetInteger("direction", direction);
                if (check(direction))
                {
                    pos.y -= 1;
                    walking = true;
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
    bool check(int direction)
    {
        Vector2 start = transform.position;
        Vector2 end;
        end.x = 0;
        end.y = 0;
        RaycastHit2D hit;
        ani.SetInteger("direction", direction);
        switch (direction)
        {
            default:
            case 0:
                end.y = - 1;
                break;
            case 1:
                end.x = 1;
                break;
            case 2:
                end.y = 1;
                break;
            case 3:
                end.x = - 1;
                break;
        }
        Debug.Log("start " + start);
        Debug.Log("end " + end);
        hit = Physics2D.Linecast(start, end, blockinglayer);
        Debug.DrawRay(start, end);
        if (hit.transform == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
