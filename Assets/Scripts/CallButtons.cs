using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Concurrent;
using System.Text;
using System.Runtime.CompilerServices;
using Microsoft.MixedReality.WebRTC.Unity;

public class CallButtons : MonoBehaviour
{
    public bool isOpen = false;
    public GameObject PeerObj;
    public GameObject CallController;
    private int counter=0;

    public void StartCall()
    {

        /*bool checkComponentEnabled = gameObject.GetComponentInChildren<PeerConnection>().enabled;
        //var x = gameObject.GetComponent<PeerConnection>().Peer;
        if (checkComponentEnabled == false)
        {
            Debug.Log("checkcomponent è false");
            PeerConnection component = gameObject.GetComponentInChildren<PeerConnection>();
            component.enabled = true;
            return;
        }
        if (isOpen == false)
        {
            Debug.Log("isopen è false");
            PeerConnection startConnection = gameObject.GetComponentInChildren<PeerConnection>();
            startConnection.StartConnection();
            isOpen = true;
        }
        if(isOpen && checkComponentEnabled == true)
        {
            Debug.Log("close call before making a new one");
        }
        */

        /*
        PeerObj = GameObject.Find("PeerConnection");
        if (isOpen==false )
        {
            if (PeerObj == null)
            {
                Instantiate(PeerObj, new Vector3(0, 0, 0), Quaternion.identity);
            }
            PeerConnection startConnection = gameObject.GetComponentInChildren<PeerConnection>();
            startConnection.StartConnection();
            isOpen = true;
            CallController.GetComponent<SingleUseEvents>().StartCall = true;
        }
        */

        Debug.Log("sono in startcall");
        if (isOpen == false || counter==1)
        {
            Debug.Log("isopen è false");
            PeerConnection startConnection = gameObject.GetComponentInChildren<PeerConnection>();
            startConnection.StartConnection();
            isOpen = true;
            CallController.GetComponent<SingleUseEvents>().StartCall = true;
            counter = 0;
            return;
        }
        if (isOpen && gameObject.GetComponentInChildren<PeerConnection>().enabled==true)
        {
            Debug.Log("close call before making a new one");
            counter++;
        }
        else
        {
            //PeerConnection component = gameObject.GetComponentInChildren<PeerConnection>();
            CallController.GetComponent<SingleUseEvents>().StartCall = true;
            counter++;
            //component.enabled = true;
            
        }

    }

    public void EndCall()
    {
        if (isOpen && gameObject.GetComponentInChildren<PeerConnection>().enabled == true)
        {
            //PeerConnection component = gameObject.GetComponentInChildren<PeerConnection>();
            CallController.GetComponent<SingleUseEvents>().EndCall = true;
            //component.enabled = false;
        }

        /*PeerObj= GameObject.Find("PeerConnection");
        if (isOpen)
        {
            Destroy(PeerObj);
            isOpen = false;
            CallController.GetComponent<SingleUseEvents>().EndCall = true;
        }*/
        /*
        bool checkComponentEnabled = gameObject.GetComponentInChildren<PeerConnection>().enabled;
        var x = gameObject.GetComponent<PeerConnection>().Peer;
        if (isOpen && x.IsConnected && checkComponentEnabled==true)
        {
            PeerConnection component = gameObject.GetComponentInChildren<PeerConnection>();
            component.enabled = false;
        }
        */


    }

}
