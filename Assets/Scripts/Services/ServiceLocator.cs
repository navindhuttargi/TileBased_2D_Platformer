using Platformer2D.Movement;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Services
{
    public class ServiceLocator
    {
        private static Dictionary<object, object> _serviceContainer = null;
        public static Dictionary<object, object> serviceContainer => _serviceContainer;
        public static void InitializeContainer()
        {
            _serviceContainer = null;
            _serviceContainer = new Dictionary<object, object>()
        {
            {typeof(IBulletPool),new BulletPool() },
            {typeof(IPlayerSpawner),new PlayerSpawner() },
            {typeof(IEnemySpawner),new EnemySpawner() },
            {typeof(IScoreHandler),new ScoreHandler() },
            {typeof(IInteractableHandler),new InteractableHandler() },
            {typeof(IPlayerController),new PlayerController() }
        };
        }
        public static T GetService<T>()
        {
            try
            {
                return (T)_serviceContainer[typeof(T)];
            }
            catch (System.Exception ex)
            {
                Debug.Log(typeof(T).ToString());
                throw new System.Exception("Service not implemented");
            }
        }
    }
}