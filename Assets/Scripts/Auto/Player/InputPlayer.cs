using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : AbstInput //PARCIAL 2 - Santiago Postacchini
{
    public override void ArtificialUpdate()
    {
        accelInput = Input.GetAxis("Horizontal");
        steerInput = Input.GetAxis("Vertical");
    }
}
