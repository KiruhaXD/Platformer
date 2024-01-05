using UnityEngine;

public class Worm : Entity
{
    [SerializeField] private int lives = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == PlayerController.Instance.gameObject) 
        {
            PlayerController.Instance.GetDamage();
            lives--;
            Debug.Log("у червяка: " + lives + " жизней");
        }

        if (lives < 1)
            Die();
            

    }
}
