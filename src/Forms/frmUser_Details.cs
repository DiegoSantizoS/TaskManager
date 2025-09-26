//Pedro José Gómez Villalobos    0901-23-4868
/*
Este formulario se encarga de mostrar información detallada 
sobre un usuario de sesión en el sistema, utilizando un objeto 
de la clase TaskManagerUser. A través de la propiedad ID, se 
inicializa el usuario con su identificador, se actualizan sus 
datos y se cargan en la interfaz mediante el método LoadSessionDetails().
En esa carga se muestran múltiples detalles: nombre de usuario,
estado de la sesión, cliente remoto, dirección, resolución de 
pantalla, tiempos de conexión, inicio de sesión, desconexión y 
última interacción, calculando además cuánto tiempo ha pasado 
desde cada evento. El formulario también incluye un botón para 
refrescar la información y otro para cerrarlo.
*/

using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Versioning;
using sMkTaskManager.Classes;
namespace sMkTaskManager.Forms;

[DesignerCategory("Component"), SupportedOSPlatform("windows")]
public partial class frmUser_Details : Form {
    private TaskManagerUser u;

    public frmUser_Details() {
        InitializeComponent();
    }
    private void frmUser_Details_Load(object sender, EventArgs e) {

    }
    private void btnOk_Click(object sender, EventArgs e) {
        Close();
    }
    private void btnRefresh_Click(object sender, EventArgs e) {
        u?.QueryUpdate();
        LoadSessionDetails();
    }

    public string ID {
        get => (u == null) ? "" : u.Ident;
        set {
            if (!string.IsNullOrEmpty(value.Trim()) && value != ID) {
                u = new TaskManagerUser(value);
                u.QueryUpdate();
                LoadSessionDetails();
            }
        }
    }
    private void LoadSessionDetails() {
        if (u == null) return;

        txtUsername.Text = u.User;
        txtSessionID.Text = u.ID;
        txtState.Text = u.Status;
        txtClientName.Text = string.IsNullOrEmpty(u.Client.Trim()) ? "n/a." : u.Client;
        txtClientAddress.Text = string.IsNullOrEmpty(u.Session.Trim()) ? "n/a." : u.Session;

        if (u.ClientAddress != null) txtClientAddress.Text += " - " + u.ClientAddress.ToString();

        if (u.ResolutionHorizontal > 0 || u.ResolutionVertical > 0) {
            txtClientDisplay.Text = u.ResolutionHorizontal + " x " + u.ResolutionVertical + " x " + u.ResolutionColorDeph + "bpp";
        } else {
            txtClientDisplay.Text = "n/a.";
        }

        txtConnectTime.Text = (u.ConnectTimeValue.Year > 1800) ? u.ConnectTime : "n/a.";
        txtConnectAgo.Text = (u.ConnectTimeValue.Year > 1800) ? Shared.TimeDiff(u.ConnectTimeValue.Ticks, 3) + " ago" : "";
        txtLogonTime.Text = (u.LogonTimeValue.Year > 1800) ? u.LogonTime : "n/a.";
        txtLogonAgo.Text = (u.LogonTimeValue.Year > 1800) ? Shared.TimeDiff(u.LogonTimeValue.Ticks, 3) + " ago" : "";
        txtDisconnectTime.Text = (u.DisconnectTimeValue.Year > 1800) ? u.DisconnectTime : "n/a.";
        txtDisconnectAgo.Text = (u.DisconnectTimeValue.Year > 1800) ? Shared.TimeDiff(u.DisconnectTimeValue.Ticks, 3) + " ago" : "";
        txtLastInputTime.Text = (u.LastInputTimeValue.Year > 1800) ? u.LastInputTime : "n/a.";
        txtLastInputAgo.Text = (u.LastInputTimeValue.Year > 1800) ? Shared.TimeDiff(u.LastInputTimeValue.Ticks, 3) + " ago" : "";

    }

}

