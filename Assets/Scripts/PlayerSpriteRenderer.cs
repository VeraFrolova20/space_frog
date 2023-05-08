using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
   private SpriteRenderer spriteRenderer;
   private PlayerMovement movement;

   public Sprite idle;
   public Sprite jump;
   public AnimatedSprite run;

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerMovement>();
    }

    public void OnEnable(){
        spriteRenderer.enabled = true;
    }

    private void OnDisable(){
        spriteRenderer.enabled = false;
        run.enabled=false;
    }

    private void LateUpdate(){
        run.enabled = movement.running;
        if(movement.jumping){
            spriteRenderer.sprite = jump;
        }else if (!movement.running){
            spriteRenderer.sprite = idle;
        }
        if(movement.hit){
            Color color;
            ColorUtility.TryParseHtmlString("#FFC9C9",out color);
            spriteRenderer.color = color;
            
        }else{
            spriteRenderer.color = Color.white;
        }
    }
}
