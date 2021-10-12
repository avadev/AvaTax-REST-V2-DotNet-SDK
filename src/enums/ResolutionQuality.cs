using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2019 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Genevieve Conty
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
    public enum ResolutionQuality
    {
        /// <summary>
        /// 
        /// </summary>
        NotCoded = 0,

        /// <summary>
        /// 
        /// </summary>
        External = 1,

        /// <summary>
        /// 
        /// </summary>
        CountryCentroid = 2,

        /// <summary>
        /// 
        /// </summary>
        RegionCentroid = 3,

        /// <summary>
        /// 
        /// </summary>
        PartialCentroid = 4,

        /// <summary>
        /// 
        /// </summary>
        PostalCentroidGood = 5,

        /// <summary>
        /// 
        /// </summary>
        PostalCentroidBetter = 6,

        /// <summary>
        /// 
        /// </summary>
        PostalCentroidBest = 7,

        /// <summary>
        /// 
        /// </summary>
        Intersection = 8,

        /// <summary>
        /// 
        /// </summary>
        Interpolated = 9,

        /// <summary>
        /// 
        /// </summary>
        Rooftop = 10,

        /// <summary>
        /// 
        /// </summary>
        Constant = 11,

    }
}
