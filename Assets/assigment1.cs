using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assigment1 : ProcessingLite.GP21
{
    Vector2 circlePosition;
    Vector2 circlePosition2;

    float diameter = 2;
    float speed = 2;
    
    Vector2 velocity;
    Vector2 acceleration;
    
    void Start()
    {
        circlePosition = new Vector2(Width / 2, Height / 2);
        circlePosition2 = new Vector2(Width / 2, Height / 2);
    }
    
    void Update()
    {
        Background(219, 112, 147);
        Fill(100, 149, 237);
        Stroke(100, 149, 237);

        //controll the speed with buttons
        float x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        //Give circle1 acceleration
        acceleration = new Vector2(x, y);
        velocity += acceleration * Time.deltaTime;

        circlePosition += velocity;

        Circle(circlePosition.x,circlePosition.y, diameter);

        // controll the maxspeed
        if (velocity.magnitude > 0.01f)
        {
            velocity = velocity.normalized * 0.01f;
        }// if no buttons are used the circle will slow down and stop-
        else if (acceleration.magnitude == 0)
        {
            velocity *= 0.99f;
        }

        //Draw circle2 without acceleration 
        Fill(46, 139, 87);
        Stroke(46, 139, 87);

        circlePosition2 += new Vector2(x, y);

        Circle(circlePosition2.x, circlePosition2.y, diameter);

        //Makes the circle stay inside the screen 
        circlePosition.x = (circlePosition.x + Width) % Width;
        circlePosition.y = (circlePosition.y + Height) % Height;
        circlePosition2.x = (circlePosition2.x + Width) % Width;
        circlePosition2.y = (circlePosition2.y + Height) % Height;
 
    }
}
 