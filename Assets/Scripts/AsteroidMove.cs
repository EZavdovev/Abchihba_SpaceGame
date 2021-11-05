using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    [SerializeField]
    private Vector2 direction;
    [SerializeField]
    private float speed;

    private float currentSpeed;

    private void OnEnable()
    {
        currentSpeed = speed + Spawner.lvlHard;
    }
    public void ChangeDirection(Vector2 dir)
    {
        direction = dir;
    }

    void Update()
    {
        gameObject.transform.Translate(direction * currentSpeed * Time.deltaTime);
    }
}
