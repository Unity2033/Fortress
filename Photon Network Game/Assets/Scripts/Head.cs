using Photon.Pun;
using UnityEngine;

public class Head : MonoBehaviourPunCallbacks
{
    [SerializeField] float speed;
    [SerializeField] float mouseX;

    void Update()
    {
        if (photonView.IsMine == false) return;

        RotateX();
    }

    public void RotateX()
    {
        // mouseX�� ���콺�� �Է��� ���� �����մϴ�.
        mouseX += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;

        // mouseX�� ���� -65 ~ 65 ������ ������ �����մϴ�.
        mouseX = Mathf.Clamp(mouseX, -65, 65);

        transform.localEulerAngles = new Vector3(-mouseX, 0, 0);
    }
}
