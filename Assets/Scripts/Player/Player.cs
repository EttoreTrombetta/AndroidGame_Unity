using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public CharacterController playerCharacterController;
    public Transform playerTransform;
    public Transform groundCheck;
    public Transform shootingPoint;
    public int hp = 100;
    public float speed = 5f;
    public float turningSpeed = 5f;
    public float gravity = 9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Image healthBar;

    private bool goingForward = false;
    private bool turning = false;
    private int walkDirection = 1;
    private int turnDirection = 1;
    private bool isGrounded = true;
    private int hpTot;

    public int HpTot { get => hpTot; set => hpTot = value; }

    void Start()
    {
        HpTot = hp;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!isGrounded)
        {
            playerCharacterController.Move(new Vector3(0f, -2f, 0f) * gravity * Time.deltaTime);
        }

        if (goingForward)
        {
            playerCharacterController.Move(transform.forward * speed * walkDirection * Time.deltaTime);
        }

        if(turning)
        {
            playerTransform.Rotate(Vector3.up * turningSpeed * turnDirection * Time.deltaTime);
        }

        if(hp <= 0f)
        {
            Death();
        }

        HealthHandler();
    }

    public void StopGoing()
    {
        goingForward = false;
    }

    public void Walk(int dir)
    {
        walkDirection = dir / Mathf.Abs(dir);
        goingForward = true;
    }

    public void Turn(int dir)
    {
        turnDirection = dir / Mathf.Abs(dir);
        turning = true;
    }

    public void StopTurning()
    {
        turning = false;
    }

    private void HealthHandler()
    {
        healthBar.fillAmount = (float) hp / HpTot;

        if (healthBar.fillAmount < 0.2f)
        {
            healthBar.color = Color.red;
        }
        else if (healthBar.fillAmount < 0.4f)
        {
            healthBar.color = Color.yellow;
        }
        else
        {
            healthBar.color = Color.green;
        }
    }

    private void Death()
    {
        //Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
