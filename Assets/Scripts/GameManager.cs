using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public int world{get; private set;}
    public int stage{get; private set;}
    public int lives{get; private set;}

    private void Awake(){
        if(Instance!= null){
            DestroyImmediate(gameObject);
        }else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy(){
        if(Instance==this){
            Instance =null;
        }
    }

    private void Start(){
       SceneManager.LoadScene($"StartScreen");
    }

    private void NewGame(){
        lives=3;
        LoadLevel(1,1);
    }

    public void LoadLevel(int world, int stage){
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void NextLevel(){
        //if(world==1 && stage==10)
        //    LoadLevel(world+1,1);
        //else
        LoadLevel(world,stage+1);
    }

    public void NextLevel(float delay){
        Invoke(nameof(NextLevel),delay);
    }

    public void ResetLevel(float delay){
        Invoke(nameof(ResetLevel),delay);
    }

    public void ResetLevel(){
        lives--;

        if(lives>0){
            LoadLevel(world,stage);
        }else{
            GameOver();
        }
    }

    private void GameOver(){
       NewGame();
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void OpenLevelMenu(){
        SceneManager.LoadScene($"LevelsScene");
    }

    public void StopScene(){
        Time.timeScale = 0;
    }

    void ResumeScene ()
    {
        Time.timeScale = 1;
    }


}

