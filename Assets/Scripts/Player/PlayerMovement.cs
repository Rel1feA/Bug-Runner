using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float jumpBuffer;
    [SerializeField]
    private float normalGravityScale;
    [SerializeField]
    private float downGravityScale;
    [SerializeField]
    private Vector2 groundBoxSize;
    [SerializeField]
    private Vector2 groundBoxOffset;
    [SerializeField]
    private bool isCheckGround;
    [SerializeField]
    private float maxDownSpeed;

    private Rigidbody2D rb2d;
    private float inputX;
    private float jumpTimer;
    private bool isPressJumpKey;
    private Animator animator;
    public string currentAnim;

    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb2d.gravityScale = normalGravityScale;
        isPressJumpKey = false;
        currentAnim = "Idle";
    }

    private void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        UpdateJumpInput();
        FilpPlayer();
        SetAnim();
    }

    private void FixedUpdate()
    {
        Move();
        ChangeGravityScale();
        if(isPressJumpKey)
        {
            if(isCheckGround)
            {
                if(CheckGround())
                {
                    Jump();
                }
            }
            else
            {
                Jump();
            }
        }
        ClampRBDownSpeed();
    }

    public void Move()
    {
        rb2d.velocity=new Vector2(inputX*moveSpeed,rb2d.velocity.y);
    }

    public void Jump()
    {
        isPressJumpKey = false;
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.velocity += Vector2.up * jumpSpeed;
    }

    public bool CheckGround()
    {
       return Physics2D.OverlapBox((Vector2)transform.position + groundBoxOffset, groundBoxSize, 0, LayerMask.GetMask("Ground","FakeBullet"));
    }

    public void ChangeGravityScale()
    {
        if(rb2d.velocity.y>=0)
        {
            rb2d.gravityScale = normalGravityScale;
        }
        else
        {
            rb2d.gravityScale = downGravityScale;
        }
    }

    public void UpdateJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPressJumpKey = true;
            jumpTimer = 0;
        }
        if (isPressJumpKey && !CheckGround())
        {
            jumpTimer += Time.deltaTime;
        }
        if (jumpTimer >= jumpBuffer)
        {
            jumpTimer = 0;
            isPressJumpKey = false;
        }
    }

    public void ClampRBDownSpeed()
    {
        if(rb2d.velocity.y<maxDownSpeed)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxDownSpeed);
        }
    }

    public void FilpPlayer()
    {
        if(inputX>0)
        {
            transform.localScale = Vector3.one;
        }
        else if(inputX<0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
    }

    public void SetAnim()
    {
        if(CheckGround())
        {
            if(currentAnim=="Down")
            {
                ChangeAnim("OtherLayer.ToGround");
            }
            else if (rb2d.velocity == Vector2.zero && inputX == 0)
            {
                ChangeAnim("Idle");
            }
            else if (rb2d.velocity.y == 0)
            {
                ChangeAnim("Run");
            }
        }
        else
        {
            if(rb2d.velocity.y>0)
            {
                ChangeAnim("Jump");
            }
            else
            {
                ChangeAnim("Down");
            }
        }
    }

    public void ChangeAnim(string animName,float crossFade=0)
    {
        if(animName!=currentAnim)
        {
            currentAnim = animName;
            animator.CrossFade(animName, crossFade);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube((Vector2)transform.position + groundBoxOffset, groundBoxSize);
    }
}
