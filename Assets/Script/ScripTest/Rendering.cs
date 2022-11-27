using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rendering : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FiexdUpdate()
    {
        
    }
    public void flipX(SpriteRenderer SR, float h)
    {
        if (Input.GetButton("Horizontal"))
        {
            if (h == 1)
            {
                SR.flipX = false;
            }
            else if (h == -1)
            {
                SR.flipX = true;
            }
        }
    }
}