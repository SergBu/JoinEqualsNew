using JoinEqualsNew;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JoinEqualsNew
{
    /// <summary>
    /// Временной Интервал Терминала
    /// </summary>
    public class TerminalTimeslot //: TerminalSettingBase, ITerminalTimeslot, ITerminalGate
    {
        public TerminalTimeslot()
        {
            //TimeslotStatus = Status.Present;
            //TimeslotType = TimeslotType.Working;
            //ActiveState = ActiveState.Active;
        }

        public Gate TerminalGate { get; set; }

        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public int TerminalSettingId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int TerminalTimeslotId
        {
            get => Id;
            set => Id = value;
        }

        [NotMapped]
        [JsonIgnore]
        public int GateId
        {
            get => TerminalGateId;
            set => TerminalGateId = value;
        }

        [JsonIgnore]
        public int TerminalGateId { get; set; }

        //[JsonConverter(typeof(DateConverter))]
        [JsonIgnore]
        public DateTime Date { get; set; }

        public int TimeslotNumber { get; set; }

        //[NotMapped]
        //[JsonIgnore]
        //public TimeslotType TimeslotTypeCode { get; set; }

        //[JsonConverter(typeof(StringEnumConverter))]
        //[JsonIgnore]
        //public TimeslotType TimeslotType
        //{
        //    get => TimeslotTypeCode;
        //    set => TimeslotTypeCode = value;
        //}

        //[NotMapped]
        //[JsonIgnore]
        //public Status TimeslotStatusCode { get; set; }

        //[NotMapped]
        //[JsonConverter(typeof(StringEnumConverter))]
        //public Status TimeslotStatus
        //{
        //    get => TimeslotStatusCode;
        //    set => TimeslotStatusCode = value;
        //}

        //[JsonConverter(typeof(StringEnumConverter))]
        //public ActiveState ActiveState { get; set; }

        [NotMapped]
        public string StartTime { get; set; }

        [NotMapped]
        public string EndTime { get; set; }

        [NotMapped]
        public DateTime StartDateTime => Date.Add(TimeSpan.Parse(StartTime));

        //[JsonIgnore]
        //public virtual TerminalGate TerminalGate { get; set; }

        //public virtual List<TerminalTimeslotMemberPermission> MemberPermissions { get; set; } = new List<TerminalTimeslotMemberPermission>();
        //public virtual List<TerminalTimeslotCropPermission> CropPermissions { get; set; } = new List<TerminalTimeslotCropPermission>();
        //public virtual List<TerminalTimeslotReservation> Reservations { get; set; } = new List<TerminalTimeslotReservation>();
        //public virtual ICollection<TerminalTimeslotVehicle> Vehicles { get; set; }

        public string TerminalTimeslotVehiclesArrivedJson { get; set; }

        public string TerminalTimeslotVehiclesLeavingJson { get; set; }

        //public bool ShouldSerializeMemberPermissions() => MemberPermissions?.Count > 0;
        //public bool ShouldSerializeCropPermissions() => CropPermissions?.Count > 0;
        //public bool ShouldSerializeReservations() => Reservations?.Count > 0;
        //public bool ShouldSerializeVehicles() => Vehicles?.Count > 0;
        //public bool ShouldSerializeVehiclesCount() => VehiclesCount > 0;
        //	public bool ShouldSerializeFreeVehiclesCount() => FreeVehiclesCount > 0;
        //public bool ShouldSerializeLeftVehiclesCount() => LeftVehiclesCount > 0;

        //[JsonIgnore]
        //public virtual TerminalSetting TerminalSetting { get; set; }

        //[JsonIgnore]
        //public int? TerminalId => TerminalSetting?.TerminalId;

        //[JsonIgnore]
        //public int? TimeslotDuration => TerminalSetting?.TimeslotDuration;

        //[JsonIgnore]
        //public int MaxVehiclesCount => TerminalSetting?.MaxVehiclesCount ?? 0;

        //[JsonIgnore]
        //public bool? CarrierDeleteAvailable => TerminalSetting?.CarrierDeleteAvailable;

        //[JsonIgnore]
        //public bool? DriverDeleteAvailable => TerminalSetting?.DriverDeleteAvailable;

        [JsonIgnore]
        [NotMapped]
        public bool? CarrierEditAvailable => false;

        //[JsonIgnore]
        //[NotMapped]
        //public bool? DriverEditAvailable
        //{
        //    get
        //    {
        //        if (TerminalSetting != null)
        //        {
        //            switch (TerminalSetting.ChangeOfDataByDriverType)
        //            {
        //                case ChangeOfDataByDriver.No:
        //                    return false;
        //                case ChangeOfDataByDriver.YesWithoutTime:
        //                    return true;
        //                case ChangeOfDataByDriver.YesTimeSelected:
        //                    {
        //                        if (TerminalSetting.ChangeOfDataByDriverTime.HasValue)
        //                        {
        //                            return DateTime.UtcNow <= DateCreated.AddMinutes(TerminalSetting.ChangeOfDataByDriverTime.Value);
        //                        }
        //                    }
        //                    break;
        //            }
        //        }
        //        return false;
        //    }
        //}

        //[NotMapped]
        //public int VehiclesCount => (Vehicles?.Count ?? 0) + (Reservations?.Sum(r => r.MaxVehiclesCount) ?? 0);

        [NotMapped]
        public int FreeVehiclesCount { get; set; }

        public int DistributedMaxVehicleCount { get; set; }

        //[NotMapped]
        //public int LeftVehiclesCount => DistributedMaxVehicleCount - (VehiclesCount - Deleted);

        [NotMapped]
        public int Deleted { get; set; }

        [NotMapped]
        [JsonIgnore]
        public int InactiveVehiclesCount { get; set; }

        //[JsonIgnore]
        //public string Info => $"{TerminalId}, {TimeslotNumber}, {Date:dd.MM.yyyy}";

        [JsonIgnore]
        public string DateTimeInfo => $"{Date:dd.MM.yyyy} {StartTime} - {EndTime}";

        [JsonIgnore]
        [Required]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        [Required]
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Сравнение Временных Интервалов
        /// </summary>
        public override bool Equals(object o)
        {
            switch (o)
            {
                case TerminalTimeslot m:
                    return this.TerminalSettingId.Equals(m.TerminalSettingId)
                           && this.TimeslotNumber.Equals(m.TimeslotNumber)
                           && this.Date.Date.Equals(m.Date.Date)
                           && this.GateId.Equals(m.GateId);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }

        public override string ToString()
        {
            return $"{TerminalGateId}, {Date:dd.MM.yyyy}, {TimeslotNumber} ({Id})";
        }
    }
}