using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    public static Action OnPlayerTouched;
    public static Action OnBulletDodged;

    public float bulletSpeed = 3f;
    public int directionSwitch;
    private Vector3 _direction;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed += Achievements.bulletCreated / 100f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (directionSwitch)
        {
            case 0:
                transform.position += Vector3.right * bulletSpeed * Time.deltaTime;
                if (transform.position.x >= 12f)
                {
                    OnBulletDodged?.Invoke();
                    Score.ScoreImprove();
                    Destroy(gameObject);
                }
                break;
            case 1:
                transform.position += Vector3.left * bulletSpeed * Time.deltaTime;
                if (transform.position.x <= -12f)
                {
                    OnBulletDodged?.Invoke();
                    Score.ScoreImprove();
                    Destroy(gameObject);
                }
                break;
            case 2:
                transform.position += Vector3.forward * bulletSpeed * Time.deltaTime;
                if (transform.position.z >= 12f)
                {
                    OnBulletDodged?.Invoke();
                    Score.ScoreImprove();
                    Destroy(gameObject);
                }
                break;
            case 3:
                transform.position += Vector3.back * bulletSpeed * Time.deltaTime;
                if (transform.position.x <= -12f)
                {
                    OnBulletDodged?.Invoke();
                    Score.ScoreImprove();
                    Destroy(gameObject);
                }
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Score.ScoreDecrease();
        OnPlayerTouched?.Invoke();
    }
}
