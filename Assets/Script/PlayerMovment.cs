using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float m_movementSpeed;
    [SerializeField] private float m_rotationSpeed;

    private Vector2 m_movementsInputs;
    private Rigidbody m_Rigidbody;
    private bool m_isMoving;
    private Vector3 m_vitesse;
    private Transform m_rotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (m_isMoving)
        {
            m_vitesse = new Vector3(m_movementsInputs.y, 0, 0);

            transform.Rotate(0, m_movementsInputs.x, 0);

            m_Rigidbody.linearVelocity = transform.localRotation * m_vitesse * m_movementSpeed;

            
        }
        else
        {
            m_Rigidbody.linearVelocity = Vector3.zero;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        m_movementsInputs = context.ReadValue<Vector2>();

        m_isMoving = m_movementsInputs != Vector2.zero;
    }
}
