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
    /// Represents the type of service or subscription given to a user
    /// </summary>
    public enum ServiceTypeId
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// AvaTaxST
        /// </summary>
        AvaTaxST = 1,

        /// <summary>
        /// AvaTaxPro
        /// </summary>
        AvaTaxPro = 2,

        /// <summary>
        /// AvaTaxGlobal
        /// </summary>
        AvaTaxGlobal = 3,

        /// <summary>
        /// AutoAddress
        /// </summary>
        AutoAddress = 4,

        /// <summary>
        /// AutoReturns
        /// </summary>
        AutoReturns = 5,

        /// <summary>
        /// TaxSolver
        /// </summary>
        TaxSolver = 6,

        /// <summary>
        /// AvaTaxCsp
        /// </summary>
        AvaTaxCsp = 7,

        /// <summary>
        /// Twe
        /// </summary>
        Twe = 8,

        /// <summary>
        /// Mrs
        /// </summary>
        Mrs = 9,

        /// <summary>
        /// AvaCert
        /// </summary>
        AvaCert = 10,

        /// <summary>
        /// AuthorizationPartner
        /// </summary>
        AuthorizationPartner = 11,

        /// <summary>
        /// CertCapture
        /// </summary>
        CertCapture = 12,

        /// <summary>
        /// AvaUpc
        /// </summary>
        AvaUpc = 13,

        /// <summary>
        /// AvaCUT
        /// </summary>
        AvaCUT = 14,

        /// <summary>
        /// AvaLandedCost
        /// </summary>
        AvaLandedCost = 15,

        /// <summary>
        /// AvaLodging
        /// </summary>
        AvaLodging = 16,

        /// <summary>
        /// AvaBottle
        /// </summary>
        AvaBottle = 17,

        /// <summary>
        /// AvaComms
        /// </summary>
        AvaComms = 18,

        /// <summary>
        /// AvaEWaste
        /// </summary>
        AvaEWaste = 19,

        /// <summary>
        /// AvaExemptTier1
        /// </summary>
        AvaExemptTier1 = 20,

        /// <summary>
        /// AvaExemptTier2
        /// </summary>
        AvaExemptTier2 = 21,

        /// <summary>
        /// AvaExemptTier3
        /// </summary>
        AvaExemptTier3 = 22,

        /// <summary>
        /// AvaExemptTier4
        /// </summary>
        AvaExemptTier4 = 23,

        /// <summary>
        /// MRSComplianceManager
        /// </summary>
        MRSComplianceManager = 24,

        /// <summary>
        /// AvaBikeTax
        /// </summary>
        AvaBikeTax = 25,

        /// <summary>
        /// AvaCheckoutBag
        /// </summary>
        AvaCheckoutBag = 26,

        /// <summary>
        /// TFOCompliance
        /// </summary>
        TFOCompliance = 27,

        /// <summary>
        /// Send Sales Rate file service
        /// </summary>
        SendSalesRateFile = 28,

        /// <summary>
        /// AvaMeals
        /// </summary>
        AvaMeals = 29,

        /// <summary>
        /// AvaAlcohol
        /// </summary>
        AvaAlcohol = 30,

        /// <summary>
        /// Accounting Firm ARA Service Type
        /// </summary>
        ARA = 31,

        /// <summary>
        /// Accounting Firm ManagedARA Service Type
        /// </summary>
        ManagedARA = 32,

    }
}
