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
    /// The address resolution quality of an address validation result
    /// </summary>
    public enum ResolutionQuality
    {
        /// <summary>
        /// Location was not geocoded
        /// </summary>
        NotCoded,

        /// <summary>
        /// Location was already geocoded on the request
        /// </summary>
        External,

        /// <summary>
        /// Avalara-defined country centroid
        /// </summary>
        CountryCentroid,

        /// <summary>
        /// Avalara-defined state / province centroid
        /// </summary>
        RegionCentroid,

        /// <summary>
        /// Geocoded at a level more coarse than a PostalCentroid1
        /// </summary>
        PartialCentroid,

        /// <summary>
        /// Largest postal code (zip5 in US, left three in CA, etc
        /// </summary>
        PostalCentroidGood,

        /// <summary>
        /// Better postal code (zip7 in US)
        /// </summary>
        PostalCentroidBetter,

        /// <summary>
        /// Best postal code (zip9 in US, complete postal code elsewhere)
        /// </summary>
        PostalCentroidBest,

        /// <summary>
        /// Nearest intersection
        /// </summary>
        Intersection,

        /// <summary>
        /// Interpolated to rooftop
        /// </summary>
        Interpolated,

        /// <summary>
        /// Assumed to be rooftop level, non-interpolated
        /// </summary>
        Rooftop,

        /// <summary>
        /// Pulled from a static list of geocodes for specific jurisdictions
        /// </summary>
        Constant,

    }
}
