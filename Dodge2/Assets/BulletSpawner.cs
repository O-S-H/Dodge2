using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f; // 최소 생성주기
    public float spawnrateMax = 3f; // 최대 생성주기

    private Transform target; // 타겟
    private float spawnRate; //생성주기
    private float timeAfterSpawn; //최근생성시점에서 지난 시간
    void Start()
    {
        timeAfterSpawn = 0f; // 최근 생성시점을 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnrateMax); // 생성주기를 0.5~3초사이에 랜덤으로 생성
        target = FindObjectOfType<PlayerCotroller>().transform; // 타겟을 플레이컨트롤러 스크립트에서 찾아 조준한다.
    }

   
    void Update()
    {
        timeAfterSpawn += Time.deltaTime; //누적시간을 일정주기로 더해 갱신

        if (timeAfterSpawn >= spawnRate)  // 마지막 탄알생성 누적시간이 생성주기보다 크거나 같다면
        {
            timeAfterSpawn = 0f;

            GameObject bullet =
                Instantiate(bulletPrefab, transform.position, transform.rotation);

            bullet.transform.LookAt(target);
        }
    }
}
