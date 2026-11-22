
using LabW11.Sensors;
using LabW11.Models;
using LabW11.Observers;
using LabW11.Emergency;
using LabW11.Devices;

// 1. Tao cam bien cu
var legacy = new LegacySmokeDetector(735);

// 2. Tao Adapter
ISensor sensor = new SmokeSensorAdapter(legacy);

// 3. Tao cac thiet bi
var alarm = new Alarm();
var door = new DoorController();
var ventilation = new VentilationController();

// 4. Tao Mediator
IEmergencyMediator mediator =
    new EmergencyMediator(
        alarm,
        door,
        ventilation
    );

// 5. Tao SensorMonitor
var monitor = new SensorMonitor();

// 6. Dang ky cac Observer
monitor.Attach(new DashboardObserver());
monitor.Attach(new EmailAlertObserver());
monitor.Attach(new AuditLogObserver());

monitor.Attach(
    new EmergencyBridgeObserver(mediator)
);

// 7. Kiem tra cam bien
Console.WriteLine("================================");
Console.WriteLine("       CAMPUS SAFETY HUB");
Console.WriteLine("================================");

Console.WriteLine("\nTEST 1: NORMAL");
legacy.SetSmokeLevel(350);
monitor.CheckSensor("Smoke Sensor", sensor);

Console.WriteLine("\nTEST 2: WARNING");
legacy.SetSmokeLevel(550);
monitor.CheckSensor("Smoke Sensor", sensor);

Console.WriteLine("\nTEST 3: CRITICAL");
legacy.SetSmokeLevel(735);
monitor.CheckSensor("Smoke Sensor", sensor);

Console.WriteLine("\nProgram finished.");
