using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    public bl_Joystick joystickMoveDir;
    public bl_Joystick joystickAttackDir;

    public GameObject attackPosition;

    public bool b_canMove;
    public bool b_canAim;
    public float speed = 4f;
    [Tooltip("Smaller values = further away from player;/nHigher values = closer to player")]
    [Range(1f, 5f)]
    public float distanceFactor = 2.5f;

    private float radius = 5f;
    
    private Rigidbody2D rb2d;
    public Vector3 offset= new Vector3(0, -0.1f, 0);

    void Start()
    {
        b_canMove = true;
        b_canAim = true;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (b_canMove)
        {
            Vector2 dir = GetMoveDir();
            rb2d.velocity = dir * speed;
        }
        if(b_canAim)
        {
            //direction and position
            Vector2 dir = GetAttackDir() * radius;
            Vector3 attackPos = new Vector3(dir.x, dir.y, 0f);
            attackPosition.transform.position = attackPos / distanceFactor + transform.position + offset;
            float angle = -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            attackPosition.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            //activate sprite renderer if player is attacking
            if (GetAttackDir().sqrMagnitude >= .95f)
            {
                attackPosition.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                attackPosition.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    private Vector2 GetMoveDir()
    {
        float x = joystickMoveDir.Horizontal;
        float y = joystickMoveDir.Vertical;

        return new Vector2(x, y);
    }

    private Vector2 GetAttackDir()
    {
        float x = joystickAttackDir.Horizontal;
        float y = joystickAttackDir.Vertical;
        return new Vector2(x, y).normalized;
    }
}
