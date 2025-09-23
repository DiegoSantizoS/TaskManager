using System.Xml.Schema;

namespace sMkTaskManager.Classes;

internal class TaskManagerColumn {
    internal string Label;
    internal string Title;
    internal string Tag;
    internal string Group;
    internal int Width;
    internal HorizontalAlignment Align;
    internal bool Fixed;
    internal bool Default;
    internal int Index = 0;
    internal SortOrder SortOrder = SortOrder.None;

    public TaskManagerColumn(string label, string title, string tag, string group, int width, HorizontalAlignment align, bool isFixed, bool isDefault) {
        Label = label;
        Title = title;
        Tag = tag;
        Group = group;
        Width = width;
        Align = align;
        Fixed = isFixed;
        Default = isDefault;
    }
    public TaskManagerColumn(string label, string title, string tag, string group, int width, int align, int isFixed, int isDefault) {
        Label = label;
        Title = title;
        Tag = tag;
        Group = group;
        Width = width;
        Align = (HorizontalAlignment)align;
        Fixed = isFixed != 0;
        Default = isDefault != 0;
    }

    public TaskManagerColumn(string Chunk) {
        if (Chunk.Split(',').Length < 6) return;
        Chunk = Chunk.Trim('|').Trim();
        string[] ChunkValues = Chunk.Split(',');
        Title = ChunkValues[0];
        Tag = ChunkValues[1];
        Width = int.Parse(ChunkValues[2]);
        Align = (HorizontalAlignment)int.Parse(ChunkValues[3]);
        SortOrder = (SortOrder)int.Parse(ChunkValues[4]);
        Index = int.Parse(ChunkValues[5]);
    }
    public TaskManagerColumn(ColumnHeader lvCol) {
        Title = lvCol.Text;
        Tag = lvCol!.Tag!.ToString()!;
        Width = lvCol.Width;
        Align = lvCol.TextAlign;
        Index = lvCol.DisplayIndex;
    }

    public string GetChunk() {
        return $"|{Title},{Tag},{Width},{(int)Align},{(int)SortOrder},{Index}|";
    }

    public static List<TaskManagerColumn> GetColumnDefinition(TaskManagerColumnTypes type) {
        List<TaskManagerColumn> r = new();

        if (type == TaskManagerColumnTypes.Process) {
            r.AddRange(new TaskManagerColumn[] {
            new("ID de Proceso (PID)", "PID", "PID", "Información General", 50, 0, 1, 1),
            new("PID Padre", "Padre", "ParentPID", "Información General", 50, 0, 0, 0),
            new("Nombre del Proceso", "Nombre", "Name", "Información General", 130, 0, 0, 1),
            new("Descripción", "Descripción", "Description", "Información General", 150, 0, 0, 1),
            new("Prioridad Base", "Prioridad", "Priority", "Información General", 60, 0, 0, 1),
            new("Ruta de la Imagen", "Ruta Imagen", "ImagePath", "Información General", 150, 0, 0, 1),
            new("Línea de Comando", "Comando", "CommandLine", "Información General", 150, 0, 0, 0),
            new("Usuario", "Usuario", "Username", "Información General", 90, 0, 0, 1),
            new("ID de Sesión", "Sesión", "SessionID", "Información General", 50, 2, 0, 0),
            new("Afinidad CPU", "Afinidad", "Affinity", "Información General", 50, 2, 0, 0),
            new("Uso de CPU", "CPU", "CpuUsage", "Información General", 40, 2, 0, 1),
            new("Cantidad de Handles", "Handles", "Handles", "Información General", 55, 1, 0, 1),
            new("Cantidad de Hilos", "Hilos", "Threads", "Información General", 55, 1, 0, 1),
            new("Objetos GDI", "Objetos GDI", "GDIObjects", "Información General", 70, 1, 0, 0),
            new("Pico de Objetos GDI", "Pico GDI", "GDIObjectsPeak", "Información General", 65, 1, 0, 0),
            new("Objetos de Usuario", "Objetos Usuario", "UserObjects", "Información General", 75, 1, 0, 0),
            new("Pico de Objetos Usuario", "Pico Usuario", "UserObjectsPeak", "Información General", 70, 1, 0, 0),
            new("Uso de Memoria", "Uso Mem", "WorkingSet", "Memoria", 80, 1, 0, 1),
            new("Pico de Uso de Memoria", "Pico Mem", "WorkingSetPeak", "Memoria", 80, 1, 0, 1),
            new("Memoria Virtual", "Uso vMem", "VirtualMemory", "Memoria", 95, 1, 0, 1),
            new("Pico de Memoria Virtual", "Pico vMem", "VirtualMemoryPeak", "Memoria", 90, 1, 0, 0),
            new("Bytes Privados Virtuales", "Bytes Privados", "PrivateBytes", "Memoria", 75, 1, 0, 0),
            new("Cantidad de Fallos de Página", "Fallos de Página", "PageFaults", "Memoria", 90, 1, 0, 0),
            new("Memoria Paginada", "Memoria PF", "PagedMemory", "Memoria", 90, 1, 0, 1),
            new("Pico de Memoria Paginada", "Pico PF", "PagedMemoryPeak", "Memoria", 90, 1, 0, 0),
            new("Pool Paginado", "Pool Paginado", "PagedPool", "Memoria", 90, 1, 0, 0),
            new("Pico Pool Paginado", "Pico Pool Paginado", "PagedPoolPeak", "Memoria", 90, 1, 0, 0),
            new("Pool No Paginado", "Pool No Paginado", "NonPagedPool", "Memoria", 90, 1, 0, 0),
            new("Pico Pool No Paginado", "Pico No Paginado", "NonPagedPoolPeak", "Memoria", 90, 1, 0, 0),
            new("Tiempo en Ejecución", "Tiempo Ejec.", "RunTime", "Información de Tiempos", 80, 1, 0, 1),
            new("Tiempo de Creación", "Hora Inicio", "CreationTime", "Información de Tiempos", 130, 1, 0, 0),
            new("Tiempo de CPU Usuario", "Tiempo Usuario", "UserTime", "Información de Tiempos", 65, 1, 0, 0),
            new("Tiempo de CPU Núcleo", "Tiempo Núcleo", "KernelTime", "Información de Tiempos", 70, 1, 0, 0),
            new("Tiempo Total de CPU", "Tiempo CPU", "CpuTime", "Información de Tiempos", 65, 1, 0, 0),
            new("Nombre del Producto", "Producto", "ProductName", "Información de Versión", 70, 0, 0, 0),
            new("Versión del Producto", "Versión", "ProductVersion", "Información de Versión", 70, 0, 0, 0),
            new("Compañía", "Compañía", "ProductCompany", "Información de Versión", 70, 0, 0, 0),
            new("Idioma del Producto", "Idioma", "ProductLanguage", "Información de Versión", 70, 0, 0, 0),
            new("Operaciones de Lectura", "Lecturas", "ReadOperations", "Contadores E/S", 90, 1, 0, 0),
            new("Delta de Lecturas", "Lecturas Δ", "ReadOperationsDelta", "Contadores E/S", 90, 1, 0, 0),
            new("Bytes Leídos", "Bytes Leídos", "ReadTransfer", "Contadores E/S", 90, 1, 0, 1),
            new("Delta Bytes Leídos", "Bytes Leídos Δ", "ReadTransferDelta", "Contadores E/S", 90, 1, 0, 0),
            new("Operaciones de Escritura", "Escrituras", "WriteOperations", "Contadores E/S", 90, 1, 0, 0),
            new("Delta Escrituras", "Escrituras Δ", "WriteOperationsDelta", "Contadores E/S", 90, 1, 0, 0),
            new("Bytes Escritos", "Bytes Escritos", "WriteTransfer", "Contadores E/S", 90, 1, 0, 1),
            new("Delta Bytes Escritos", "Bytes Escritos Δ", "WriteTransferDelta", "Contadores E/S", 90, 1, 0, 0),
            new("Otras Operaciones", "Otras Ops", "OtherOperations", "Contadores E/S", 90, 1, 0, 0),
            new("Delta Otras Operaciones", "Otras Ops Δ", "OtherOperationsDelta", "Contadores E/S", 90, 1, 0, 0),
            new("Otros Bytes", "Otros Bytes", "OtherTransfer", "Contadores E/S", 90, 1, 0, 0),
            new("Delta Otros Bytes", "Otros Bytes Δ", "OtherTransferDelta", "Contadores E/S", 90, 1, 0, 0),
            new("Bytes Leídos Disco", "Disco Lectura", "DiskRead", "Disco y Red", 80, 1, 0, 0),
            new("Delta Lectura Disco", "Δ Lectura", "DiskReadDelta", "Disco y Red", 80, 1, 0, 0),
            new("Tasa Lectura Disco", "Tasa Lectura", "DiskReadRate", "Disco y Red", 80, 1, 0, 1),
            new("Bytes Escritos Disco", "Disco Escritura", "DiskWrite", "Disco y Red", 80, 1, 0, 0),
            new("Delta Escritura Disco", "Δ Escritura", "DiskWriteDelta", "Disco y Red", 80, 1, 0, 0),
            new("Tasa Escritura Disco", "Tasa Escritura", "DiskWriteRate", "Disco y Red", 80, 1, 0, 1),
            new("Bytes Enviados Red", "Red Enviados", "NetSent", "Disco y Red", 80, 1, 0, 0),
            new("Delta Enviados Red", "Δ Enviados", "NetSentDelta", "Disco y Red", 80, 1, 0, 0),
            new("Tasa Enviados Red", "Tasa Env.", "NetSentRate", "Disco y Red", 80, 1, 0, 1),
            new("Bytes Recibidos Red", "Red Recibidos", "NetRcvd", "Disco y Red", 80, 1, 0, 0),
            new("Delta Recibidos Red", "Δ Recib.", "NetRcvdDelta", "Disco y Red", 80, 1, 0, 0),
            new("Tasa Recibidos Red", "Tasa Rec.", "NetRcvdRate", "Disco y Red", 80, 1, 0, 1),
            });
            }
            else if (type == TaskManagerColumnTypes.Services)
            {
                r.AddRange(new TaskManagerColumn[] {
            new("Nombre", "Nombre", "Name", "Información General", 180, 0, 1, 1),
            new("Estado", "Estado", "Status", "Información General", 70, 0, 0, 1),
            new("ID de Proceso", "PID", "PID", "Información General", 50, 0, 0, 1),
            new("Descripción", "Descripción", "Description", "Información General", 150, 0, 0, 0),
            new("Modo de Inicio", "Inicio", "Startup", "Información General", 70, 0, 0, 1),
            new("Nombre Interno", "Interno", "Ident", "Información General", 100, 0, 0, 1),
            new("Cuenta de Inicio de Sesión", "Inicia Como", "Logon", "Información General", 80, 0, 0, 1),
            new("Línea de Comando", "Comando", "CommandLine", "Información General", 200, 0, 0, 1),
            });
            }
            else if (type == TaskManagerColumnTypes.Connections)
            {
                r.AddRange(new TaskManagerColumn[] {
            new("ID de Proceso", "PID", "PID", "Información General", 60, 0, 1, 1),
            new("Nombre del Proceso", "Proceso", "ProcessName", "Información General", 80, 0, 0, 1),
            new("Protocolo", "Proto", "Protocol", "Información General", 55, 0, 0, 1),
            new("Dirección Local", "Dirección Local", "LocalAddr", "Información General", 90, 0, 0, 1),
            new("Puerto Local", "Puerto Local", "LocalPort", "Información General", 60, 0, 0, 1),
            new("Dirección Remota", "Dirección Remota", "RemoteAddr", "Información General", 100, 0, 0, 1),
            new("Puerto Remoto", "Puerto Remoto", "RemotePort", "Información General", 60, 0, 0, 1),
            new("Estado de Conexión", "Estado", "StateString", "Información General", 75, 0, 0, 1),
            new("Tiempo de Vida Conexión", "Tiempo Vida", "LifeTime", "Información General", 80, 1, 0, 0),
            new("Total Enviado", "Enviado", "Sent", "Información Transferencia", 65, 1, 0, 1),
            new("Total Recibido", "Recibido", "Received", "Información Transferencia", 65, 1, 0, 1),
            new("Delta Enviado", "Δ Enviado", "SentDelta", "Información Transferencia", 80, 1, 0, 0),
            new("Delta Recibido", "Δ Recibido", "ReceivedDelta", "Información Transferencia", 86, 1, 0, 0),
            new("Tasa Envío", "Tasa Env.", "SentRate", "Información Transferencia", 80, 1, 0, 0),
            new("Tasa Recepción", "Tasa Rec.", "ReceivedRate", "Información Transferencia", 86, 1, 0, 0),
            });
            }
            else if (type == TaskManagerColumnTypes.Ports)
            {
                r.AddRange(new TaskManagerColumn[] {
            new("ID de Proceso", "PID", "PID", "General", 60, 0, 1, 1),
            new("Nombre del Proceso", "Proceso", "ProcessName", "General", 100, 0, 0, 1),
            new("Protocolo", "Proto", "Protocol", "General", 60, 0, 0, 1),
            new("Dirección Local", "Dirección", "LocalAddr", "General", 100, 0, 0, 1),
            new("Puerto Local", "Puerto", "LocalPort", "General", 60, 0, 0, 1),
            new("Estado del Puerto", "Estado", "StateString", "General", 70, 0, 0, 1),
            });
            }
            else if (type == TaskManagerColumnTypes.Users)
            {
                r.AddRange(new TaskManagerColumn[] {
            new("ID de Sesión", "ID", "ID", "General", 60, 0, 1, 1),
            new("Usuario", "Usuario", "Username", "General", 100, 0, 0, 1),
            new("Estado", "Estado", "Status", "General", 100, 0, 0, 1),
            new("Nombre del Cliente", "Cliente", "Client", "General", 100, 0, 0, 1),
            new("Tipo de Sesión", "Sesión", "Session", "General", 100, 0, 0, 1),
            new("Procesos Totales", "Procesos", "TotalProcesses", "General", 70, 1, 0, 1),
            });
            }
            else if (type == TaskManagerColumnTypes.Nics)
            {
                r.AddRange(new TaskManagerColumn[] {
            new ("Nombre del Adaptador", "Nombre", "Name", "General", 120, 0, 1, 1),
            new ("Descripción", "Descripción", "Description", "General", 120, 0, 0, 0),
            new ("Velocidad", "Velocidad", "Speed", "General", 80, 2, 0, 1),
            new ("Estado", "Estado", "State", "General", 60, 2, 0, 1),
            new ("Tipo", "Tipo", "Type", "General", 90, 2, 0, 1),
            new ("Dirección MAC", "MAC", "MacAddress", "General", 90, 1, 0, 0),
            new ("Bytes Recibidos", "Recibidos", "Rcvd", "General", 80, 1, 0, 1),
            new ("Bytes Enviados", "Enviados", "Sent", "General", 80, 1, 0, 1),
            new ("Tasa Recibidos", "Tasa Rec.", "RcvdRate", "General", 80, 1, 0, 1),
            new ("Tasa Enviados", "Tasa Env.", "SentRate", "General", 80, 1, 0, 1),
            new ("Delta Recibidos", "Δ Recib.", "RcvdDelta", "General", 80, 1, 0, 0),
            new ("Delta Enviados", "Δ Env.", "SentDelta", "General", 80, 1, 0, 0),
            });
            }
            else if (type == TaskManagerColumnTypes.GPUs)
            {
                r.AddRange(new TaskManagerColumn[] {
            new ("Nombre del Adaptador", "Nombre", "Name", "General", 200, 0, 1, 1),
            new ("Nodos", "Nodos", "NodeCount", "General", 50, 1, 0, 1),
            new ("Segmentos", "Segmentos", "SegmentCount", "General", 65, 1, 0, 1),
            new ("Uso de Energía", "Energía", "PowerUsage", "General", 65, 1, 0, 1),
            new ("Temperatura", "Temp.", "Temperature", "General", 80, 1, 0, 1),
            new ("Velocidad del Ventilador", "Ventilador", "FanSpeed", "General", 80, 1, 0, 1),
            new ("Memoria Dedicada Total", "Dedicada Total", "DedicatedMemoryTotal", "Memoria", 100, 1, 0, 0),
            new ("Memoria Dedicada Usada", "Dedicada Usada", "DedicatedMemoryUsed", "Memoria", 100, 1, 0, 0),
            new ("Memoria Dedicada Libre", "Dedicada Libre", "DedicatedMemoryFree", "Memoria", 100, 1, 0, 0),
            new ("Uso % Memoria Dedicada", "% Uso Dedicada", "DedicatedMemoryUsage", "Memoria", 100, 1, 0, 0),
            new ("Memoria Compartida Total", "Compartida Total", "SharedMemoryTotal", "Memoria", 100, 1, 0, 0),
            new ("Memoria Compartida Usada", "Compartida Usada", "SharedMemoryUsed", "Memoria", 100, 1, 0, 0),
            new ("Memoria Compartida Libre", "Compartida Libre", "SharedMemoryFree", "Memoria", 100, 1, 0, 0),
            new ("Uso % Memoria Compartida", "% Uso Compartida", "SharedMemoryUsage", "Memoria", 100, 1, 0, 0),
            });
            }
            return r;
        }
    public static string GetDefaultColumnsChunks(TaskManagerColumnTypes Type) {
        System.Text.StringBuilder retValue = new();
        int newIndex = 0;
        foreach (TaskManagerColumn c in GetColumnDefinition(Type).Where(x => x.Default == true)) {
            c.Index = newIndex;
            retValue.AppendLine(c.GetChunk());
            newIndex++;
        }
        return retValue.ToString();
    }
}
public enum TaskManagerColumnTypes : int {
    None = 0,
    Process = 1,
    Services = 2,
    Connections = 3,
    Ports = 4,
    Users = 5,
    Applications = 6,
    Nics = 7,
    GPUs = 8,
}
