using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameObject[] activatedObjects;
   // public AudioSource failSound;

    private void Start(){
       // failSound = GetComponent<AudioSource>();
    }
    public void Setup(float delay){
        //failSound = GetComponent<AudioSource>();
        //failSound.Play();
        Invoke(nameof(setObjects),delay);
    }

    private void setObjects(){
        SetActiveObject(gameObject,true);
       // failSound.Play();
        foreach(GameObject obj in activatedObjects){
            SetActiveObject(obj,false);
        }

    } 
    private void SetActiveObject(GameObject obj, bool boolValue){
        obj.SetActive(boolValue);
    }
}
