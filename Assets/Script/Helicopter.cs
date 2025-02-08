using System.Collections;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public float speed = 4f;
    public GameObject paratrooper;
    private int direction;

    void OnEnable()
    {
        SetDirection();
        StartCoroutine(ParatrooperCheck());
    }
    void Update()
    {
        MoveHelicopter();
    }

    void SetDirection()
    {
        if (transform.position.x < 0)
        {
            direction = 1;
            this.GetComponent<SpriteRenderer>().flipX = false;
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else
        {
            direction = -1;
            this.GetComponent<SpriteRenderer>().flipX = true;
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
    }

    void MoveHelicopter()
    {
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);

        if (Mathf.Abs(transform.position.x) > 10f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator ParatrooperCheck()
    {
        while (paratrooper == null)
            yield return null;

        float randomDropTime = Random.Range(1f, 5f);
        yield return new WaitForSeconds(randomDropTime);
        ActivateParatrooper();
    }

    void ActivateParatrooper()
    {
        if(paratrooper != null)
        {
            paratrooper.transform.position = transform.position;
            paratrooper.SetActive(true);
            paratrooper = null;
        }
        
        
    }
}
