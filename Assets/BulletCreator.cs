using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletCreator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public static Action OnBulletCreated;

    private float _lastBulletCreatedTime = 2f;
    private float _timeBuffer;
    public float timeBuffer
    {
        get => _timeBuffer;
        set
        {
            _timeBuffer = value;
            if (_timeBuffer < 0.1f) _timeBuffer = 0.1f;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_lastBulletCreatedTime + timeBuffer <= Time.time)
        {
            Vector3 initialPosition = Vector3.zero;
            int switchDirection = Random.Range(0,4);
            switch (switchDirection)
            {
                case 0:
                    initialPosition = new Vector3(-12f, 0.5f, Random.Range(-10f, 10f));
                    break;
                case 1:
                    initialPosition = new Vector3(12f, 0.5f, Random.Range(-10f, 10f));
                    break;
                case 2:
                    initialPosition = new Vector3(Random.Range(-10f, 10f), 0.5f, -12f);
                    break;
                case 3:
                    initialPosition = new Vector3(Random.Range(-10f, 10f), 0.5f, 12f);
                    break;
            }
            
            GameObject newBullet = Instantiate(bulletPrefab, initialPosition, Quaternion.identity);
            newBullet.GetComponent<Bullet>().directionSwitch = switchDirection;
            _lastBulletCreatedTime = Time.time;
            timeBuffer -= 0.01f;
        }
    }
}
