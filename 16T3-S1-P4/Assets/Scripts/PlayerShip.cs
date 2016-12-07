using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

    public Rigidbody _RigidBody;
    float MovementForce = 10;
    float MaxSpeed = 7;
    public float CurrentXSpeed;
    public float CurrentZSpeed;
    float RotationSpeed = 200;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Movement();
        Rotation();
    }

    void Movement() {
        if (Input.GetKey("w")) {
            if (_RigidBody.velocity.z < 0)
                _RigidBody.AddForce(Vector3.forward * MovementForce * 2);
            else if (_RigidBody.velocity.z > -MaxSpeed)
                _RigidBody.AddForce(Vector3.forward * MovementForce);
        }
        else if (Input.GetKey("s")) {
            if (_RigidBody.velocity.z > 0)
                _RigidBody.AddForce(Vector3.back * MovementForce * 2);
            else if (_RigidBody.velocity.z < MaxSpeed)
                _RigidBody.AddForce(Vector3.back * MovementForce);
        }
        else {
            _RigidBody.AddForce(new Vector3(0, 0, _RigidBody.velocity.z * -2));
        }

        if (Input.GetKey("a")) {
            if (_RigidBody.velocity.x > 0)
                _RigidBody.AddForce(Vector3.left * MovementForce * 2);
            else if (_RigidBody.velocity.x > -MaxSpeed)
                _RigidBody.AddForce(Vector3.left * MovementForce);
        }
        else if (Input.GetKey("d")) {
            if (_RigidBody.velocity.x < 0)
                _RigidBody.AddForce(Vector3.right * MovementForce * 2);
            else if (_RigidBody.velocity.x < MaxSpeed)
                _RigidBody.AddForce(Vector3.right * MovementForce);
        }
        else {
            _RigidBody.AddForce(new Vector3(_RigidBody.velocity.x * -2, 0, 0));
        }
        _RigidBody.velocity = new Vector3(Mathf.Clamp(_RigidBody.velocity.x, -MaxSpeed, MaxSpeed), transform.position.y, Mathf.Clamp(_RigidBody.velocity.z, -MaxSpeed, MaxSpeed));
        CurrentXSpeed = _RigidBody.velocity.x;
        CurrentZSpeed = _RigidBody.velocity.z;
    }

    void Rotation() {
        Vector3 MousePos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 MouseHeading = Input.mousePosition - MousePos;

        float Angle = Mathf.Atan2(MouseHeading.x, MouseHeading.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(Angle, Vector3.up), Time.deltaTime * RotationSpeed);
    }
}
