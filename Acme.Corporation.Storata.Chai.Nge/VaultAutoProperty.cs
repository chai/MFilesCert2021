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

        private string SignQuotesTitle(ObjVerEx objVerEx)
        {
            if (false == this.Configuration.TxtPropertySubject.IsResolved)
            {
                throw new NotFoundException();
            }
            return $"{objVerEx.GetPropertyText(MFBuiltInPropertyDef.MFBuiltInPropertyDefClass)} - {objVerEx.GetPropertyText(Configuration.TxtPropertySubject)}";
        }

        [PropertyCustomValue("MF.PD.ContractTitle")]
        public TypedValue ContractTitle(PropertyEnvironment env)
        {


            var _typevalue = new TypedValue();

            var _objVerEx = env.ObjVerEx;
            var _szDocumentTitle = string.Empty;

            try
            {

                if (env.ObjVerEx.Class==Configuration.ClassDeliveryAgreement)
                {
                    //1034 = MF.PD.Subject
                    //1027 = MF.PD.Customer
                    if (false == this.Configuration.SelectMPropertyCustomer.IsResolved)
                    {
                    return    _typevalue;
                    }

                    _szDocumentTitle = $"{SignQuotesTitle(_objVerEx)} - {_objVerEx.GetPropertyText(Configuration.SelectMPropertyCustomer)}";                                           

                }
                else if (env.ObjVerEx.Class == Configuration.ClassSupplierAgreement)
                {

                    //1042 = MF.PD.Supplier
                    if (false == this.Configuration.SelectMPropertySupplier.IsResolved)
                    {
                        return _typevalue;
                    }
                    _szDocumentTitle = $"{SignQuotesTitle(_objVerEx)} - {_objVerEx.GetPropertyText(Configuration.SelectMPropertySupplier)}";
                }

            }
            catch (Exception ex)
            {

                SysUtils.ReportErrorToEventLog($"ContractTitle { _objVerEx } - {_objVerEx.Title}", ex);
            }




             _typevalue.SetValue(MFDataType.MFDatatypeText, _szDocumentTitle);
            
            //_objVerEx.SetModifiedBy(env.CurrentUserID);
            return _typevalue;
        }
    }
}
