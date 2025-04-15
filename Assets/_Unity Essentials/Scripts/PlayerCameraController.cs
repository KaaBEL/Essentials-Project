using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private GameObject Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player == null)
        {
            Player = new GameObject("NotFound");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 position = Player.transform.position;
        gameObject.transform.position = new(position.x, position.y, position.z);
    }
}
