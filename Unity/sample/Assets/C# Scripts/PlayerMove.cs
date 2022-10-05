using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //public float maxSpeed;
    public float jumppower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animation;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animation = GetComponent<Animator>();
    }

    void Update()
    {
        //점프 
        if (Input.GetButtonDown("Jump") && !animation.GetBool("Jump")) {
            rigid.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
            animation.SetBool("Jump", true);
        }

        //방향 전환
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            spriteRenderer.flipX = true;

        //걷는 모션 출력
     //   if (Mathf.Abs(rigid.velocity.x) < 1.5)
     //       animation.SetBool("Walk", false);
     //   else
     //       animation.SetBool("Walk", true);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            animation.SetBool("Walk", true);
        else
            animation.SetBool("Walk", false);
    }

    // Update is called once per frame
    void FixedUpdate() //1초에 50번이랬나?
    {
        //   float h = Input.GetAxisRaw("Horizontal");

        //   rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //   if (rigid.velocity.x > maxSpeed) // 현재 속도가 너무 빠르면
        //       rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y); //점프에 영향을 주지 않음
        //   else if (rigid.velocity.x < maxSpeed*(-1)) //역 방향 가속 제한
        //       rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);

        //착지
        if(rigid.velocity.y < 0) {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 1f)
                    animation.SetBool("Jump", false);
                //               Debug.Log(rayHit.collider.name);
            }
        }
    }
}
