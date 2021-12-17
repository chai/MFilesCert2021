using System;
using System.Collections.Generic;
using System.Diagnostics;
using MFiles.VAF;
using MFiles.VAF.Common;
using MFiles.VAF.Configuration;
using MFiles.VAF.Configuration.AdminConfigurations;
using MFiles.VAF.Core;
using MFilesAPI;

namespace Acme.Corporation.Storata.Chai.Nge
{
    /// <summary>
    /// The entry point for this Vault Application Framework application.
    /// </summary>
    /// <remarks>Examples and further information available on the developer portal: http://developer.m-files.com/. </remarks>
    public partial class VaultApplication
        : ConfigurableVaultApplicationBase<Configuration>
    {

        /// <summary>
        /// Boiler Plate getting the configuration ready and available for used in the rest of the vaf
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override string GetDashboardContent(IConfigurationRequestContext context)
        {
            return "Developer Certification VAF for Chai Nge";
        }
        //protected override void OnConfigurationUpdated(IConfigurationRequestContext context, ClientOperations clientOps, Configuration oldConfiguration)
        //{
        //    base.OnConfigurationUpdated(context, clientOps, oldConfiguration);


        //}

        public override void StartOperations(Vault vaultPersistent)
        {        
            base.StartOperations(vaultPersistent);
        }

        protected override IEnumerable<ValidationFinding> CustomValidation(Vault vault, Configuration config)

        {

            return base.CustomValidation(vault, config);

        }



    }
}