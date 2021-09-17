using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class SingleUseEvents : MonoBehaviourPun
{
    // Start is called before the first frame update
    private SpriteRenderer _spriteRenderer;
    private const byte COLOR_CHANGE_EVENT =0;
    public bool StartCall=false;
    public bool EndCall=false;
    private float r, g, b;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (base.photonView.IsMine && Input.GetKeyDown(KeyCode.Space) ||StartCall==true || EndCall==true)
            ChangeColor();
    }

    private void OnEnable()// per la ricezione dell'evento !
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }


    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(EventData obj)
    {
        if(obj.Code==COLOR_CHANGE_EVENT)
        {
            //dobbiamo processare l'evento del cambio colore
            object[] datas = (object[])obj.CustomData;
            float r = (float)datas[0];
            float g = (float)datas[1];
            float b = (float)datas[2];
            _spriteRenderer.color = new Color(r, g, b, 1f);
        }
    }

    private void ChangeColor()
    {
        /*
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        */
        if (StartCall)
        {
            r = 0f;
            g = 1f;
            b = 0f;
            _spriteRenderer.color = new Color(r, g, b, 1f);
            StartCall = false;
        }

        if(EndCall)
        {
            r = 1f;
            g = 0f;
            b = 0f;
            _spriteRenderer.color = new Color(r, g, b, 1f);
            EndCall = false;
        }

        object[] datas = new object[] { r, g, b }; // o passare photonView.ViewID per riferirti ad un unico oggetto piuttosto che a tutti quelli cui hai sottoscritto l'evento
        PhotonNetwork.RaiseEvent(COLOR_CHANGE_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendUnreliable);
    }
}
