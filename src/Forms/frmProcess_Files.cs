//Pedro José Gómez Villalobos  0901-23-4868
/*
Este formulario está pensado para mostrar los archivos que
un proceso tiene abiertos, utilizando la clase Process de .NET. 
A través de la propiedad PID, se puede asignar el identificador 
de un proceso, y el formulario queda preparado para cargar la 
información relacionada mediante el método LoadProcessFiles(). 
Además, cuenta con atajos para cerrarse fácilmente, ya sea con 
la tecla Escape o con un botón.
*/
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
namespace sMkTaskManager.Forms;

[DesignerCategory("Component"), SupportedOSPlatform("windows")]
public partial class frmProcess_Files : Form {
    private Process? p = null;

    public frmProcess_Files() {
        InitializeComponent();
        Load += OnLoad;
        KeyPress += OnKeyPress;
    }

    private void OnLoad(object? sender, EventArgs e) {
        LoadProcessFiles();
    }
    private void OnKeyPress(object? sender, KeyPressEventArgs e) {
        if (e.KeyChar == Convert.ToChar(Keys.Escape)) { Close(); }
    }
    private void btnClose_Click(object? sender, EventArgs e) {
        Close();
    }

    public int PID {
        get { return (p == null) ? 0 : p.Id; }
        set { p = Process.GetProcessById(value); if (Visible) { LoadProcessFiles(); } }
    }
    private void LoadProcessFiles() { }
}

