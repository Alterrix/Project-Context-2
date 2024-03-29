using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Elevator el;
    private Animator animator;
    public float speed;
    public float rotationSpeed;
    public GameObject player;
    public Bathroom bathroom;
    public BathroomAi bathroomAi;
    public DeathRoom deathRoom;

    private void Start()
    {
        animator = player.GetComponent<Animator>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
       

        if (el.walking)
        {
            animator.SetBool("IsMoving",true);
        }

        if (bathroom.walking)
        {
            animator.SetBool("IsMoving", true);
        }
        if (bathroomAi.walking)
        {
            animator.SetBool("IsMoving", true);
        }

        if (deathRoom.walking)
        {
            animator.SetBool("IsMoving", true);
        }
    }
}


