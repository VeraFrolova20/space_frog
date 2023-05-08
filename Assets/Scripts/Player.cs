using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameOverScreen gameOverScreen;
    public LivesManager livesManager;
    public PlayerSpriteRenderer smallRenderer;

    private DeathAnimation deathAnimation;

    public AudioSource hurtSound;
   // public AudioSource failSound;

    public bool dead => deathAnimation.enabled;

    public void Awake(){
        deathAnimation = GetComponent<DeathAnimation>();//получает компоненту анимации смерти
       // hurtSound = GetComponent<AudioSource>();
    }
    public void Hit(){
        //Death();
        livesManager.TakeLife();//забираем жизнь
        hurtSound.Play();
    }

    public void Death(){
        smallRenderer.enabled = false;
        deathAnimation.enabled=true;

       gameOverScreen.Setup(3f);
    }

}
