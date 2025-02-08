using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float fireSpeed = 10f;
    [SerializeField] bool moveBullet;

    private void OnEnable()
    {
        moveBullet = true;
        Invoke("DisableGameObject", 3f);   
    }

    private void OnDisable()
    {
        moveBullet = false;
    }

    private void DisableGameObject()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(moveBullet)
            transform.position += transform.up * fireSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Helicopter"))
        {
            Debug.Log("Helicopter Collid");
            DisableGameObject();
            GameManager.instance.AddScore(5);

        }

        if(collision.gameObject.CompareTag("paratrooper"))
        {
            GameManager.instance.AddScore(2);
            Debug.Log("paratrooper Collid");
            collision.gameObject.SetActive(false);

        }
    }
}
