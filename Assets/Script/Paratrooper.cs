using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paratrooper : MonoBehaviour
{
    public SpriteRenderer paratroopSpriteRenderer;
    public Sprite parachuteSprite;
    public Sprite paratrooperSprite;
    public float dropSpeed = 4f;
    public bool isParachuteActive;
    public bool isGrounded;


    private void Start()
    {
        paratroopSpriteRenderer.sprite = paratrooperSprite;
    }

    private void OnEnable()
    {
        isParachuteActive = false;
        isGrounded = false;
        dropSpeed = 4f;

        if (paratroopSpriteRenderer != null)
        {
            paratroopSpriteRenderer.sprite = paratrooperSprite;
        }
    }


    void Update()
    {
        if (isGrounded) return; // Stop movement when on the ground

        transform.position -= new Vector3(0, dropSpeed * Time.deltaTime, 0);

        if (!isParachuteActive && transform.position.y < 1.5f)
        {
            isParachuteActive = true;
            paratroopSpriteRenderer.sprite = parachuteSprite;
            dropSpeed /= 2f; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision detected");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("On ground");
            paratroopSpriteRenderer.sprite = paratrooperSprite;
            Invoke(nameof(DisableParatrooper), 4f);
        }

        else if (collision.gameObject.CompareTag("paratrooper") && transform.position.y < 0.5f)
        {
            isGrounded = true;
            Debug.Log("Landed on another paratrooper");
            paratroopSpriteRenderer.sprite = paratrooperSprite;
            Invoke(nameof(DisableParatrooper), 8f);
        }
        
    }

    private void DisableParatrooper()
    {
        gameObject.SetActive(false);
    }
}
