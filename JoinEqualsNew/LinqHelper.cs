using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JoinEqualsNew
{
    internal class LinqHelper
    {
        public static List<TerminalTimeslot> UpdateTerminalTimeslotsParametersFromDB(Gate gate,
            List<TerminalTimeslot> terminalTimeslots)
        {
            var updatedTerminalTimeslots = (from a in gate.TerminalTimeslots
                                            join b in terminalTimeslots on new { a.TimeslotNumber, a.TerminalGate.Id } equals new
                                            { b.TimeslotNumber, b.TerminalGate.Id } into g
                                            from c in g.DefaultIfEmpty()
                                            select new TerminalTimeslot
                                            {
                                                Id = (c != null) ? c.Id : a.Id, //?????
                                                //ActiveState = (c != null) ? c.ActiveState : a.ActiveState,
                                                //TerminalSetting = (c != null) ? c.TerminalSetting : a.TerminalSetting,
                                                //CropPermissions = (c != null) ? c.CropPermissions : a.CropPermissions,
                                                //MemberPermissions = (c != null) ? c.MemberPermissions : a.MemberPermissions,
                                                //Reservations = (c != null)
                                                //    ? (c.Reservations.Where(x =>
                                                //        x.ReservationType != ReservationType.None &&
                                                //        x.ModelState != ModelState.Deleted).ToList())
                                                //    : a.Reservations,
                                                //Vehicles = (c != null) ? c.Vehicles : a.Vehicles,
                                                Date = a.Date,
                                                DateCreated = a.DateCreated,
                                                DateUpdated = a.DateUpdated,
                                                EndTime = a.EndTime,
                                                FreeVehiclesCount = a.FreeVehiclesCount,
                                                TerminalGateId = a.TerminalGateId,
                                                InactiveVehiclesCount = a.InactiveVehiclesCount,
                                                StartTime = a.StartTime,
                                                TerminalGate = a.TerminalGate,
                                                TerminalSettingId = a.TerminalSettingId,
                                                TimeslotNumber = a.TimeslotNumber,
                                                //TimeslotStatusCode = a.TimeslotStatusCode,
                                                //TimeslotTypeCode = a.TimeslotTypeCode,
                                            }).ToList();
            return updatedTerminalTimeslots;
        }
    }
}
