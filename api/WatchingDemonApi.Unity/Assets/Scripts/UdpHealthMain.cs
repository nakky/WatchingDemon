using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using WatchingDemonApi;

public class UdpHealthMain : MonoBehaviour
{
    [SerializeField]
    InputField killProcessIdField;

    UdpHealthPulse healthPulse = new UdpHealthPulse(1);

    PacketTriggerApi api = new PacketTriggerApi();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnShutDown()
    {
        api.ShutdownRequest();
    }

    public void OnReboot()
    {
        api.RebootRequest();
    }

    public void OnStartMonitoring()
    {
        api.MonitoringStart();
    }

    public void OnStopMonitoring()
    {
        api.MonitoringStop();
    }

    public void OnKillProcess()
    {
        try
        {
            byte id = byte.Parse(killProcessIdField.text);
            api.KillProcess(id);
        }
        catch
        {

        }
        
    }
}
