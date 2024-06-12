using System;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : AbstInput //PARCIAL 2 - Santiago Postacchini
{
    Action _ArtificialUpdate;
    Auto _car;
    public InputPlayer(float accel, float steer, Auto car) : base(accel, steer)
    {
        accelInput = accel;
        steerInput = steer;
        _car = car;
        _ArtificialUpdate = NormalControl;
    }

    public override void ArtificialUpdate()
    {
        _ArtificialUpdate();
    }

    void NormalControl() 
    {
        accelInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
        _car.RunWheel(steerInput, accelInput);
    }

    void FlyControl() //
    {
        accelInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
        _car.RotateRB(steerInput, accelInput);
    }

    public override void ChangeControl(string name)
    {
        if (name == "Normal")
            _ArtificialUpdate = NormalControl;
        else if(name == "Fly")
            _ArtificialUpdate = FlyControl;
    }
}
