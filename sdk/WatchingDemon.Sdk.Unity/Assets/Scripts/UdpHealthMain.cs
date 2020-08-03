using System.Collections;
using System.Collections.Generic;
using System.Net;
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

    string targetIp = IPAddress.Loopback.ToString();

    // Start is called before the first frame update
    void Start()
    {
        string[] ipList = new string[1] { targetIp };
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
        api.ShutdownRequest(targetIp);
    }

    public void OnReboot()
    {
        api.RebootRequest(targetIp);
    }

    public void OnStartMonitoring()
    {
        api.MonitoringStart(targetIp);
    }

    public void OnStopMonitoring()
    {
        api.MonitoringStop(targetIp);
    }

    public void OnKillProcess()
    {
        try
        {
            byte id = byte.Parse(killProcessIdField.text);
            api.KillProcess(targetIp, id);
        }
        catch
        {

        }
        
    }
}
