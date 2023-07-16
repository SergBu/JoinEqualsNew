using JoinEqualsNew;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JoinEqualsNew
{
    public class Gate
    {
        public Gate()
        {
            TerminalTimeslots = new List<TerminalTimeslot>();
        }

        [JsonIgnore]
        public int TerminalSettingId { get; set; }

        public int Id { get; set; }
        public int TerminalId { get; set; }

        public int GateId { get; set; }

        [Required]
        public int GateNumber { get; set; }

        public string GateName { get; set; }

        //[JsonIgnore]
        //public TerminalState TerminalStateCode { get; set; }

        //[JsonConverter(typeof(StringEnumConverter))]
        //public TerminalState TerminalState
        //{
        //    get => TerminalStateCode;
        //    set => TerminalStateCode = value;
        //}

        public int NumberOfAutolines { get; set; }
        public int VehicleUnloadTime { get; set; }
        public int MaxVehiclesCount { get; set; }

        public ICollection<TerminalTimeslot> TerminalTimeslots { get; set; }

        /// <summary>
        /// Сравнение Групп Автоприёмов
        /// </summary>
        public override bool Equals(object o)
        {
            switch (o)
            {
                case Gate m:
                    return this.GateNumber.Equals(m.GateNumber)
                           && this.VehicleUnloadTime.Equals(m.VehicleUnloadTime)
                           && this.MaxVehiclesCount.Equals(m.MaxVehiclesCount);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }

        public override string ToString()
        {
            return $"{GateNumber} ({VehicleUnloadTime}) ({MaxVehiclesCount})";
        }
    }
}