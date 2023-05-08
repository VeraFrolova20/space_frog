using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
   // public int stage;

   public WinScreen winScreen;
    private AudioSource finishSound;

    private bool levelCompleted = false;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(!levelCompleted && collision.CompareTag("Player")){
            finishSound.Play();
            levelCompleted=true;
            CompleteLevel();
        }
    }

    private void CompleteLevel(){
        //GameManager.Instance.NextLevel(4f);
         winScreen.Setup(0.5f);
        //GameOverScreen.Setup();
    }



}
