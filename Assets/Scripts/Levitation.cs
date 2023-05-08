using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitation : MonoBehaviour
{

    public float maxChanges;
    private float startYPosition;
    public float framerate = 1f/6f;

    private int i=1;
    // Start is called before the first frame update
    void Start()
    {
        startYPosition = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable(){
        InvokeRepeating(nameof(ChangePosition),framerate,framerate);
    }
    private void ChangePosition(){
        switch(i){
            case 1:
                 gameObject.transform.position = new Vector2( gameObject.transform.position.x,startYPosition);
                 break;
            case 2:
                 gameObject.transform.position = new Vector2( gameObject.transform.position.x,startYPosition+maxChanges);
                 break;
            case 3:
                 gameObject.transform.position = new Vector2( gameObject.transform.position.x,startYPosition);
                 break;
            case 4:
                 gameObject.transform.position = new Vector2( gameObject.transform.position.x,startYPosition-maxChanges);
                 break;
        }
        i++;
        if(i==5) i=1;
      
    }
}
