using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public float leftrightSpeed = 4;
    public Rigidbody rb;
    public Animator animator;
    public LayerMask layerMask;
    public bool grounded;
    float startColliderHeight = 0;
    private CapsuleCollider collider;
    public static bool canMove = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
        startColliderHeight = collider.height;
    }
    private void Update() {
        Grounded();
        Jump();
        Slide();
        Move();     
    }
    private void Jump(){
        if(canMove== true){
            if(Input.GetKeyDown(KeyCode.Space) && this.grounded){
                this.rb.AddForce(Vector3.up * 250);
            }
        }
    }
    private void Grounded(){
        if(Physics.CheckSphere(this.transform.position + Vector3.down, 0.2f, layerMask)){
            this.grounded = true;
        }
        else{
            this.grounded = false;
        }
        this.animator.SetBool("jump",!this.grounded);
    } 
    private void Slide(){
        if(Input.GetKey(KeyCode.DownArrow) && this.grounded){
            this.animator.SetBool("slide",true);

            }
            else{
                this.animator.SetBool("slide",false);
            }
        }
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.IsName("Slide"))
            {
                float colliderheight = animator.GetFloat("colliderheight");
                collider.height = startColliderHeight * colliderheight;
                float centery = -0.5f;
                collider.center = new Vector3(collider.center.x,centery,collider.center.z);
            }
            else{
                collider.height = startColliderHeight;
                collider.center = new Vector3(collider.center.x,0,collider.center.z);
            }
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if(canMove == true){
            if(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow)){
                if(this.gameObject.transform.position.x > LevelBoundary.leftside){
                    transform.Translate(Vector3.left * Time.deltaTime * leftrightSpeed);
                }
            }

            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
                if(this.gameObject.transform.position.x < LevelBoundary.rightside){
                    transform.Translate(Vector3.left * Time.deltaTime * leftrightSpeed * -1);
                }
            }
        }
    }
}
