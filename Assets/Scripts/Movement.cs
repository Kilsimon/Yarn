using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;

public class Movement : MonoBehaviour
{
    public float MovementSpeed;
    public float TurnSpeed;
    public float InteractionRadius;

    Vector3 acceleration;
    private float velcocity;
    // Update is called once per frame
    void Update()
    {
        velcocity = Input.GetAxis("Vertical");
        transform.Rotate(transform.up, Input.GetAxis("Horizontal") * TurnSpeed * Time.deltaTime);
        transform.position += transform.forward * velcocity * MovementSpeed * Time.deltaTime;

        // Detect if we want to start a conversation
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckForNearbyNPC();
        }
    }

    /// Find all DialogueParticipants
    /** Filter them to those that have a Yarn start node and are in range; 
     * then start a conversation with the first one
     */
    public void CheckForNearbyNPC()
    {
        var allParticipants = new List<NPC>(FindObjectsOfType<NPC>());
        var target = allParticipants.Find(delegate (NPC p) {
            return string.IsNullOrEmpty(p.talkToNode) == false && // has a conversation node?
            (p.transform.position - this.transform.position)// is in range?
            .magnitude <= InteractionRadius;
        });
        if (target != null)
        {
            // Kick off the dialogue at this node.
            FindObjectOfType<DialogueRunner>().StartDialogue(target.talkToNode);
        }
    }

}
