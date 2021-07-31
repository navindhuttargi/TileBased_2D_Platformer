using Platformer2D.Movement;
using UnityEngine;

namespace Platformer2D.Interactables
{
    public class BaseItem : MonoBehaviour
    {
        protected virtual void Start()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
        protected virtual PlayerMovement GetPlayer(Collider2D collision)
        {
            return collision.transform.GetComponent<PlayerMovement>();
        }
    }
}