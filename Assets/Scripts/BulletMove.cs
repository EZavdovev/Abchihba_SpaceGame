using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    void Update()
    {
        gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime); 
    }
}
