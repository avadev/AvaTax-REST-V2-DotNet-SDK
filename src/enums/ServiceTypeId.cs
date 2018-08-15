using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents the type of service or subscription given to a user
    /// </summary>
    public enum ServiceTypeId
    {
        /// <summary>
        /// None
        /// </summary>
        None,

        /// <summary>
        /// AvaTaxST
        /// </summary>
        AvaTaxST,

        /// <summary>
        /// AvaTaxPro
        /// </summary>
        AvaTaxPro,

        /// <summary>
        /// AvaTaxGlobal
        /// </summary>
        AvaTaxGlobal,

        /// <summary>
        /// AutoAddress
        /// </summary>
        AutoAddress,

        /// <summary>
        /// AutoReturns
        /// </summary>
        AutoReturns,

        /// <summary>
        /// TaxSolver
        /// </summary>
        TaxSolver,

        /// <summary>
        /// AvaTaxCsp
        /// </summary>
        AvaTaxCsp,

        /// <summary>
        /// Twe
        /// </summary>
        Twe,

        /// <summary>
        /// Mrs
        /// </summary>
        Mrs,

        /// <summary>
        /// AvaCert
        /// </summary>
        AvaCert,

        /// <summary>
        /// AuthorizationPartner
        /// </summary>
        AuthorizationPartner,

        /// <summary>
        /// CertCapture
        /// </summary>
        CertCapture,

        /// <summary>
        /// AvaUpc
        /// </summary>
        AvaUpc,

        /// <summary>
        /// AvaCUT
        /// </summary>
        AvaCUT,

        /// <summary>
        /// AvaLandedCost
        /// </summary>
        AvaLandedCost,

        /// <summary>
        /// AvaLodging
        /// </summary>
        AvaLodging,

        /// <summary>
        /// AvaBottle
        /// </summary>
        AvaBottle,

        /// <summary>
        /// AvaComms
        /// </summary>
        AvaComms,

        /// <summary>
        /// AvaEWaste
        /// </summary>
        AvaEWaste,

        /// <summary>
        /// AvaExemptTier1
        /// </summary>
        AvaExemptTier1,

        /// <summary>
        /// AvaExemptTier2
        /// </summary>
        AvaExemptTier2,

        /// <summary>
        /// AvaExemptTier3
        /// </summary>
        AvaExemptTier3,

        /// <summary>
        /// AvaExemptTier4
        /// </summary>
        AvaExemptTier4,

        /// <summary>
        /// MRSComplianceManager
        /// </summary>
        MRSComplianceManager,

        /// <summary>
        /// AvaBikeTax
        /// </summary>
        AvaBikeTax,

        /// <summary>
        /// AvaCheckoutBag
        /// </summary>
        AvaCheckoutBag,

        /// <summary>
        /// TFOCompliance
        /// </summary>
        TFOCompliance,

        /// <summary>
        /// Send Sales Rate file service
        /// </summary>
        SendSalesRateFile,

    }
}
