using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public HealthBar healthBar;
    public GameOverScreen GameOverScreen;

    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private int maxHealth = 20;

    private float movementZ;
    private float movementX;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(movementX, 0f, movementZ);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if(moveDir != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
    }

    public void ReduceHealth(int damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            Debug.Log(currentHealth);           
        }
        else if(currentHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }  
}
