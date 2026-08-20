using LibreHardwareMonitor.PawnIo;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
namespace Temp_Watcher.Api;

public class TrayApplicationContext : ApplicationContext
{
    private readonly NotifyIcon _trayIcon;
    private readonly Func<Task> _onExit;

    public TrayApplicationContext(Func<Task> onExit, int port)
    {
        _onExit = onExit;

        var ip = GetLocalIPAddress();
        var address = $"http://{ip}:{port}";

        var contextMenu = new ContextMenuStrip();
        contextMenu.Items.Add(address).Enabled = false;

        contextMenu.Items.Add(new ToolStripSeparator());

        contextMenu.Items.Add(
            PawnIo.IsInstalled
                ? $"PawnIO installed ({PawnIo.Version})"
                : "PawnIO required"
        ).Enabled = false;

        contextMenu.Items.Add(new ToolStripSeparator());

        contextMenu.Items.Add("Exit", null, OnExitClicked);

        _trayIcon = new NotifyIcon
        {
            Icon = new Icon(
                Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("Temp_Watcher.Api.Assets.tempwatcher.ico")!
            ),
            Visible = true,
            Text = "Temp Watcher API",
            ContextMenuStrip = contextMenu
        };

        _ = ShowStartupNotificationsAsync(ip, port);
    }

    private async Task ShowStartupNotificationsAsync(string ip, int port)
    {
        _trayIcon.ShowBalloonTip(
            2000,
            "Temp Watcher API running",
            $"Connect at http://{ip}:{port}",
            ToolTipIcon.Info);

        if (!PawnIo.IsInstalled)
        {
            await Task.Delay(3000);

            _trayIcon.ShowBalloonTip(
                5000,
                "PawnIO required",
                "PawnIO is not installed. Some hardware sensors will not be available.",
                ToolTipIcon.Warning);
        }
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