using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public Transform playerObject;

    void Update()
    {
        //checks if player object is static
        Rigidbody2D playerRigidbody = playerObject.GetComponent<Rigidbody2D>();
        if (playerRigidbody.bodyType == RigidbodyType2D.Static)
        {
            Debug.Log("Player object is static.");
            GhostGotMoves();
        }
    }
    private void GhostGotMoves()
    {
        transform.position = new Vector3(playerObject.position.x, playerObject.position.y + 1f, transform.position.z);
    }
}