using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    private PickupItem pickUp;

    Vector2 movement;
    //private Vector3 change;
    void Start()
    {
        pickUp = gameObject.GetComponent<PickupItem>();
        pickUp.Direction = new Vector2(0, -1);
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");  //directia pe orizontala
        movement.y = Input.GetAxisRaw("Vertical");  //directia pe verticala

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //change sunt folosite pentru a afla distanta in care se misca player-ul, ulterior folosite pentru a arunca item-ul detinut de jucator
        /*change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change.sqrMagnitude > .2f)
        {
            pickUp.Direction = change.normalized;
        }*/
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position +  movement * moveSpeed * Time.fixedDeltaTime);
    }
}
