using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcAnimManager : MonoBehaviour
{
    private Animator anim;
    public string npcType;
    private bool isWalking = false;
    private bool isMoving = false;
    private bool isWalkingToTarget = false;
    private Vector3 targetPosition;
    [SerializeField] private float walkSpeed = 2.0f;

    private npcManager manager;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        anim = GetComponent<Animator>();

        // Find the npcManager in the scene
        manager = FindObjectOfType<npcManager>();

        // Register with the manager
        if (manager != null)
        {
            manager.RegisterNPC(gameObject);
        }
        else
        {
            Debug.LogError("Could not find npcManager in the scene!");
        }

        // Show walking animation immediately but don't move yet
        anim.SetBool("WantsToDance", false);
        anim.SetBool("WantsToIdle", false);
        anim.SetBool("WantsToWalk", true);
        isWalking = true;
        isMoving = false;

        // Start the walking sequence
        StartCoroutine(WalkAfterSpawn());
    }

    void OnDestroy()
    {
        // Unregister from the manager when destroyed
        if (manager != null)
        {
            manager.UnregisterNPC(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Animation states are controlled based on walking state and music
        if (isWalking)
        {
            // Walking animation takes priority
            anim.SetBool("WantsToDance", false);
            anim.SetBool("WantsToIdle", false);
            anim.SetBool("WantsToWalk", true);

            // Only move the NPC if isMoving is true
            if (isMoving)
            {
                if (isWalkingToTarget)
                {
                    // Move towards target position when despawning
                    Vector3 direction = (targetPosition - transform.position).normalized;
                    transform.position += direction * walkSpeed * Time.deltaTime;

                    //  rotation code to prevent tilting
                    Vector3 lookDirection = (targetPosition - transform.position);
                    lookDirection.y = 0; // Keep the NPC upright by zeroing Y component
                    if (lookDirection != Vector3.zero) // Avoid errors when vectors are identical
                    {
                        transform.forward = lookDirection.normalized; // Face the direction of movement
                    }

                    // Check if we're close enough to the target
                    if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
                    {
                        // We've reached the target position, directly call the manager
                        if (manager != null)
                        {
                            manager.OnReachedDespawnPoint(gameObject);
                        }
                        else
                        {
                            Debug.LogError("No manager reference to notify about reaching despawn point");
                            Destroy(gameObject); // Fallback
                        }
                    }
                }
                else
                {
                    // Regular movement behavior during normal walking
                    transform.position += transform.forward * walkSpeed * Time.deltaTime;
                }
            }
        }
        else if ((npcType == held_track.genreTag) && deck_btn.isPlaying)
        {
            // Dancing when preferred genre is playing
            anim.SetBool("WantsToDance", true);
            anim.SetBool("WantsToIdle", false);
            anim.SetBool("WantsToWalk", false);
        }
        else
        {
            // Default to idle
            anim.SetBool("WantsToDance", false);
            anim.SetBool("WantsToIdle", true);
            anim.SetBool("WantsToWalk", false);
        }
    }

    public void WalkToPositionAndDespawn(Vector3 targetPos)
    {
        // Stop any existing movement coroutines
        StopAllCoroutines();

        // Set up walking to target (keep the same Y position)
        targetPosition = new Vector3(targetPos.x, transform.position.y, targetPos.z);
        isWalkingToTarget = true;
        isWalking = true;
        isMoving = true;

        // Rotate to face the target but only on Y axis
        Vector3 direction = (targetPosition - transform.position);
        direction.y = 0; // Zero out the Y component to prevent tilting
        direction = direction.normalized;

        // Create a rotation that only affects the Y axis
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    public IEnumerator WalkAfterSpawn()
    {
        // Initial state: walking animation but not moving
        isWalking = true;
        isMoving = false;

        // Wait for a random time before starting to move
        float waitBeforeMovingTime = Random.Range(1f, 14f);
        Debug.Log("NPC will display walking animation for " + waitBeforeMovingTime + " seconds before moving");
        yield return new WaitForSeconds(waitBeforeMovingTime);

        // Start actual movement
        isMoving = true;
        Debug.Log("NPC started moving");

        // Move for a random duration
        float movementDuration = Random.Range(3f, 12f);
        Debug.Log("NPC will move for " + movementDuration + " seconds");
        yield return new WaitForSeconds(movementDuration);

        // Stop moving and walking
        isMoving = false;
        isWalking = false;
        Debug.Log("NPC stopped moving");

        // Rotate to a new direction and start moving again
        transform.rotation = Quaternion.Euler(0, Random.Range(140, 190), 0);
        isMoving = true;
        isWalking = true;

        // Second walking period
        float movementDuration2 = Random.Range(1f, 8f);
        yield return new WaitForSeconds(movementDuration2);
        isMoving = false;
        isWalking = false;
    }
}