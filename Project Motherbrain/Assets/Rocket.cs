using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rocket : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float TurnSpeed;
    [SerializeField] private float ExplosionForce;

    private Rigidbody _rb;
    private Transform _target;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }

    public void SetTarget(Transform target) => _target = target;

    private void Update()
    {
        Transform transform = this.transform;
        Vector3 position = transform.position;
        Quaternion lookDir = Quaternion.LookRotation(_target.position - position);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookDir, 1 - Mathf.Exp(-TurnSpeed * Time.deltaTime));

        _rb.MovePosition(position + transform.forward * (MoveSpeed * Time.deltaTime));
    }

    private void Explode(PlayerController controller)
    {
        controller.Rigidbody.AddExplosionForce(ExplosionForce, transform.position, 2f, 0.5f);
        Debug.Log("I exploded :D");
        transform.root.gameObject.SetActive(false);
        KillMe();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"I just hit {other.name} :D");

        var player = other.GetComponent<PlayerController>();
        if (player == null)
            return;

        Explode(player);
    }

    void KillMe()
    {
        Destroy(gameObject);
    }
}