﻿namespace SAEON.Observations.WebAPI
{

    #region SpacialCoverage
    /*
    public class SpacialCoverageInput : DataQueryInput { }

    public enum SpacialStatus
    {
        NoStatus,
        Unverified,
        BeingVerified,
        Verified
    }

    public class SpacialMapPoint : MapPoint
    {
        public SpacialStatus Status { get; set; }
    }

    public class SpacialStation
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Elevation { get; set; }
        public string Url { get; set; }
        public SpacialStatus Status { get; set; }
        public int NoStatus { get; set; }
        public int Unverified { get; set; }
        public int BeingVerified { get; set; }
        public int Verified { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is SpacialStation spacialStation)) return false;
            return Equals(spacialStation);
        }

        public bool Equals(SpacialStation spacialStation)
        {
            if (spacialStation == null) return false;
            return
                (Name == spacialStation.Name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;
                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!(Name is null) ? Name.GetHashCode() : 0);
                return hash;
            }
        }
    }

    public class SpacialCoverageOutput
    {
        public List<SpacialStation> Stations { get; private set; } = new List<SpacialStation>();
    }
    */
    #endregion

    #region TemporalCoverage
    /*
    public class TemporalCoverageInput : DataQueryInput { }

    public class TemporalCoverageOutput
    {
        public List<DataSeries> Series { get; private set; } = new List<DataSeries>();
        public List<ExpandoObject> Data { get; private set; } = new List<ExpandoObject>();
    }
    */
    #endregion
}
