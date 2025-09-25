/* JUAN JESÚS MENDOZA MONTEJO 0901-23-6357
Este código define la clase frmSystem, que representa una ventana de diálogo 
modal (FixedDialog) en una aplicación de Windows Forms. El formulario contiene
un control de pestañas personalizado (tabSystem) que ocupa la mayor parte del área,
junto con dos botones estándar, "OK" y "Cancel", anclados en la parte inferior. 
La ventana está configurada para no ser redimensionable y para centrarse sobre su
ventana padre al abrirse. Su funcionalidad principal se activa en el evento OnLoad,
donde se llama al método Refresher del control de pestañas, lo que indica que esta 
ventana actúa como un contenedor para mostrar y actualizar información del sistema 
contenida en dicho control.
*/


using System.ComponentModel;
using System.Runtime.Versioning;
namespace sMkTaskManager.Forms;

[DesignerCategory("Component"), SupportedOSPlatform("windows")]
public class frmSystem : Form {
    private tabSystem ts;
    private Button btnOk;
    private Button btnCancel;

    public frmSystem() {
        InitializeComponent();
        btnOk!.Click += (o,e) => Close();
        btnCancel!.Click += (o,e) => Close();
    }

    private readonly IContainer? components = null;
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) { components.Dispose(); }
        base.Dispose(disposing);
    }
    private void InitializeComponent() {
        btnCancel = new Button();
        ts = new tabSystem();
        btnOk = new Button();
        SuspendLayout();
        // 
        // btnCancel
        // 
        btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnCancel.Location = new Point(371, 470);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 23);
        btnCancel.TabIndex = 2;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        // 
        // ts
        // 
        ts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        ts.BorderStyle = Border3DStyle.RaisedInner;
        ts.Description = "System Properties";
        ts.Location = new Point(10, 10);
        ts.Name = "ts";
        ts.Padding = new Padding(2, 10, 10, 2);
        ts.Size = new Size(436, 452);
        ts.TabIndex = 0;
        ts.TabStop = false;
        ts.Title = "System";
        // 
        // btnOk
        // 
        btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnOk.Location = new Point(290, 470);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(75, 23);
        btnOk.TabIndex = 1;
        btnOk.Text = "OK";
        btnOk.UseVisualStyleBackColor = true;
        // 
        // frmSystem
        // 
        AcceptButton = btnOk;
        CancelButton = btnCancel;
        ClientSize = new Size(454, 501);
        Controls.Add(ts);
        Controls.Add(btnOk);
        Controls.Add(btnCancel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        HelpButton = true;
        KeyPreview = true;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "frmSystem";
        SizeGripStyle = SizeGripStyle.Hide;
        StartPosition = FormStartPosition.CenterParent;
        Text = "System Properties - Feeling Nostalgic?";
        Load += OnLoad;
        ResumeLayout(false);
    }

    private void OnLoad(object? sender, EventArgs e) {
        ts.Refresher(true);
    }
}

