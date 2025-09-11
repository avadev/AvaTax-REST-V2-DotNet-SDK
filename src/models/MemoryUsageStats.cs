using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    /// Memory usage statistics
    /// </summary>
    public class MemoryUsageStats
    {
        /// <summary>
        /// Total physical memory available on the system in bytes
        /// </summary>
        public Int64? totalPhysicalMemory { get; set; }

        /// <summary>
        /// Total physical memory available on the system in GB
        /// </summary>
        public Decimal? totalPhysicalMemoryGB { get; set; }

        /// <summary>
        /// Available physical memory on the system in bytes
        /// </summary>
        public Int64? availablePhysicalMemory { get; set; }

        /// <summary>
        /// Available physical memory on the system in GB
        /// </summary>
        public Decimal? availablePhysicalMemoryGB { get; set; }

        /// <summary>
        /// Used physical memory on the system in bytes
        /// </summary>
        public Int64? usedPhysicalMemory { get; set; }

        /// <summary>
        /// Used physical memory on the system in GB
        /// </summary>
        public Decimal? usedPhysicalMemoryGB { get; set; }

        /// <summary>
        /// Percentage of physical memory currently in use
        /// </summary>
        public Decimal? physicalMemoryUsagePercentage { get; set; }

        /// <summary>
        /// Total virtual memory available to the process in bytes
        /// </summary>
        public Int64? totalVirtualMemory { get; set; }

        /// <summary>
        /// Total virtual memory available to the process in GB
        /// </summary>
        public Decimal? totalVirtualMemoryGB { get; set; }

        /// <summary>
        /// Available virtual memory to the process in bytes
        /// </summary>
        public Int64? availableVirtualMemory { get; set; }

        /// <summary>
        /// Available virtual memory to the process in GB
        /// </summary>
        public Decimal? availableVirtualMemoryGB { get; set; }

        /// <summary>
        /// Used virtual memory by the process in bytes
        /// </summary>
        public Int64? usedVirtualMemory { get; set; }

        /// <summary>
        /// Used virtual memory by the process in GB
        /// </summary>
        public Decimal? usedVirtualMemoryGB { get; set; }

        /// <summary>
        /// Percentage of virtual memory currently in use
        /// </summary>
        public Decimal? virtualMemoryUsagePercentage { get; set; }

        /// <summary>
        /// Total size of the managed heap in bytes
        /// </summary>
        public Int64? managedHeapSize { get; set; }

        /// <summary>
        /// Total size of the managed heap in GB
        /// </summary>
        public Decimal? managedHeapSizeGB { get; set; }

        /// <summary>
        /// Used portion of the managed heap in bytes
        /// </summary>
        public Int64? managedHeapUsed { get; set; }

        /// <summary>
        /// Used portion of the managed heap in GB
        /// </summary>
        public Decimal? managedHeapUsedGB { get; set; }

        /// <summary>
        /// Free portion of the managed heap in bytes
        /// </summary>
        public Int64? managedHeapFree { get; set; }

        /// <summary>
        /// Free portion of the managed heap in GB
        /// </summary>
        public Decimal? managedHeapFreeGB { get; set; }

        /// <summary>
        /// Percentage of managed heap currently in use
        /// </summary>
        public Decimal? managedHeapUsagePercentage { get; set; }

        /// <summary>
        /// Current working set size of the process in bytes
        /// </summary>
        public Int64? workingSetSize { get; set; }

        /// <summary>
        /// Current working set size of the process in GB
        /// </summary>
        public Decimal? workingSetSizeGB { get; set; }

        /// <summary>
        /// Private memory size of the process in bytes
        /// </summary>
        public Int64? privateMemorySize { get; set; }

        /// <summary>
        /// Private memory size of the process in GB
        /// </summary>
        public Decimal? privateMemorySizeGB { get; set; }

        /// <summary>
        /// Peak working set size of the process in bytes
        /// </summary>
        public Int64? peakWorkingSetSize { get; set; }

        /// <summary>
        /// Peak working set size of the process in GB
        /// </summary>
        public Decimal? peakWorkingSetSizeGB { get; set; }

        /// <summary>
        /// Peak virtual memory size of the process in bytes
        /// </summary>
        public Int64? peakVirtualMemorySize { get; set; }

        /// <summary>
        /// Peak virtual memory size of the process in GB
        /// </summary>
        public Decimal? peakVirtualMemorySizeGB { get; set; }

        /// <summary>
        /// Number of Gen0 garbage collections performed
        /// </summary>
        public Int32? garbageCollectionGen0Count { get; set; }

        /// <summary>
        /// Number of Gen1 garbage collections performed
        /// </summary>
        public Int32? garbageCollectionGen1Count { get; set; }

        /// <summary>
        /// Number of Gen2 garbage collections performed
        /// </summary>
        public Int32? garbageCollectionGen2Count { get; set; }

        /// <summary>
        /// Timestamp when the memory statistics were collected
        /// </summary>
        public DateTime? timestamp { get; set; }

        /// <summary>
        /// Name of the machine where the process is running
        /// </summary>
        public String machineName { get; set; }

        /// <summary>
        /// Name of the process
        /// </summary>
        public String processName { get; set; }

        /// <summary>
        /// Process ID
        /// </summary>
        public Int32? processId { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
