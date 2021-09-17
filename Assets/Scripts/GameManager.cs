using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.WebRTC.Unity;

public class GameManager : MonoBehaviour
{
    //public GameObject Dialog = GameObject.Find("DialogController").GetComponent<DialogExampleController>();;
    public GameObject CallController;
    public GameObject PeerObj;
    private Color EndCallRed = Color.red;
    private Color StartCallGreen = Color.green;


    // Start is called before the first frame update
    private void Start()
    {
        this.GetComponent<Microsoft.MixedReality.Toolkit.Examples.Experimental.DialogTest.DialogExampleController>().OpenMenuStart();
    }



// Update is called once per frame
void Update()
    {
        Color myColor = CallController.GetComponent<SpriteRenderer>().color;
        if (myColor == StartCallGreen)
        {
            PeerObj.GetComponentInChildren<PeerConnection>().enabled = true;
            if(PeerObj.GetComponentInChildren<CallButtons>().isOpen==false )
                PeerObj.GetComponentInChildren<CallButtons>().isOpen = true;
        }
        if (myColor == EndCallRed)
        {
            PeerObj.GetComponentInChildren<PeerConnection>().enabled=false;

        }
    }
}
