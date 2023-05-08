using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public Sprite deadSprite;
    public SpriteRenderer spriteRenderer;
    public AudioSource deathAudio;

    private void Reset(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable(){
        deathAudio.Play();
        UpdateSprite();//������ �������� �� ������
        DisablePhysics();//��������� ������ ����������
        StartCoroutine(Animate());
    }

    private void UpdateSprite(){
        spriteRenderer.enabled = true;
        spriteRenderer.sortingOrder=100;
        if(deadSprite!=null){
        spriteRenderer.sprite = deadSprite;
        }
    }

    private void DisablePhysics(){
        Collider2D[] colliders = GetComponents<Collider2D>();

        foreach(Collider2D collider in colliders){
            collider.enabled = false;
        }

        GetComponent<Rigidbody2D>().isKinematic = true;

        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        EntityMovement entityMovement = GetComponent<EntityMovement>();
       
       if(playerMovement!=null){
            playerMovement.enabled=false;
       }

       if(entityMovement!=null){
            entityMovement.enabled=false;
       }
    }

    private IEnumerator Animate(){
        float elapsed = 0f;
        float duration = 2f;

        float jumpVelocity = 10f;
        float gravity = -36f;

        Vector3 velocity = Vector3.up*jumpVelocity;

        while (elapsed < duration){
            transform.position+= velocity* Time.deltaTime;
            velocity.y+= gravity*Time.deltaTime;
            elapsed+= Time.deltaTime;
            yield return null;
        }

    }
}
