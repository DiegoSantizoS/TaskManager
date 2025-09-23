namespace sMkTaskManager.Classes;



// DIEGO FERNANDO SANTIZO SAMAYOA 0901-22-15950

/*
    La clase TaskManagerValuesBase funciona como una clase base destinada a la gestión de métricas del sistema.  
    Su objetivo principal es centralizar el manejo de eventos asociados a los objetos Metric, que representan valores 
    dinámicos como uso de CPU, memoria, GPU o red.  

    Durante su construcción, la clase detecta automáticamente todas las propiedades del tipo Metric declaradas en 
    sus clases derivadas y adjunta manejadores de eventos, garantizando que cualquier cambio en los valores, 
    variaciones (delta) o actualizaciones generales sea notificado de manera uniforme.  

    Este diseño permite que los módulos especializados (TaskManagerProcess, TaskManagerGPU, TaskManagerNetwork, 
    entre otros) hereden una estructura común para actualizar métricas y enviar notificaciones a la interfaz de usuario, 
    facilitando así la sincronización en tiempo real entre la información obtenida a nivel del sistema y su representación 
    visual en las pestañas correspondientes.  

    Además, incorpora mecanismos de control como la supresión temporal de eventos (CancellingEvents) y el registro 
    del último ciclo de actualización (LastUpdate), que proporcionan flexibilidad y evitan sobrecargar la aplicación 
    con notificaciones excesivas.
*/



internal class TaskManagerValuesBase {

    public class TaskManagerMetricChangedEventArgs {
        public TaskManagerMetricChangedEventArgs(Metric metric, MetricChangedEventArgs e) {
            this.metric = metric;
            this.e = e;
        }
        public Metric metric { get; set; }
        public MetricChangedEventArgs e { get; set; }
    }

    public TaskManagerValuesBase() {
        // Attach the event handlers for all the Metrics discovered
        var properties = GetType().GetProperties().Where(p => p.PropertyType == typeof(Metric));
        foreach (var p in properties) {
            var metric = (Metric)p.GetValue(this)!;
            metric.AnyChanged += OnMetricChanged;
            metric.ValueChanged += OnMetricValueChanged;
            metric.DeltaChanged += OnMetricDeltaChanged;
        }
    }

    protected void OnMetricChanged(Metric sender, MetricChangedEventArgs e) { if (!CancellingEvents) MetricChanged?.Invoke(this, sender, e); }
    protected void OnMetricValueChanged(Metric sender, MetricChangedEventArgs e) { if (!CancellingEvents) MetricValueChanged?.Invoke(this, sender, e); }
    protected void OnMetricDeltaChanged(Metric sender, MetricChangedEventArgs e) { if (!CancellingEvents) MetricDeltaChanged?.Invoke(this, sender, e); }
    public event MetricEventHandler? MetricChanged;
    public event MetricEventHandler? MetricValueChanged;
    public event MetricEventHandler? MetricDeltaChanged;
    public delegate void MetricEventHandler(object sender, Metric metric, MetricChangedEventArgs e);

    public void SetValue(Metric m, Int128 newValue) => m.SetValue(newValue);
    public bool CancellingEvents = false;
    public long LastUpdate = 0;
}
