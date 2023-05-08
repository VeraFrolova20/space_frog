using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameObject[] activatedObjects;

    public GameObject[] stars;
    public void Setup(float delay){
        Invoke(nameof(setObjects),delay);
    }

    private void setObjects(){//включает экран 
        SetActiveObject(gameObject,true);
        foreach(GameObject obj in activatedObjects){
            SetActiveObject(obj,false);
        }

        if(scoreManager.perctentages>90){
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }else if (scoreManager.perctentages>50){
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(false);
        }else{
            stars[0].SetActive(true);
            stars[1].SetActive(false);
            stars[2].SetActive(false);
        }



    } 
    private void SetActiveObject(GameObject obj, bool boolValue){
        obj.SetActive(boolValue);
    }
}
