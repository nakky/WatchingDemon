using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using WatchingDemon.Sdk;

public class UdpHealthMain : MonoBehaviour
{
    [SerializeField]
    InputField killProcessIdField;

    [SerializeField]
    Text textStatus;

    UdpHealthPulse healthPulse = new UdpHealthPulse(1);

    PacketTriggerApi api = new PacketTriggerApi();

    RemoteMonitor monitor;
    RemoteNode node;

    float elapsed;

    // Start is called before the first frame update
    void Start()
    {
        string[] ipList = new string[1] { "127.0.0.1" };
        monitor = new RemoteMonitor(ipList);
        node = monitor.GetNode(ipList[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        elapsed += Time.deltaTime;
        if(elapsed >= 1.0f)
        {
            textStatus.text = "Status:" + node.Status;
            elapsed = 0.0f;
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
