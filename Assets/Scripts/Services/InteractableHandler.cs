using Platformer2D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Services
{
    public class InteractableHandler : IInteractableHandler
    {
        private Transform parentTransform;
        List<GameObject> itemPickups = new List<GameObject>();
        public InteractableHandler()
        {
            GameManager.Instance.restartGame += ResetInteractables;
        }
        ~InteractableHandler()
        {
            GameManager.Instance.restartGame -= ResetInteractables;
        }
        public void InitializeInteractableHandler(Transform transform)
        {
            parentTransform = transform;
            for (int i = 0; i < parentTransform.childCount; i++)
            {
                itemPickups.Add(parentTransform.GetChild(i).gameObject);
            }
        }
        public void ActivateInteractables()
        {
            for (int i = 0; i < itemPickups.Count; i++)
            {
                itemPickups[i].SetActive(true);
            }
        }
        private void ResetInteractables()
        {

        }
    }
}