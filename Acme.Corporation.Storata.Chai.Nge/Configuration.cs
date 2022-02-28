using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MFiles.VAF.Configuration;
using MFiles.VAF.Configuration.JsonAdaptor;
using MFilesAPI;

namespace Acme.Corporation.Storata.Chai.Nge
{
    [DataContract]
    public class Configuration
    {

       public const string PERSON_CLASS_NAME = "person";

        #region Configuration 2.3.1
        [DataMember]
        [JsonConfEditor(DefaultValue = false, Label = "Application Enabled")]
        public bool ApplicationEnabled { get; set; }

        [MFUserGroup(Required = true)]
        public MFIdentifier ContractManagersUserGroup
	        = "MF.UG.ContractManagers";

        [MFUserGroup(Required = true)]
        public MFIdentifier ExecutiveManagersUserGroup
            = "MF.UG.ExecutiveManagement";

        [MFValueListItem(Required = true, ValueList = "MF.VL.Role")]
        public MFIdentifier ContractManagerRoleVLItem { get; set; }
            = "{F0D28476-F58D-440F-8E65-D3A58AA916C9}";

        [MFValueListItem(Required = true, ValueList = "MF.VL.Role")]
        public MFIdentifier ExecutiveManagementRoleVLItem { get; set; }
            = "{9A9A3642-6E0F-4817-BFFF-4A7A14F7C000}";


        [MFValueList(Required = true)]
        public MFIdentifier RoleVList { get; set; }
            = "MF.VL.Role";
        #endregion

        #region Class

        [MFClass(Required = true)]
        public MFIdentifier DeliveryAgreementClass { get; set; }
            = "MF.CL.DeliveryAgreement";

        [MFClass(Required = true)]
        public MFIdentifier SupplierAgreementClass { get; set; }
            = "MF.CL.SupplierAgreement";
        #endregion


        #region Documents
        [MFPropertyDef(Required = true)]
        public MFIdentifier SubjectTxtProperty { get; set; }
            = "MF.PD.Subject";

        [MFPropertyDef(Required = true)]
        public MFIdentifier CustomerSelectMProperty { get; set; }
        = "MF.PD.Customer";

        [MFPropertyDef(Required = true)]
        public MFIdentifier SupplierSelectMProperty { get; set; }
        = "MF.PD.Supplier";
        #endregion

        #region Person
        [MFPropertyDef(Required = true)]
        public MFIdentifier RolesSelectMProperty { get; set; }
            = "MF.PD.Roles";

        [MFPropertyDef(Required = true)]
        public MFIdentifier RolesBoolProperty { get; set; }
            = "MF.PD.FormerEmployee";
        #endregion



        //      [DataMember]
        //      [MFValueListItem(AllowEmpty = false)]
        //      public MFIdentifier HubDesignState { get; set; }

        //      [MFValueList]
        //      [JsonConfEditor(Label = "Hubshare Hub state list")]
        //      [DataMember]
        //      public MFIdentifier HubStatusList { get; set; }

        //      [DataMember]
        //      [MFPropertyDef(Datatypes = new MFDataType[] { MFDataType.MFDatatypeLookup })]
        //      public MFIdentifier HubStateProperty { get; set; }

        //      [MFClass(Required = true)]
        //      [DataMember]
        //      public MFIdentifier MyClass { get; set; }
        //          = "MFiles.Class.PurchaseOrder";



        //      [MFPropertyDef(Required = true)]
        //      [DataMember]
        //      public MFIdentifier MyPropertyDefinition { get; set; }
        //          = "MFiles.PropertyDef.PurchaseOrderNumber";




        //[MFWorkflow]
        //      [JsonConfEditor(Label = "Object Workflow")]
        //      [DataMember]
        //      public MFIdentifier Workflow { get; set; }



        //      [MFState]
        //      [DataMember]
        //      [JsonConfEditor(Label = "State")]
        //      public MFIdentifier State { get; set; }
        //      [MFStateTransition]

        //      [DataMember]
        //      [JsonConfEditor(Label = "Transitions")]
        //      public List<MFIdentifier> Transitions { get; set; }


        //      [MFValueList(Required = true)]

        //      public MFIdentifier CountriesValueList = "MFiles.ValueList.Countries";



        //      /// <summary> Refers to an item in a value list in the vault. </summary>

        //      /// <remarks> Use its GUID instead. </remarks>

        //      [MFValueListItem(Required = true, ValueList = "MFiles.ValueList.Countries")]

        //      public MFIdentifier UnitedKingdomCountryValueList

        //          = "{2F7A844E-1E91-41DA-8EA8-80A31A4BCD41}";


        //      /// <summary> Refers to a named access control list in the vault. </summary>
        //      [MFNamedACL(Required = true)]
        //      public MFIdentifier OnlyForMeNamedAccessControlList = "MFiles.NamedACL.OnlyForMe";

        //      /// <summary> Refers to a user group in the vault. </summary>
        //      [MFUserGroup(Required = true)]
        //      public MFIdentifier FinanceUserGroup = "MFiles.UserGroup.FinanceUsers";

        //      /// <summary> Refers to a view in the vault. </summary>
        //      /// <remarks> This is the view's Id, as shown in its properties dialog. </remarks>
        //      [MFView(Required = true)]
        //      public MFIdentifier CustomersView = 142;
    }
}