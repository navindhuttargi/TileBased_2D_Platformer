using Platformer2D;
using Platformer2D.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : BaseState
{
    public StartState(GameManager manager,StateController controller):base(manager, controller)
    {

    }
    public override void Entry()
    {
        Debug.Log("State Name:"+this.ToString());
        ServiceLocator.GetService<IPlayerSpawner>().SpwanPlayer();
        ServiceLocator.GetService<IEnemySpawner>().SpawnEnemy();
        GameManager.Instance.cameraFollow.SetFollowTransform(ServiceLocator.GetService<IPlayerSpawner>().playerRefGO.transform);
        ServiceLocator.GetService<IInteractableHandler>().ActivateInteractables();
        stateController.ChangeState(StateController.GameStates.running);
    }
}
