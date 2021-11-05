using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float speed;

    private Vector3 changePos = Vector3.zero;

    private void FixedUpdate()
    {
        Move();
    }
    public void ChangePos(Vector3 pos)
    {
        changePos = pos;
    }
    private void Move()
    {
        float xMove = changePos.x;
        float yMove = changePos.y;
        if(xMove == 0 && yMove == 0)
        {
            return;
        }
        float rotate = (Mathf.Acos((xMove) / Mathf.Sqrt(xMove * xMove + yMove * yMove)) * 180 / Mathf.PI);
        firePoint.rotation = Quaternion.Euler(0, 0, yMove > 0 ? rotate : -rotate);
        playerPos.Translate(new Vector3(xMove * Time.deltaTime * speed, yMove * Time.deltaTime * speed));
    }

    
}
