using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    [SerializeField] float rotatingSpeed;
    [SerializeField] Transform bulletPos;
    [SerializeField] objectPool objectPools;
    [SerializeField] float movSpeed = 4f;

    private float spawnRate = 3f;
    private float timer;

    void Update()
    {
        TurretRotation();
        TurretShoot();

        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnHelicopter();
            timer = 0f;
            spawnRate = Random.Range(2, 4);
        }
    }

    void TurretRotation()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        float newRotation = transform.eulerAngles.z - rotationInput * rotatingSpeed * Time.deltaTime;

        if (newRotation > 180) newRotation -= 360;
        newRotation = Mathf.Clamp(newRotation, -70f, 70f);

        transform.eulerAngles = new Vector3(0, 0, newRotation);
    }

    void TurretShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = objectPools.GetBullet();
            if(bullet != null)
            {
                Debug.Log("Bullet Not Null");
                bullet.transform.position = bulletPos.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
            }
            else
            {
                Debug.Log("Bullet is Null");
            }
        }
    }

    public void SpawnHelicopter()
    {
        GameObject helipad = objectPools.GetHelicopter();
        Helicopter hs = helipad.GetComponent<Helicopter>();

        hs.paratrooper = objectPools.GetParatrooper();


        if (helipad != null)
        {
            float spawnX = (Random.value > 0.5f) ? -10f : 10f;

            if (spawnX == 10)
            {
                helipad.transform.position = new Vector3(spawnX, 3f, 0);  // Spawn Left to Right
            }
            else
            {
                helipad.transform.position = new Vector3(spawnX, 4.3f, 0);  // Spawn Right to Left
            }
            helipad.SetActive(true);
        }
        else
        {
            Debug.Log("Helicopter is Null");
        }
    }
}
