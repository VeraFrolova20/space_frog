using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int ChestCount;
    private int currentChestCount ;

    public float perctentages {get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        currentChestCount=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddChest(){
        currentChestCount++;
        perctentages = ((float)currentChestCount/ChestCount)*100;
    }
}
