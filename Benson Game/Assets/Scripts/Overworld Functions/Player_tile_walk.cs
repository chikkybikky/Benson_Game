using UnityEngine;

public class Player_tile_walk : MonoBehaviour
{
    public float speed = 3f;
    public LayerMask blockinglayer;
    public Animator ani;
    public Vector3 StartPos;

    public bool busy = false;
    Vector3 pos;
    int direction;
    bool walking = false;
    int newOrder;
    GameObject lookingAt;

    void Start()
    {
        float y = StartPos.y;
        int sortLayer = (int)y * -1;
        GetComponent<SpriteRenderer>().sortingOrder = sortLayer;
        transform.position = StartPos;
        pos = transform.position;
    }
    void Update()
    {
        if (!busy)
        {
            if (transform.position == pos)
            {
                walking = false;
                lookingAt = null;
                newOrder = (int)(-1 * pos.y);
                GetComponent<SpriteRenderer>().sortingOrder = newOrder;
                ani.SetBool("walking", walking);
                if (Input.GetKey(KeyCode.E))
                {
                    lookingAt = inspect(direction);
                    if (lookingAt != null)
                    {
                        if (lookingAt.transform.tag == "NPC")
                        {
                            ExternalTalk();
                        }
                        else if(lookingAt.transform.tag == "Interactable Object")
                        {
                            InternalTalk();
                        }
                    }
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    direction = 3;
                    ani.SetInteger("direction", direction);
                    lookingAt = inspect(direction);
                    if (lookingAt == null)
                    {
                        pos.x -= 1;
                        walking = true;
                    }
                    else if (lookingAt.transform.tag == "cutscene")
                    {
                        lookingAt.GetComponent<CutsceneTrigger>().StartCut();
                    }
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    direction = 2;
                    ani.SetInteger("direction", direction);
                    lookingAt = inspect(direction);
                    if (lookingAt == null)
                    {
                        pos.y += 1;
                        walking = true;
                    }
                    else if (lookingAt.transform.tag == "cutscene")
                    {
                        lookingAt.GetComponent<CutsceneTrigger>().StartCut();
                    }
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    direction = 1;
                    ani.SetInteger("direction", direction);
                    lookingAt = inspect(direction);
                    if (lookingAt == null)
                    {
                        pos.x += 1;
                        walking = true;
                    }
                    else if (lookingAt.transform.tag == "cutscene")
                    {
                        lookingAt.GetComponent<CutsceneTrigger>().StartCut();
                    }
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    direction = 0;
                    ani.SetInteger("direction", direction);
                    lookingAt = inspect(direction);
                    if (lookingAt == null)
                    {
                        pos.y -= 1;
                        walking = true;
                    }
                    else if (lookingAt.transform.tag == "cutscene")
                    {
                        lookingAt.GetComponent<CutsceneTrigger>().StartCut();
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

    GameObject inspect(int direction)
    {
        Vector2 start = transform.position;
        start.y -= .5f;
        Vector2 end = start;
        RaycastHit2D hit;
        ani.SetInteger("direction", direction);
        switch (direction)
        {
            default:
            case 0:
                end.y -= 1;
                break;
            case 1:
                end.x += 1;
                break;
            case 2:
                end.y += 1;
                break;
            case 3:
                end.x -= 1;
                break;
        }
        hit = Physics2D.Linecast(start, end, blockinglayer);
        if (hit.transform == null)
        {
            return null;
        }
        else
        {
            return hit.transform.gameObject;
        }
    }
    void InternalTalk()
    {
        busy = true;
        lookingAt.GetComponent<Monologue_Trigger>().TriggerMonologue();
    }
    void ExternalTalk()
    {
        busy = true;
        lookingAt.GetComponent<NPC_Static>().TalkToMe(direction);
    }
}
