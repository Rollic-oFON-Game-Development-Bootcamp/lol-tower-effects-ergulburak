using System;
using UnityEngine;


public class FireballMovement : MonoBehaviour
{
  [SerializeField] private float speed;

  public Transform Target { get; set; }

  private void Update()
  {
    if (Target != null)
    {
      Vector3 direction = Target.position - transform.position;
      direction.Normalize();
      transform.position += direction * speed * Time.deltaTime;
      transform.LookAt(Target);
    }
    else Destroy(this.gameObject);
  }
}
