using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

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
