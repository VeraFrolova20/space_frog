using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pike : MonoBehaviour
{
 private void OnCollisionEnter2D(Collision2D collision){
        
        if(collision.gameObject.CompareTag("Player")){
            Player player = collision.gameObject.GetComponent<Player>();
            //Player player = collision.gameObject.GetComponent<Player>();

            //if(collision.transform.DotTest(transform, Vector2.down)){
           //     Flatten();
           // } else{
                player.Death();
           // }
        }

    }
}
