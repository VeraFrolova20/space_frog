using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
   // private new MeshRenderer renderer;
    private new Camera camera;
   

    public float Speed = 8f;
    private float HorSpeed;
    public float VertSpeed;
    public float Imp;

    public bool grounded { get; private set; }
    public bool jumping => grounded==false;
    public bool running => HorSpeed!=0;

    public bool hit {get; private set;}

    public AudioSource jumpAudio;
   
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        camera= Camera.main;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            OnLeft();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Stop();
        }
        if (Input.GetKey(KeyCode.D))
        {
            OnRight();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Stop();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            OnJump();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Stop();
        }

    }

    private void FixedUpdate(){
        grounded = rigidbody.Raycast(Vector2.down);
        if(hit){
            Invoke(nameof(setHit),0.5f);
        }
        //Vector2 position = rigidbody.position;
        //Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        //Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    
        if (HorSpeed > 0f)
        {
            transform.eulerAngles = Vector3.zero;
            transform.Translate(HorSpeed,0,0);
           //Vector2 pos = new Vector2(position.x+HorSpeed, position.y);
           //rigidbody.MovePosition(pos);
            
        }
        else if (HorSpeed < 0f)
        {
            transform.eulerAngles = new Vector3(0f,180f,0f);
            transform.Translate(-HorSpeed,0,0);
            
        }
        /*position = rigidbody.position;
        position.x = Mathf.Clamp(position.x, leftEdge.x, rightEdge.x);
        rigidbody.MovePosition(position);*/

        

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer== LayerMask.NameToLayer("Enemy")){
            if(transform.DotTest(collision.transform, Vector2.down)){
                rigidbody.AddForce(new Vector2(0,Imp/3), ForceMode2D.Impulse);
            }else
            if(transform.DotTest(collision.transform, Vector2.right)){
                rigidbody.AddForce(new Vector2(-Imp/3,Imp/3), ForceMode2D.Impulse);
                hit=true;
            }else
            if(transform.DotTest(collision.transform, Vector2.left)){
                rigidbody.AddForce(new Vector2(Imp/3,Imp/3), ForceMode2D.Impulse);
                hit=true;
            }
        }
    }

    public void setHit(){
        hit=false;
    }

    public void OnRight(){
        HorSpeed = Speed; 
    }

    public void OnLeft(){
        HorSpeed = -Speed; 
    }

    public void OnJump(){
        if(grounded == true){
            jumpAudio.Play();
            rigidbody.AddForce(new Vector2(0,Imp), ForceMode2D.Impulse);
        }
    }

    public void Stop(){
        HorSpeed=0;
    }


}
