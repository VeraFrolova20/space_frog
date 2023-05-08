using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public int world=1;
    public int stage=1;

    public string sceneName;
    public void LoadLevel(){
        GameManager.Instance.LoadLevel(world,stage);
    }

    public void LoadScene(){
        GameManager.Instance.LoadScene(sceneName);
    }
}