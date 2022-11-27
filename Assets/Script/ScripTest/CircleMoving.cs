using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMoving : MonoBehaviour
{
    Rigidbody2D rigid;
    float Angle; // 회전 각
    public Transform player;
    public GameManger gameManger;
    public static float rotdir; //회전 방향
    public float Radius; // 회전 반경

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update() 
    {
        
    }
    void FixedUpdate()
    {
        
    }
    public void rot()
    {
        float PPX = player.position.x;
        float PPY = player.position.y;
        Angle += PlayerMoving.AngleSpeed * rotdir;
        transform.GetChild(0).position = new Vector3 (PPX + Radius * Mathf.Cos(Angle * Mathf.Deg2Rad),PPY + Radius * Mathf.Sin(Angle * Mathf.Deg2Rad),-1);
        transform.GetChild(1).position = new Vector3 (PPX + Radius * Mathf.Cos((Angle+180)* Mathf.Deg2Rad),PPY + Radius * Mathf.Sin((Angle+180)* Mathf.Deg2Rad),-1);
    }
    public void visible()
    {

    }
}
