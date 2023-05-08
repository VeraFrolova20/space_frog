using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public ScoreManager scoreManager;
    private AudioSource collectSound;
    private new BoxCollider2D collider;
    private new SpriteRenderer renderer;

    private void Start()
    {
        collectSound = GetComponent<AudioSource>();
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
           scoreManager.AddChest();
            collider.enabled=false;
            renderer.enabled = false;
           collectSound.Play();
            //gameObject.SetActive(false);
        }
    }
}
