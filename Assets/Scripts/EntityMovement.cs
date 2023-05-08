using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    public float speed = 1f;
    public float UnitsToMove=2;
   // public bool _isFacingRight;
    private float startPos;
    private float endPos;

    public bool _moveRight = true;
   // public Vector2 direction = Vector2.left;

    private void Awake(){
        rigidbody = GetComponent<Rigidbody2D>();
        startPos = rigidbody.transform.position.x;
        endPos = startPos + UnitsToMove;
        //_isFacingRight = transform.localScale.x > 0 ;
        //enabled = false;
    }

    private void onBecameVisible(){
        enabled = true;
    }

    private void onBecameInvisible(){
        enabled = false;
    }

    private void OnEnable(){
        rigidbody.WakeUp();
    }

    private void OnDisable(){
        rigidbody.Sleep();
    }

    private void FixedUpdate()
    {
        if (_moveRight)
        {
           rigidbody.velocity = new Vector2(speed,rigidbody.velocity.y);
            //rigidbody.transform.Translate(Vector2.right*Time.deltaTime);
        }

        if (rigidbody.position.x >= endPos){
            _moveRight = false;
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        if (!_moveRight)
        { 
           // rigidbody.transform.Translate(Vector2.left*Time.deltaTime);
            rigidbody.velocity = new Vector2(-speed,rigidbody.velocity.y);
        }
        if (rigidbody.position.x <= startPos){
            _moveRight = true;
            transform.eulerAngles = Vector3.zero;
           
        }
    }

  

}
