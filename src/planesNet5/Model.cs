using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planesNet5
{
    public enum MessageType
    {
        //SELECTION_CHANGE, NEW_ID, NEW_AIRCRAFT, STATUS_CHANGE, and CLK indicate changes in the state of the SBS-1 software and aren't typically used by other systems.
        //TRANSMISSION messages contain information sent by aircraft.

        SEL,
        ID,
        AIR,
        STA,
        CLK,
        MSG
    }
    public enum TransmissionType
    {
        //Only ES_SURFACE_POS and ES_AIRBORNE_POS transmissions will have position (latitude and longitude) information
        ES_IDENT_AND_CATEGORY,
        ES_SURFACE_POS,
        ES_AIRBORNE_POS,
        ES_AIRBORNE_VEL,
        SURVEILLANCE_ALT,
        SURVEILLANCE_ID,
        AIR_TO_AIR,
        ALL_CALL_REPLY
    }
    public class planeInfo
    {
        public MessageType messageType { get; set; }
        public TransmissionType transmissiontype { get; set; }
        public string sessionId { get; set; }
        public string aircraftId { get; set; }
        public string hexIdent { get; set; }
        public string flightId { get; set; }
        public string generatedDate { get; set; }
        public string generatedTime { get; set; }
        public string loggedDate { get; set; }
        public string loggedTime { get; set; }
        public string callSign { get; set; }
        public int? altitude { get; set; }
        public int? groundSpeed { get; set; }
        public int? track { get; set; }
        public float? lat { get; set; }
        public float? lon { get; set; }
        public int? verticalRate { get; set; }
        public string squawk { get; set; }
        public bool alert { get; set; }
        public bool emergency { get; set; }
        public bool spi { get; set; }
        public bool isOnGround { get; set; }
        public planeInfo(string[] response)
        {
            messageType = (MessageType)System.Enum.Parse(typeof(MessageType), response[0]);
            transmissiontype = (TransmissionType)System.Enum.Parse(typeof(TransmissionType), response[1]);
            sessionId = response[2];
            aircraftId = response[3];
            hexIdent = response[4];
            flightId = response[5];
            generatedDate = response[6];
            generatedTime = response[7];
            loggedDate = response[8];
            loggedTime = response[9];
            callSign = response[10];
            altitude = string.IsNullOrWhiteSpace(response[11])? (int?)null : int.Parse(response[11]);
            groundSpeed = string.IsNullOrWhiteSpace(response[12]) ? (int?)null : int.Parse(response[12]);
            track = string.IsNullOrWhiteSpace(response[13]) ? (int?)null : int.Parse(response[13]);
            lat = string.IsNullOrWhiteSpace(response[14]) ? (float?)null : float.Parse(response[14]); 
            lon = string.IsNullOrWhiteSpace(response[15]) ? (float?)null : float.Parse(response[15]);
            verticalRate = string.IsNullOrWhiteSpace(response[16]) ? (int?)null : int.Parse(response[16]);
            squawk = response[17];
            alert = string.IsNullOrWhiteSpace(response[18]) ? false : response[18] == "0" ? false : true;
            emergency = string.IsNullOrWhiteSpace(response[19]) ? false : response[19] == "0" ? false : true;
            spi = string.IsNullOrWhiteSpace(response[20]) ? false : response[20] == "0" ? false : true;
            isOnGround = string.IsNullOrWhiteSpace(response[21]) ? false : response[21] == "0"? false : true;
        }
        public override string ToString()
        {
            return messageType.ToString() + ":" +lat + ","+ lon;
        }
    }
}
