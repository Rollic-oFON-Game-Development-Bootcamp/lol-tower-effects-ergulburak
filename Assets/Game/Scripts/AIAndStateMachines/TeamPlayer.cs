using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class TeamPlayer : MonoBehaviour
{
  [SerializeField] private int maxHealth;
  private int currentHealth;
  public bool IsDead;

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("EnemyPlayer"))
    {
      var enemy = other.attachedRigidbody.GetComponent<EnemyPlayer>();
      enemy.GetHitByEnemy(this);
    }

    if (other.CompareTag("Fireball"))
    {
      Destroy(other.attachedRigidbody.gameObject);
      GetHit();
    }
  }

  private void Die()
  {
    Destroy(gameObject);
  }

  public bool GetHit(int damage = 1)
  {
    IsDead = false;
    currentHealth -= damage;
    if (currentHealth <= 0)
    {
      IsDead = true;
      Die();
    }

    return IsDead;
  }
}
