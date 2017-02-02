using System;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// ResolutionQuality
    /// </summary>
    public enum ResolutionQuality
    {
        /// <summary>
        /// 
        /// </summary>
        NotCoded,

        /// <summary>
        /// 
        /// </summary>
        External,

        /// <summary>
        /// 
        /// </summary>
        CountryCentroid,

        /// <summary>
        /// 
        /// </summary>
        RegionCentroid,

        /// <summary>
        /// 
        /// </summary>
        PartialCentroid,

        /// <summary>
        /// 
        /// </summary>
        PostalCentroidGood,

        /// <summary>
        /// 
        /// </summary>
        PostalCentroidBetter,

        /// <summary>
        /// 
        /// </summary>
        PostalCentroidBest,

        /// <summary>
        /// 
        /// </summary>
        Intersection,

        /// <summary>
        /// 
        /// </summary>
        Interpolated,

        /// <summary>
        /// 
        /// </summary>
        Rooftop,

        /// <summary>
        /// 
        /// </summary>
        Constant,

    }
}
