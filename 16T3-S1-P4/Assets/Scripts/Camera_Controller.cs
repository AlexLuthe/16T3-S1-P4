using UnityEngine;
using System.Collections;

public class Camera_Controller : MonoBehaviour {

    // Bounds to begin lerping towards player
    int xMaxPos = 5;
    int zMaxPos = 5;
    // Bounds to follow player
    int xCutPos = 8;
    int zCutPos = 8;

    float MoveSpeed = 2;

    public GameObject Player;

    public bool ScreenShake = false;
    public Vector3 ScreenShakeDirection;
    public Vector3 CameraPosition;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Movement();
        if (ScreenShake)
            CameraShake();
    }

    void Movement() {

        // Lerp towards player if player is heading towards bounds

        if (Player.transform.position.x < transform.position.x - xMaxPos) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.transform.position.x + xMaxPos, transform.position.y, transform.position.z), Time.deltaTime * MoveSpeed);
        }
        else if (Player.transform.position.x > transform.position.x + xMaxPos) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.transform.position.x - xMaxPos, transform.position.y, transform.position.z), Time.deltaTime * MoveSpeed);
        }

        if (Player.transform.position.z < transform.position.z - zMaxPos) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Player.transform.position.z + zMaxPos), Time.deltaTime * MoveSpeed);
        }
        else if (Player.transform.position.z > transform.position.z + zMaxPos) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Player.transform.position.z - zMaxPos), Time.deltaTime * MoveSpeed);
        }

        // Follow player if player is too close to bounds

        if (Player.transform.position.x < transform.position.x - xCutPos) {
            transform.position = new Vector3(Player.transform.position.x + xCutPos, transform.position.y, transform.position.z);
        }
        else if (Player.transform.position.x > transform.position.x + xCutPos) {
            transform.position = new Vector3(Player.transform.position.x - xCutPos, transform.position.y, transform.position.z);
        }

        if (Player.transform.position.z < transform.position.z - zCutPos) {
            transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z + zCutPos);
        }
        else if (Player.transform.position.z > transform.position.z + zCutPos) {
            transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z - zCutPos);
        }
    }

    void CameraShake() {
        if (Vector3.Distance(transform.position, ScreenShakeDirection) > 0.5f)
            Vector3.MoveTowards(transform.position, ScreenShakeDirection, Time.deltaTime * 10);
        else
            Vector3.MoveTowards(transform.position, CameraPosition, Time.deltaTime * 8);

        if (Vector3.Distance(transform.position, CameraPosition) < 0.5f)
            ScreenShake = false;
    }
}
