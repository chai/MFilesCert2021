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
        [EventHandler(MFEventHandlerType.MFEventHandlerAfterCheckInChangesFinalize, ObjectType = "MF.OT.Person")]

        public void CheckForRoles(EventHandlerEnvironment env)
        {

            //Applied only to Person class, normally would apply via Attribute 
            //e.g.         [EventHandler(MFEventHandlerType.MFEventHandlerAfterCheckInChangesFinalize, ObjectType = "F.OT.Person", Class = "Class Alias")]
            //but as we're not changing anything in the vault, including adding alia
            //we're setting up a manual check
            try
            {
                if (false == isOfClass(env.ObjVerEx, Configuration.PERSON_CLASS_NAME))
                { return; }


                if (false == this.Configuration.ContractManagersUserGroup.IsResolved)
                { return; }

                if (false == this.Configuration.ExecutiveManagersUserGroup.IsResolved)
                { return; }

                if (false == this.Configuration.ContractManagerRoleVLItem.IsResolved)
                { return; }

                if (false == this.Configuration.ExecutiveManagementRoleVLItem.IsResolved)
                { return; }

                if (false == this.Configuration.RolesSelectMProperty.IsResolved)
                { return; }

                // var RoleList = env.ObjVerEx.GetAllDirectReferences(this.Configuration.SelectMPropertyRoles);
                var aaroleChange = new ObjVerChanges(env.ObjVerEx).Changed;
                var roleChange = new ObjVerChanges(env.ObjVerEx).Changed.FirstOrDefault(p => p.PropertyDef == this.Configuration.RolesSelectMProperty);
                if (roleChange != null)
                {
                    switch (roleChange.ChangeType)
                    {
                        case PropertyValueChangeType.Added:
                            // Handle New Person.
                            // 
                            break;
                        case PropertyValueChangeType.Modified:
                            // Handle modified values.
                            break;
                        case PropertyValueChangeType.Removed:
                            // Handle delete Person.

                            break;
                    }

                }

                //  var roleChange = objVerChanges.FirstOrDefault(p => p.PropertyDef == this.Configuration.RolesSelectMProperty);


            }
            catch (Exception ex)
            {

            }
        }

        [EventHandler(MFEventHandlerType.MFEventHandlerAfterDeleteObject, ObjectType = "MF.OT.Person")]
        [EventHandler(MFEventHandlerType.MFEventHandlerAfterDestroyObject, ObjectType = "MF.OT.Person")]

        public void RemoveFromRoles(EventHandlerEnvironment env)
        {

            //Applied only to Person class, normally would apply via Attribute 
            //e.g.         [EventHandler(MFEventHandlerType.MFEventHandlerAfterCheckInChangesFinalize, ObjectType = "F.OT.Person", Class = "Class Alias")]
            //but as we're not changing anything in the vault, including adding alias
            //we're setting up a manual check

            try
            {
                if (false == isOfClass(env.ObjVerEx, Configuration.PERSON_CLASS_NAME))
                {return;}

                if (false == this.Configuration.ContractManagersUserGroup.IsResolved)
                { return; }

                if (false == this.Configuration.ExecutiveManagersUserGroup.IsResolved)
                { return; }

                if (false == this.Configuration.ContractManagerRoleVLItem.IsResolved)
                { return; }

                if (false == this.Configuration.ExecutiveManagementRoleVLItem.IsResolved)
                { return; }

                if (false == this.Configuration.RolesSelectMProperty.IsResolved)
                { return; }




            }
            catch (Exception ex)
            {

            }
        }



    }
}
