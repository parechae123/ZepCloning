using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IMoveHandler 
{
    void OnMove(Vector3 dir);

}

public class PlayerMoveHandler : IMoveHandler
{
    private Rigidbody2D rb;
    public PlayerMoveHandler(Rigidbody2D tr) {this.rb = tr;}
    public void OnMove(Vector3 dir)
    {
        rb.velocity = dir;
        //tr.position += dir*Time.deltaTime;
    }
}