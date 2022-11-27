using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid;
    public float Speed; // 이동 속도
    public float MaxSpeed; // 최고 속도
    public float JumpPower; // 점프력
    SpriteRenderer SR;
    Animator anim;
    float h; //Horizontal 방향
    bool bottomjump; // 하단점프
    int jumpcnt = 0; // 점프 카운트
    int playerlayer, PDL, floorlayer; // 점프 시 바닥 뚫기 레이어
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        playerlayer = LayerMask.NameToLayer("Player");
        floorlayer = LayerMask.NameToLayer("normalfloor");
        anim = GetComponent<Animator>();
        anim.SetBool("jumping", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z)){
        }
        //오른쪽 이동
        if(Input.GetKey(KeyCode.RightArrow)){
            Moving PlayerRightMove = new Moving();
            PlayerRightMove.RightMove(rigid, Speed, MaxSpeed);
        }
        //왼쪽 이동
        if(Input.GetKey(KeyCode.LeftArrow)){
            Moving PlayerRightMove = new Moving();
            PlayerRightMove.LeftMove(rigid, Speed, MaxSpeed);
        }
        //이동 정지
        h = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonUp("Horizontal")||h==0)
        {
            Moving PlayerStop = new Moving();
            PlayerStop.Stop(rigid);
        }
        //플립
        Rendering flip = new Rendering();
        flip.flipX(SR, h);

        //이동 애니메이션
        if ((h == 0))
        {
            anim.SetBool("running", false);
        }
        else
        {
            anim.SetBool("running", true);
        }

        //이동 애니메이션 해제
        if (Mathf.Abs(rigid.velocity.x) < 0.3)
        {
            anim.SetBool("running", false);
        }
        else
        {
            anim.SetBool("running", true);
        }

        //하단 점프
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetButtonDown("Jump"))
        {
            Physics2D.IgnoreLayerCollision(playerlayer, floorlayer, true);
            Physics2D.IgnoreLayerCollision(PDL, floorlayer, true);
            Debug.Log("하단점프");
            bottomjump = true;
            jumpcnt += 1;
        }

        //바닥 감지
        if (bottomjump && !anim.GetBool("jumping"))
        {
            Debug.DrawRay(rigid.position, Vector2.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector2.down, 1, LayerMask.GetMask("normalfloor"));
            if (rayHit.collider == null)
            {
                anim.SetBool("jumping", true);
                Debug.Log(anim.GetBool("jumping"));
                bottomjump = false;
            }
        }

        //점프
        if (!Input.GetKey(KeyCode.DownArrow) && Input.GetButtonDown("Jump") && jumpcnt < 2)
        {

            rigid.velocity = Vector2.up * JumpPower;
            Physics2D.IgnoreLayerCollision(playerlayer, floorlayer, true);
            Physics2D.IgnoreLayerCollision(PDL, floorlayer, true);
            Debug.Log("점프"); // 점프 시 충돌 무시
            anim.SetBool("jumping", true);
            Debug.Log(anim.GetBool("jumping"));
            jumpcnt += 1;
            Debug.Log(jumpcnt);
        }

        //랜딩
        if (rigid.velocity.y < 0 && anim.GetBool("jumping"))
        {
            Debug.DrawRay(rigid.position + Vector2.down * 0.51f, Vector2.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position + Vector2.down * 0.51f, Vector2.down, 1, LayerMask.GetMask("normalfloor", "blockedfloor"));
            Debug.DrawRay(rigid.position + new Vector2(0.3f,-0.51f), Vector2.down, new Color(0, 1, 0));
            RaycastHit2D rayHit3 = Physics2D.Raycast(rigid.position + new Vector2(0.3f,-0.51f), Vector2.down, 1, LayerMask.GetMask("normalfloor", "blockedfloor"));
            Debug.DrawRay(rigid.position + new Vector2(-0.3f,-0.51f), Vector2.down, new Color(0, 1, 0));
            RaycastHit2D rayHit4 = Physics2D.Raycast(rigid.position + new Vector2(-0.3f,-0.51f), Vector2.down, 1, LayerMask.GetMask("normalfloor", "blockedfloor"));
            Debug.DrawRay(rigid.position, Vector2.up, new Color(1, 0, 0));
            RaycastHit2D rayHit2 = Physics2D.Raycast(rigid.position, Vector2.up, 1, LayerMask.GetMask("normalfloor", "blockedfloor"));
            //Debug.Log(rayHit2.collider.name);
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.3f && rayHit3.distance < 0.3f && rayHit4.distance <0.3f && rayHit2.collider == null)
                {
                    //Debug.Log(rayHit.collider.name);
                    anim.SetBool("jumping", false);
                    //Debug.Log(anim.GetBool("jumping"));
                    Debug.Log("착지");
                    Physics2D.IgnoreLayerCollision(playerlayer, floorlayer, false);
                    Physics2D.IgnoreLayerCollision(PDL, floorlayer, false);
                    jumpcnt = 0;
                    Debug.Log(jumpcnt);
                }
            }
        }

        
    }
    void FiexdUpdate()
    {
        
    }
    
}
