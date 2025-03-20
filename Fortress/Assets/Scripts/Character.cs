using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Move))]
public class Character : MonoBehaviourPun
{
    [SerializeField] Move move;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] GameObject remoteCamera;

    private void Awake()
    {
        move = GetComponent<Move>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        DisableCamera();
    }

    private void Update()
    {
        move.OnKeyUpdate();
    }

    private void FixedUpdate()
    {
        move.OnMove(rigidBody);
    }

    public void DisableCamera()
    {
        // ���� �÷��̾ �� �ڽ��̶��?
        if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            remoteCamera.SetActive(false);
        }
    }
  
}
