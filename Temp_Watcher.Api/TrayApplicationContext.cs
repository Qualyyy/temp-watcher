using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Temp_Watcher.Api;

public class TrayApplicationContext : ApplicationContext
{
    private readonly NotifyIcon _trayIcon;
    private readonly Func<Task> _onExit;

    public TrayApplicationContext(Func<Task> onExit, int port)
    {
        _onExit = onExit;

        var ip = GetLocalIPAddress();

        var contextMenu = new ContextMenuStrip();
        contextMenu.Items.Add($"http://{ip}:{port}").Enabled = false;
        contextMenu.Items.Add(new ToolStripSeparator());
        contextMenu.Items.Add("PawnIO required").Enabled = false;
        contextMenu.Items.Add(new ToolStripSeparator());
        contextMenu.Items.Add("Exit", null, OnExitClicked);

        _trayIcon = new NotifyIcon
        {
            Icon = SystemIcons.Application,
            Visible = true,
            Text = "Temp Watcher API",
            ContextMenuStrip = contextMenu
        };

        _trayIcon.ShowBalloonTip(2000, "Temp Watcher API running",
            $"Connect at http://{ip}:{port}", ToolTipIcon.Info);
    }

    private async void OnExitClicked(object? sender, EventArgs e)
    {
        _trayIcon.Visible = false;
        await _onExit();
        Application.Exit();
    }

    private static string GetLocalIPAddress()
    {
        try
        {
            using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Connect("8.8.8.8", 65530); // no actual packet sent, just resolves routing
            return ((IPEndPoint)socket.LocalEndPoint).Address.ToString();
        }
        catch
        {
            return "127.0.0.1";
        }
    }
}