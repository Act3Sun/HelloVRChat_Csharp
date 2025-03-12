using System;
using System.Threading;
using System.Runtime;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Rug.Osc;
using Rug.Osc.Core;
namespace HelloVRChat_Csharp;

public partial class Form1 : Form
{
    private OscSender OscS ;
    public Form1()
    {
        InitializeComponent();
        SendMsg();
    }
    private void SendMsg ()
    {
        // ホスト名を取得
        string hostName = Dns.GetHostName();

        // ホスト名からIPアドレスを取得
            IPAddress address = IPAddress.Parse("127.0.0.1");
            int PortNo = 9000;

            OscS = new OscSender(address,0,PortNo);
            OscS.Connect();
            OscS.Send(new OscMessage("/chatbox/input","Hello, world!"));
    }
   private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        // アプリケーションが終了する前にOSCセンダーを閉じる
        OscS.Close();
    }
}
