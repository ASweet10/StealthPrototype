using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    CharacterController controller;

    [Header("Movement Parameters")]
    [SerializeField, Range(1, 10)] float walkSpeed = 10f;
    float runMultiplier;
    float gravityValue = 9.8f;
    bool canMove = true;
    float verticalSpeed;

    Vector2 currentInput;
    Vector3 currentMovement;

    /*

    [Header("Crouch Parameters")]
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standingHeight = 2.1f;
    [SerializeField] private float timeToCrouch = 0.25f;
    [SerializeField, Range(1, 5)] private float crouchSpeed = 2.5f;
    private bool isCrouching;
    private bool duringCrouchAnimation;
    private bool canCrouch = true;

    */

    void Awake()
    {
        //footstepAudioSource = gameObject.GetComponent<AudioSource>();
        controller = gameObject.GetComponent<CharacterController>();
    }
    void Update()
    {
        if(canMove){
            HandleMovement();
        }

    }
    private void HandleMovement() {
        currentInput.x = Input.GetAxis("Vertical") * walkSpeed;
        currentInput.y = Input.GetAxis("Horizontal") * walkSpeed;

        currentMovement = (transform.forward * currentInput.x) + (transform.right * currentInput.y);
        
        if(!controller.isGrounded){
            verticalSpeed -= gravityValue * Time.deltaTime;
            currentMovement.y = verticalSpeed;
        }
        controller.Move(currentMovement * Time.deltaTime);
    }

    //Not used in this game
    /*
    public void AttemptToCrouch()
    {
        if(!duringCrouchAnimation && controller.isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                StartCoroutine(CrouchOrStand());
            }
        }
    }
    private IEnumerator CrouchOrStand()
    {
        duringCrouchAnimation = true;

        float timeElapsed = 0f;
        float currentHeight = controller.height;
        float targetHeight;
        if(isCrouching)
        {
            targetHeight = standingHeight;
            isCrouching = false;
        }
        else
        {
            targetHeight = crouchHeight;
            isCrouching = true;
        }

        while(timeElapsed > timeToCrouch)
        {
            controller.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed / timeToCrouch);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        controller.height = targetHeight;

        duringCrouchAnimation = false;
    }
    */
}
