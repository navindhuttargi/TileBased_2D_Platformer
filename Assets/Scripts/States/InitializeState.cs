using Platformer2D;
using Platformer2D.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeState : BaseState
{
    public InitializeState(GameManager manager, StateController controller) : base(manager, controller)
    {

    }
    public override void Entry()
    {
        Debug.Log("State Name:" + this.ToString());
        ServiceLocator.InitializeContainer();
        ServiceLocator.GetService<IPlayerSpawner>().InitializePlayerSpawner(gameManager.config.playerPrefab);
        ServiceLocator.GetService<IEnemySpawner>().InitializeEnemySpawner(gameManager.config.enemy1Prefab, gameManager.enemyParent, gameManager.config.enemyCount,gameManager.config.enemy2Prefab);
        ServiceLocator.GetService<IScoreHandler>().Initialize(gameManager.config.totalCoins);
        ServiceLocator.GetService<IInteractableHandler>().InitializeInteractableHandler(gameManager.interactablesParent);
        ServiceLocator.GetService<IBulletPool>().InitializePool(gameManager.config.bulletPrefab,gameManager.config.bulletLength);
        stateController.ChangeState(StateController.GameStates.start);
    }
}
