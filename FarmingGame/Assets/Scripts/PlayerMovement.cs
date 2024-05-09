using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Transform cam;

    public float speed;
    float finalSpeed;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Vector3 moveDir;

    public Animator animator;
    bool running;

    bool canMove;

    public AudioSource walkingAudio;
    private void Start()
    {
        canMove = true;
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;

        PlayerManager.playerManager.OnFreezePlayer += FreezePlayer;
    }

    private void Update()
    {
        if (canMove)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            Run();

            if (direction != Vector3.zero)
            {
                animator.SetBool("isWalking", true);

                if (running)
                {
                    animator.SetBool("isRunning", true);
                }
                else
                {
                    animator.SetBool("isRunning", false);
                }
            }
            else
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
                walkingAudio.Stop();
            }

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                if (running)
                {
                    finalSpeed = speed * 1.5f;
                }
                else
                {
                    finalSpeed = speed;
                }
                moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * finalSpeed * Time.deltaTime);
            }
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            running = true;
        }
        else
        {
            running = false;
        }
    }

    private void FreezePlayer(float time)
    {
        StartCoroutine(Freeze(time));
    }
    IEnumerator Freeze(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
}
