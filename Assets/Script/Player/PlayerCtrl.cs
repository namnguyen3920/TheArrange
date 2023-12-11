using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCtrl : MonoBehaviour
{

    public static PlayerCtrl Instance { get; private set; }

    public event EventHandler<OnSelectedChangedArgs> OnSelectedChanged;

    public class OnSelectedChangedArgs : EventArgs
    {
        public ClearConveyor selectedConveyor;
    }


    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float playerHeight = 2f;
    [SerializeField] private float playerRadius = 0.7f;
    [SerializeField] private float moveSpeed;
    private float moveDistance;
    [SerializeField] private GameObject checkCollision;
    [SerializeField] private GameInput gameInput;

    bool isWalking;
    private ClearConveyor selectedConveyor;
    Vector3 lastInteractDir;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        gameInput.OnInteractAction += GameInput_OnInteractAction;

    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if(selectedConveyor != null)
        {
            selectedConveyor.Interact();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovementHandler();
        InteractHandler();
    }

    private void InteractHandler() 
    {
        Vector2 movementInput = gameInput.GetMovementNormalized();

        Vector3 moveDirection = new Vector3(movementInput.x, 0f, movementInput.y);

        if(moveDirection !=  Vector3.zero)
        {
            lastInteractDir = moveDirection;
        }

        if(Physics.Raycast(checkCollision.transform.position, lastInteractDir, out RaycastHit rayCastHit, 2f))
        {
            if(rayCastHit.transform.TryGetComponent(out ClearConveyor clearConveyor)){
                //clearConveyor.Interact();
                SetSelectedObjects(clearConveyor);

            //    if (clearConveyor != selectedConveyor)
            //    {
            //        SetSelectedObjects(clearConveyor);                    
            //    }
            //    else
            //    {
            //        SetSelectedObjects(null);
            //    }
            //}
            //else
            //{
            //    SetSelectedObjects(null);
            }
        }
        Debug.Log(selectedConveyor);
    }
    private void SetSelectedObjects(ClearConveyor selectedConveyor)
    {
        this.selectedConveyor = selectedConveyor;
        OnSelectedChanged?.Invoke(this, new OnSelectedChangedArgs
        {
            selectedConveyor = selectedConveyor
        });
    }
    private void MovementHandler()
    {
        Vector2 movementInput = gameInput.GetMovementNormalized();
        Vector3 moveDirection = new Vector3(movementInput.x, 0f, movementInput.y);
        moveDistance = moveSpeed * Time.deltaTime;


        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.down * playerHeight, playerRadius, moveDirection, moveDistance);
  
        if (!canMove)
        {
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0f, 0f);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.down * playerHeight, playerRadius, moveDirectionX, moveDistance);
            if (canMove)
            {
                moveDirection = moveDirectionX;
            }
            else
            {
                Vector3 moveDirectionZ = new Vector3(0f, 0f, moveDirection.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.down * playerHeight, playerRadius, moveDirectionZ, moveDistance);
                if (canMove)
                {
                    moveDirection = moveDirectionZ;
                }
            }

        }
        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        isWalking = moveDirection != Vector3.zero;

        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
    }
    
    public bool IsWalking()
    {
        return isWalking;
    }
    //void IsometricMovement()
    //{
    //    Vector3 rightMovement = right * moveSpeed * Input.GetAxis("Horizontal");
    //    Vector3 upMovement = forward * moveSpeed * Input.GetAxis("Vertical");

    //    Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

    //    Vector3 newPosition = transform.position;
    //    newPosition += rightMovement;
    //    newPosition += upMovement;    

    //    transform.forward = heading;
    //    transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime);
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerRadius);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * playerHeight);
        Gizmos.DrawWireSphere(transform.position + Vector3.down * playerHeight, playerRadius);
    }
}
