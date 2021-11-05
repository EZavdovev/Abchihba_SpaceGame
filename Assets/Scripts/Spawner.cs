using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static event Action OnChangeHard = delegate { };

    public static int lvlHard { get; private set;}
    [SerializeField]
    private List<Transform> spawnerPoint;

    [SerializeField]
    private List<GameObject> spawnObjects;

    [SerializeField]
    private int countSpawn;

    [SerializeField]
    private float timer;

    [SerializeField]
    private float timerToHard;

    private float currentTimerToHard;

    private int currentCount;
    private void Start()
    {
        currentTimerToHard = 0;
        lvlHard = 0;
        StartCoroutine(SpawnObj());
    }

    void Repeat()
    {
        StartCoroutine(SpawnObj());
    }

    IEnumerator SpawnObj()
    {
        yield return new WaitForSeconds(timer);
        currentTimerToHard += timer;
        if (currentTimerToHard >= timerToHard)
        {
            OnChangeHard();
            timer -= 0.5f;
            if(timer <= 0)
            {
                timer = 0.5f;
            }
            countSpawn += 2;
            currentTimerToHard = 0;
            lvlHard++;
        }
        currentCount = 0;
        while(currentCount < countSpawn)
        {
            currentCount++;
            int point = UnityEngine.Random.Range(0, spawnerPoint.Count);
            Transform pos = spawnerPoint[point];
            if (point == 0)
            {
                pos.position += new Vector3(UnityEngine.Random.Range(-20, 20), 0, 0);
            }
            else
            {
                pos.position += new Vector3(0, UnityEngine.Random.Range(-5, 5), 0);
            }
            GameObject enemy = PoolManager.getGameObjectFromPool(spawnObjects[UnityEngine.Random.Range(0, spawnObjects.Count)], pos);
            float angle = UnityEngine.Random.Range(-30, 30);
            angle *= Mathf.PI;
            angle /= 180;
            enemy.GetComponent<AsteroidMove>().ChangeDirection(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)));
            yield return new WaitForSeconds(0.1f);
        }
        Repeat();
    }
}
