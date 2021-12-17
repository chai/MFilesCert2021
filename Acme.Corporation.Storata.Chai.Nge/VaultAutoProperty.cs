using MFiles.VAF.Common;
using MFilesAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Corporation.Storata.Chai.Nge
{
    public partial class VaultApplication
    {
        /*
         Original VB
        Dim oPropVals: Set oPropVals = CreateObject("MFilesApi.PropertyValues")
        Set oPropVals = Vault.ObjectPropertyOperations.GetProperties(ObjVer)
        Dim szDocumentTitle: szDocumentTitle = ""
        If oPropVals.SearchForProperty(100).TypedValue.GetValueAsLookup.DisplayID = 5 Then
            szDocumentTitle = oPropVals.SearchForProperty(100).TypedValue.DisplayValue + " - " + oPropVals.SearchForProperty(1034).TypedValue.DisplayValue + " - " + oPropVals.SearchForProperty(1027).TypedValue.DisplayValue
        Elseif oPropVals.SearchForProperty(100).TypedValue.GetValueAsLookup.DisplayID = 6 Then
            szDocumentTitle = oPropVals.SearchForProperty(100).TypedValue.DisplayValue + " - " + oPropVals.SearchForProperty(1034).TypedValue.DisplayValue + " - " + oPropVals.SearchForProperty(1042).TypedValue.DisplayValue
        End If
        Output = szDocumentTitle
         */
        [PropertyCustomValue("PD.Signed Quotes Title")]
        public TypedValue ContractTitle(PropertyEnvironment env)
        {
            try
            {
                var typevalue = new TypedValue();
                if (env.ObjVerEx.Class==Configuration.ClassDeliveryAgreement)
                {

                }
 
            }
            catch (Exception ex)
            {

                SysUtils.ReportErrorToEventLog($"ContractTitle { env.ObjVerEx } - {env.ObjVerEx.Title}", ex);
            }

            return typevalue;
        }
    }
}
