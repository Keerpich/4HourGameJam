using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class MoveScript : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = -3.0F;

    Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);

        m_Animator.SetFloat("speed", curSpeed);
    }
}