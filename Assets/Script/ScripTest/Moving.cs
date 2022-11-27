using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RightMove(Rigidbody2D rigid, float Speed, float MaxSpeed)
    {
        
        rigid.AddForce(Vector2.right * Speed, ForceMode2D.Impulse);

        //속도 제한
        if (rigid.velocity.x > MaxSpeed)
        {
            rigid.velocity = new Vector2(MaxSpeed, rigid.velocity.y);
        }
        
    }
    public void LeftMove(Rigidbody2D rigid, float Speed, float MaxSpeed)
    {
        
        rigid.AddForce(Vector2.right * Speed * (-1), ForceMode2D.Impulse);

        //속도 제한
        if (rigid.velocity.x < MaxSpeed * (-1))
        {
            rigid.velocity = new Vector2(MaxSpeed * (-1), rigid.velocity.y);
        }
        
    }

    public void Stop(Rigidbody2D rigid) 
    {
        rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.01f, rigid.velocity.y);
    }
}
