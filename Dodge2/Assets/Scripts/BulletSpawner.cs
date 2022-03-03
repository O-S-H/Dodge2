using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f; // �ּ� �����ֱ�
    public float spawnrateMax = 3f; // �ִ� �����ֱ�

    private Transform target; // Ÿ��
    private float spawnRate; //�����ֱ�
    private float timeAfterSpawn; //�ֱٻ����������� ���� �ð�
    void Start()
    {
        timeAfterSpawn = 0f; // �ֱ� ���������� 0���� �ʱ�ȭ
        spawnRate = Random.Range(spawnRateMin, spawnrateMax); // �����ֱ⸦ 0.5~3�ʻ��̿� �������� ����
        target = FindObjectOfType<PlayerCotroller>().transform; // Ÿ���� �÷�����Ʈ�ѷ� ��ũ��Ʈ���� ã�� �����Ѵ�.
    }

   
    void Update()
    {
        timeAfterSpawn += Time.deltaTime; //�����ð��� �����ֱ�� ���� ����

        if (timeAfterSpawn >= spawnRate)  // ������ ź�˻��� �����ð��� �����ֱ⺸�� ũ�ų� ���ٸ�
        {
            timeAfterSpawn = 0f;

            GameObject bullet =
                Instantiate(bulletPrefab, transform.position, transform.rotation);

            bullet.transform.LookAt(target);
        }
    }
}
