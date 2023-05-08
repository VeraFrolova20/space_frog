using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public int defaultLives = 3;
    public int livesCounter;

    public Image[] images;

    private GameManager gameManager;

    public Player player;

    void Start(){
        livesCounter = defaultLives;

        //player = FindObjectOfType<Player>();
    }

    void Update(){
        for(int i=0;i<images.Length;i++){
           if(i<livesCounter)
           images[i].enabled=true;
           else
            images[i].enabled=false;
        }

        if(livesCounter<1){
            player.Death();
           // player.failSound.Play();
        }
    }

    public void TakeLife(){
        if(livesCounter>0)
            livesCounter--;
    }

    public void AddLife(){
        if(livesCounter<defaultLives){
            livesCounter++;
        }
    }

}
