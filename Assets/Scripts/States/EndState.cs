using Platformer2D;
using Platformer2D.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : BaseState
{
    public EndState(GameManager manager,StateController controller) : base(manager,controller)
    {

    }
    public override void Entry()
    {
        Debug.Log("State Name:" + this.ToString());
        GameManager.Instance.controller.ChangeState(StateController.GameStates.start);
    }
}
