using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
           var player = other.gameObject.GetComponent<Player>();//.SetActive(false);
           player.Death();
           // GameManager.Instance.ResetLevel(1f);
        }else{
            Destroy(other.gameObject);
        }
    }
}
