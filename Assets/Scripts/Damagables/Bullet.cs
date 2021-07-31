using Platformer2D;
using Platformer2D.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rgBody;
    public bool isShootByEnemy = false;
    private void Start()
    {
        rgBody = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        Invoke("Disable", 3f);
        rgBody.WakeUp();
    }
    public void FireBullet(Vector3 direction,float speed,Vector3 position)
    {
        gameObject.SetActive(true);
        GetComponent<Collider2D>().enabled = true;
        transform.position = position;
        rgBody.velocity = direction * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.transform.GetComponent<PlayerMovement>();
        if (isShootByEnemy && player)
        {
            //GameManager.Instance.GameStatus(false);
            player.DeathAnimation();
        }
        else
        {
            BaseEnemy enemyMovement = collision.transform.GetComponent<BaseEnemy>();
            if (enemyMovement && !isShootByEnemy)
            {
                Debug.Log("Enemy Death event:"+collision.gameObject.name);
                enemyMovement.DeathAnimation();
            }
        }
        ResetBullet();
        GetComponent<Animator>().SetTrigger("blast");
    }
    void Disable()
    {
        DisableBullet();
    }
    void ResetBullet()
    {
        isShootByEnemy = false;
        GetComponent<Collider2D>().enabled = false;
        rgBody.Sleep();
    }
    void DisableBullet()
    {
        gameObject.SetActive(false);
        rgBody.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        CancelInvoke();
    }
}
