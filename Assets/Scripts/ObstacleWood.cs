using UnityEngine;

public class ObstacleWood : Entity
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == PlayerController.Instance.gameObject) 
        {
            PlayerController.Instance.GetDamage();
        }
    }

    
}
