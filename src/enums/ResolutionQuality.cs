using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2023 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Jonathan Wenger <jonathan.wenger@avalara.com>
 * @author Sachin Baijal <sachin.baijal@avalara.com>
 * Swagger name: AvaTaxClient 
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// The address resolution quality of an address validation result
    /// </summary>
    public enum ResolutionQuality
    {
        /// <summary>
        /// Location was not geocoded
        /// </summary>
        NotCoded = 0,

        /// <summary>
        /// Location was already geocoded on the request
        /// </summary>
        External = 1,

        /// <summary>
        /// Avalara-defined country centroid
        /// </summary>
        CountryCentroid = 2,

        /// <summary>
        /// Avalara-defined state / province centroid
        /// </summary>
        RegionCentroid = 3,

        /// <summary>
        /// Geocoded at a level more coarse than a PostalCentroid1
        /// </summary>
        PartialCentroid = 4,

        /// <summary>
        /// Largest postal code (zip5 in US, left three in CA, etc
        /// </summary>
        PostalCentroidGood = 5,

        /// <summary>
        /// Better postal code (zip7 in US)
        /// </summary>
        PostalCentroidBetter = 6,

        /// <summary>
        /// Best postal code (zip9 in US, complete postal code elsewhere)
        /// </summary>
        PostalCentroidBest = 7,

        /// <summary>
        /// Nearest intersection
        /// </summary>
        Intersection = 8,

        /// <summary>
        /// Interpolated to rooftop
        /// </summary>
        Interpolated = 9,

        /// <summary>
        /// Assumed to be rooftop level, non-interpolated
        /// </summary>
        Rooftop = 10,

        /// <summary>
        /// Pulled from a static list of geocodes for specific jurisdictions
        /// </summary>
        Constant = 11,

    }
}
