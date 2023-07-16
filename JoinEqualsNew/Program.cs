// See https://aka.ms/new-console-template for more information
using JoinEqualsNew;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

var gateFromDb = new Gate
{
    Id = 1,
    TerminalSettingId = 1,
    TerminalId = 1,
    GateId = 1,
    GateNumber = 1,

    GateName = "1",

    NumberOfAutolines = 1,
    VehicleUnloadTime = 1,
    MaxVehiclesCount = 1,

    //TerminalTimeslots = new List<TerminalTimeslot> { }
};

// fromDBId   fromRequestId
// 1 (1)       1  (1)
// 2 (2)       22 (2)
// 3 (3)       -  (3)
// - (4)       4  (4)

var terminalTimeslot1FromDB = new TerminalTimeslot
{
    Id = 1,
    Date = DateTime.Now,
    DateCreated = DateTime.Now,
    DateUpdated = DateTime.Now,
    EndTime = DateTime.Now.ToString(),
    FreeVehiclesCount = 10,
    TerminalGateId = 1,
    InactiveVehiclesCount = 1,
    StartTime = DateTime.Now.ToString(),
    TerminalGate = gateFromDb,
    TerminalSettingId = 1,
    TimeslotNumber = 1
};

var terminalTimeslot1FromRequest = new TerminalTimeslot
{
    Id = 1,
    Date = DateTime.Now,
    DateCreated = DateTime.Now,
    DateUpdated = DateTime.Now,
    EndTime = DateTime.Now.ToString(),
    FreeVehiclesCount = 10,
    TerminalGateId = 1,
    InactiveVehiclesCount = 1,
    StartTime = DateTime.Now.ToString(),
    TerminalGate = gateFromDb,
    TerminalSettingId = 1,
    TimeslotNumber = 1
};

var terminalTimeslot2FromDB = new TerminalTimeslot
{
    Id = 2,
    Date = DateTime.Now,
    DateCreated = DateTime.Now,
    DateUpdated = DateTime.Now,
    EndTime = DateTime.Now.ToString(),
    FreeVehiclesCount = 10,
    TerminalGateId = 1,
    InactiveVehiclesCount = 1,
    StartTime = DateTime.Now.ToString(),
    TerminalGate = gateFromDb,
    TerminalSettingId = 1,
    TimeslotNumber = 2
};

var terminalTimeslot2FromRequest = new TerminalTimeslot
{
    Id = 22,
    Date = DateTime.Now,
    DateCreated = DateTime.Now,
    DateUpdated = DateTime.Now,
    EndTime = DateTime.Now.ToString(),
    FreeVehiclesCount = 10,
    TerminalGateId = 1,
    InactiveVehiclesCount = 1,
    StartTime = DateTime.Now.ToString(),
    TerminalGate = gateFromDb,
    TerminalSettingId = 1,
    TimeslotNumber = 2
};

var terminalTimeslot3FromDB = new TerminalTimeslot
{
    Id = 3,
    Date = DateTime.Now,
    DateCreated = DateTime.Now,
    DateUpdated = DateTime.Now,
    EndTime = DateTime.Now.ToString(),
    FreeVehiclesCount = 10,
    TerminalGateId = 1,
    InactiveVehiclesCount = 1,
    StartTime = DateTime.Now.ToString(),
    TerminalGate = gateFromDb,
    TerminalSettingId = 1,
    TimeslotNumber = 3
};

var terminalTimeslot4FromRequest = new TerminalTimeslot
{
    Id = 4,
    Date = DateTime.Now,
    DateCreated = DateTime.Now,
    DateUpdated = DateTime.Now,
    EndTime = DateTime.Now.ToString(),
    FreeVehiclesCount = 10,
    TerminalGateId = 1,
    InactiveVehiclesCount = 1,
    StartTime = DateTime.Now.ToString(),
    TerminalGate = gateFromDb,
    TerminalSettingId = 1,
    TimeslotNumber = 4
};

var terminalTimeslotsFromDB = new List<TerminalTimeslot> { terminalTimeslot1FromDB, terminalTimeslot2FromDB, terminalTimeslot3FromDB };
var terminalTimeslotsFromRequest = new List<TerminalTimeslot> { terminalTimeslot1FromRequest, terminalTimeslot2FromRequest, terminalTimeslot4FromRequest };

gateFromDb.TerminalTimeslots = terminalTimeslotsFromDB;



var terminalTimeslots = LinqHelper.UpdateTerminalTimeslotsParametersFromDB(gateFromDb, terminalTimeslotsFromRequest);

terminalTimeslots.ForEach(t => Console.WriteLine(t));

//1, 16.07.2023, 1(1)
//1, 16.07.2023, 2(22)
//1, 16.07.2023, 3(3)

Console.ReadKey();
