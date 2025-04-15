using UnityEngine;

public class CustomMovementScript : MonoBehaviour
{

    [SerializeField] CharacterController cC;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cC.Move(Vector3.up);

    }
}
